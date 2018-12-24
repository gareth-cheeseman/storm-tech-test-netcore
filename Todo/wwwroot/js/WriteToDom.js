export function writeTemplateToDom(elementId, template) {
  const fragment = document.createRange().createContextualFragment(template);
  const element = document.querySelector(elementId);
  element.append(fragment);
}
