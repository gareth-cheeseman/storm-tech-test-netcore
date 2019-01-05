expect.extend({
  toEqualIgnoringWhiteSpace(received, actual) {
    const removeWhiteSpace = function(input) {
      return input.replace(/\s/g, '');
    };

    received = removeWhiteSpace(received);
    actual = removeWhiteSpace(actual);

    const pass = received === actual;

    if (pass) {
      return {
        message: () => `expected ${received} to be equal to ${actual}`,
        pass: true
      };
    } else {
      return {
        message: () => `expected ${received} to be equal to ${actual}`,
        pass: false
      };
    }
  }
});
