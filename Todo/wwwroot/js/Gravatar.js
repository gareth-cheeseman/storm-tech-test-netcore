import { getJson } from './FetchService.js';

export const generateHash = email => {
  return SparkMD5.hash(email);
};

export const gravatarNameUrl = hash => {
  return `https://en.gravatar.com/${hash}.json`;
};

export const gravatarImageUrl = hash => {
  return `https://gravatar.com/avatar/${hash}?s=30`;
};

export const getUniqueHashes = () => {
  const elements = Array.from(document.querySelectorAll('[data-hash]'));
  const hashes = elements.map(e => e.getAttribute('data-hash'));
  const uniqueHashes = [...new Set(hashes)];
  return uniqueHashes;
};

export const getGravatarName = () => {
  const hashes = getUniqueHashes();
  hashes.forEach(async hash => {
    const key = hash + 'name';
    let gravatarNameObject = localStorage.getObject(key);
    if (!gravatarNameObject || gravatarNameObject.expiry < Date.now()) {
      const profile = await getJson(gravatarNameUrl(hash));
      const name = profile.entry[0].displayName;
      const expiry = Date.now() + 64800000; // one week
      gravatarNameObject = { name: name, expiry: expiry };
      localStorage.setObject(key, gravatarNameObject);
    }
    const elements = document.querySelectorAll(
      `[data-gravatar-name][data-hash="${hash}"]`
    );
    elements.forEach(element => {
      element.textContent = gravatarNameObject.name;
    });
  });
};

export const getGravatarImage = () => {
  getUniqueHashes().forEach(hash => {
    const key = hash + 'image';
    const gravatarImage = localStorage.getItem(key);
    if (gravatarImage) {
      const elements = document.querySelectorAll(`img[data-hash="${hash}"]`);
      elements.forEach(element => (element.src = gravatarImage));
    } else {
      const elements = document.querySelectorAll(`img[data-hash="${hash}"]`);
      elements.forEach(element => (element.src = gravatarImageUrl(hash)));
      const gravatarImage = document.querySelector(`img[data-hash="${hash}"]`);
      gravatarImage.addEventListener(
        'load',
        () => {
          const canvas = document.createElement('canvas'),
            imageContext = canvas.getContext('2d');
          canvas.width = gravatarImage.width;
          canvas.height = gravatarImage.height;
          imageContext.drawImage(
            gravatarImage,
            0,
            0,
            gravatarImage.width,
            gravatarImage.height
          );
          const dataUrl = canvas.toDataURL('image/jpeg');

          localStorage.setItem(key, dataUrl);
        },
        false
      );
    }
  });
};
