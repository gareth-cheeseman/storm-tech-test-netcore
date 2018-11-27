class Gravatar {
  static getUniqueEmailHash() {
    const elements = Array.from(document.querySelectorAll('span[data-hash]'));
    const hashes = elements.map(e => e.getAttribute('data-hash'));
    const uniqueHashes = [...new Set(hashes)];
    return uniqueHashes;
  }

  static addNames(res) {
    const profile = res.entry[0];
    const elements = Array.from(
      document.querySelectorAll(`span[data-hash='${profile.requestHash}']`)
    );
    elements.forEach(element => (element.innerHTML = profile.displayName));
  }

  static namesCall() {
    this.getUniqueEmailHash().forEach(hash => {
      const ggn = document.createElement('script');
      ggn.type = 'text/javascript';
      ggn.async;
      ggn.src = `https://www.gravatar.com/${hash}.json?callback=Gravatar.addNames`;
      document.body.append(ggn);
    });
  }

  static imagesCall() {
    this.getUniqueEmailHash().forEach(hash => {
      const elements = Array.from(
        document.querySelectorAll(`img[data-hash='${hash}']`)
      );
      elements.forEach(
        element =>
          (element.src = `https://www.gravatar.com/avatar/${hash}?s=30`)
      );
    });
  }
}
