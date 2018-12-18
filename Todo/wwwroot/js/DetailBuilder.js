import { getJson } from './FetchService.js';
import { todoSummaryBuild } from './TodoSummaryBuilder.js';

export const detailBuild = (url, todoListId) => {
  getJson(url + todoListId).then(todoList => {
    if (todoList.todoListId == todoListId) {
      todoList.items.forEach(todo => {
        const { todoItemId, title, responsibleParty, importance, rank } = todo;

        const todoSummaryView = todoSummaryBuild(todo);

        const fragment = document
          .createRange()
          .createContextualFragment(todoSummaryView);

        const todoList = document.querySelector('#todos');
        todoList.append(fragment);
      });
    } else {
      console.log('Wrong list returned');
    }
  });
};
