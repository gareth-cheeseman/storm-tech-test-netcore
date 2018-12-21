import { getJson } from './FetchService.js';
import { todoSummaryBuild } from './TodoSummaryBuilder.js';
import { getGravatarName, getGravatarImage } from './Gravatar.js';

export const detailBuild = (url, todoListId) => {
  getJson(url + todoListId).then(todoList => {
    if (todoList.todoListId == todoListId) {
      todoList.items.forEach(todo => {
        const todoSummaryView = todoSummaryBuild(todo);

        const fragment = document
          .createRange()
          .createContextualFragment(todoSummaryView);

        const todoList = document.querySelector('#todos');
        todoList.append(fragment);
      });
      getGravatarImage();
      getGravatarName();
    } else {
      console.log('Wrong list returned');
    }
  });
};
