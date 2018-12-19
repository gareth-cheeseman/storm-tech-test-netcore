export const generateHash = email => {
  return SparkMD5.hash(email);
};

export const gravatarNameUrl = hash => {
  return `https://gravatar.com/${hash}.json?callback=getGravatarNameCallback`;
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
  var hashes = getUniqueHashes();

  hashes.forEach(hash => {
    const key = hash + 'name';
    const gravatarNameObject = localStorage.getObject(key);
    if (!gravatarNameObject || gravatarNameObject.expiry < Date.now()) {
      const gravatarNameScript = document.createElement('script');
      gravatarNameScript.src = gravatarNameUrl(hash);
      document.body.append(gravatarNameScript);
    } else {
      const elements = document.querySelectorAll(
        `[data-gravatar-name][data-hash="${hash}"]`
      );
      elements.forEach(
        element => (element.textContent = gravatarNameObject.name)
      );
    }
  });
};

window.getGravatarNameCallback = res => {
  const name = res.entry[0].displayName;
  const expiry = Date.now() + 604800000; //one week
  const hash = res.entry[0].requestHash;
  const key = hash + 'name';
  const value = { name: name, expiry: expiry };
  localStorage.setObject(key, value);
  const elements = document.querySelectorAll(
    `[data-gravatar-name][data-hash="${hash}"]`
  );
  elements.forEach(element => (element.textContent = name));
};

export const getGravatarImage = () => {
  getUniqueHashes().forEach(hash => {
    const elements = document.querySelectorAll(`img[data-hash="${hash}"]`);
    elements.forEach(element => (element.src = gravatarImageUrl(hash)));
  });
};
