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
  getUniqueHashes().forEach(hash => {
    const gravatarNameScript = document.createElement('script');
    gravatarNameScript.async;
    gravatarNameScript.src = gravatarNameUrl(hash);
    document.body.append(gravatarNameScript);
  });
};

export const getGravatarNameCallback = res => {
  let name = res.entry[0].displayName;
  let hash = res.entry[0].requestHash;
  const elements = document.querySelectorAll(
    `[data-gravatar-name data-hash="${hash}"]`
  );
  elements.forEach(element => (element.innerHTML = name));
};

export const getGravatarImage = () => {
  getUniqueHashes().forEach(hash => {
    const elements = document.querySelectorAll(`img[data-hash="${hash}"]`);
    elements.forEach(element => (element.src = gravatarImageUrl(hash)));
  });
};
