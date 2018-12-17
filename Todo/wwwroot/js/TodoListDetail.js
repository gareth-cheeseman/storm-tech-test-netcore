import { getJson } from './FetchService.js';
import { todoSummary } from './TodoSummary.js';

export const detail = (url, todoListId) => {
  getJson(url + todoListId).then(todoList => {
    if (todoList.todoListId == todoListId) {
      todoList.items.forEach(todo => {
        const { todoItemId, title, responsibleParty, importance, rank } = todo;

        const todoSummaryView = todoSummary(
          todoItemId,
          title,
          responsibleParty,
          importance,
          rank
        );

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
