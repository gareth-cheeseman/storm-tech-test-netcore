// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let orderByRankButton = document.querySelector(`#orderByRank`);
orderByRankButton.addEventListener(
  'click',
  function(event) {
    if (orderByRankButton.getAttribute('data-orderedByRank') == 'false') {
      orderByRank('false');
      event.target.textContent = 'Do not order by rank?';
      event.target.setAttribute('data-orderedByRank', 'true');
    } else {
      orderByRank('true');
      event.target.textContent = 'Order by rank?';
      event.target.setAttribute('data-orderedByRank', 'false');
    }
  },
  false
);
