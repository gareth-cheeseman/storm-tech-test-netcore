import { getJson } from './FetchService.js';

export const getTodos = url => {
  getJson(url).then(todos =>
    todos.forEach(todo => {
      const { todoItemId, title, rank, responsiblePartyId } = todo;

      const todoTemplate = `<li class="list-group-item">
        <div class="row">
          <div class="col-md-8">
            <a href="/TodoItem/Edit?todoItemId=${todoItemId}">${title}</a>
          </div>

          <div class="col-md-10">
            <strong>Rank</strong>
            <span class="badge">${rank}</span>
          </div>

          <div class="col-md-4 text-left">
            <small>${responsiblePartyId}<small />
          </div>
        </div>
      </li>`;

      const fragment = document
        .createRange()
        .createContextualFragment(todoTemplate);

      const todoList = document.querySelector('#todos');
      todoList.append(fragment);
    })
  );
};
