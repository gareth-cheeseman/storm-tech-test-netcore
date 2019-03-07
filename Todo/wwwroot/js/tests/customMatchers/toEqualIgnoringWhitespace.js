expect.extend({
  toEqualIgnoringWhiteSpace(received, expected) {
    const removeWhiteSpace = function(input) {
      return input.replace(/\s/g, '');
    };

    received = removeWhiteSpace(received);
    expected = removeWhiteSpace(expected);

    const pass = received === expected;

    if (pass) {
      return {
        message: () => `expected ${received} to be equal to ${expected}`,
        pass: true
      };
    } else {
      return {
        message: () => `expected ${received} to be equal to ${expected}`,
        pass: false
      };
    }
  }
});
