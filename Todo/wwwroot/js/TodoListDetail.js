import { getJson } from './FetchService.js';
import { todoSummary } from './TodoSummary.js';

export const listTodos = url => {
  getJson(url).then(todos =>
    todos.forEach(todo => {
      const { todoItemId, title, rank, responsiblePartyId } = todo;

      const todoSummaryView = todoSummary(
        todoItemId,
        title,
        rank,
        responsiblePartyId
      );

      const fragment = document
        .createRange()
        .createContextualFragment(todoSummaryView);

      const todoList = document.querySelector('#todos');
      todoList.append(fragment);
    })
  );
};
