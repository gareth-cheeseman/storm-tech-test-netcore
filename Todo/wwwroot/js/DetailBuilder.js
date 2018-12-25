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

window.orderByRank = function(status) {
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
};
