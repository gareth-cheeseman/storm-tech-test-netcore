// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let orderByRankButton = document.querySelector(`#orderByRank`);
orderByRankButton.addEventListener(
  'click',
  function(event) {
    if (orderByRankButton.getAttribute('data-orderedByRank') == 'false') {
      orderByRank('false');
      event.target.textContent = 'Order by importance';
      event.target.setAttribute('data-orderedByRank', 'true');
    } else {
      orderByRank('true');
      event.target.textContent = 'Order by rank';
      event.target.setAttribute('data-orderedByRank', 'false');
    }
  },
  false
);

let hideDoneButton = document.querySelector(`#hideDone`);
hideDoneButton.addEventListener(
  'click',
  function(event) {
    if (hideDoneButton.getAttribute('data-hidden-done') == 'false') {
      const elements = document.querySelectorAll('[data-isDone=true]');
      elements.forEach(element =>
        element.setAttribute('style', 'display:none')
      );
      event.target.textContent = 'Show done todos';
      event.target.setAttribute('data-hidden-done', 'true');
    } else {
      const elements = document.querySelectorAll('[data-isDone=true]');
      elements.forEach(element => element.removeAttribute('style'));
      event.target.textContent = 'Hide done todos';
      event.target.setAttribute('data-hidden-done', 'false');
    }
  },
  false
);
