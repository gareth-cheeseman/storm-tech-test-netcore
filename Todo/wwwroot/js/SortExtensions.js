Object.defineProperty(Array.prototype, 'sortByOrder', {
  value: function(property, valuesInOrder) {
    const map = new Map(
      valuesInOrder.map(value => [value, valuesInOrder.indexOf(value)])
    );
    return this.sort((a, b) => {
      return map.get(a[property]) - map.get(b[property]);
    });
  }
});

const sortByOrderWorks = (array, property, valuesInOrder) => {
  const map = new Map(
    valuesInOrder.map(value => [value, valuesInOrder.indexOf(value)])
  );
  return array.sort((a, b) => {
    return map.get(a[property]) - map.get(b[property]);
  });
};
