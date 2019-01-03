import { getJson } from './FetchService.js';
import { todoSummaryBuild } from './TodoSummaryBuilder.js';
import { getGravatarName, getGravatarImage } from './Gravatar.js';
import { writeTemplateToDom } from './WriteToDom.js';
import { removeChildren } from './removeChildren.js';

export async function detailBuild(url, todoListId) {
  const todoList = await getJson(url + todoListId);
  localStorage.setObject(`todoList:${todoList.todoListId}`, todoList);
  todoListBuild(todoList.items);
}

export function todoListBuild(todoListItems) {
  removeChildren('#todoList');
  todoListItems.forEach(todo => {
    const todoSummaryView = todoSummaryBuild(todo);
    writeTemplateToDom('#todoList', todoSummaryView);
  });
  getGravatarImage();
  getGravatarName();
}

export function setOrderRankButton() {
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
}

export function orderByRank(status) {
  const todoListId = document
    .querySelector('#todoListId')
    .getAttribute('data-todoListId');

  const todoList = localStorage.getObject(`todoList:${todoListId}`);
  const listToView = todoList.items;
  if (status == 'false') {
    listToView.sort((a, b) => a.rank - b.rank);
    todoListBuild(listToView);
  } else {
    todoListBuild(todoList.items);
  }
}

export function setShowHiddenButton() {
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
}
