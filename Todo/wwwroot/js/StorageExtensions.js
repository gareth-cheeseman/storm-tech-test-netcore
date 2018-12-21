Object.defineProperties(Storage.prototype, {
  setObject: {
    value: function(key, value) {
      this.setItem(key, JSON.stringify(value));
    }
  },
  getObject: {
    value: function(key) {
      var value = this.getItem(key);
      return value && JSON.parse(value);
    }
  }
});
