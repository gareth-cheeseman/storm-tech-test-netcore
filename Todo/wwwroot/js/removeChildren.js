export function removeChildren(selector) {
  const element = document.querySelector(selector);
  while (element.lastChild) {
    element.removeChild(element.lastChild);
  }
}
