export const todoSummaryBuild = (todo, hash, hideDone) => {
  const getImportanceClass = impt => {
    switch (impt) {
      case 0:
        return 'list-group-item-danger';
        break;
      case 2:
        return 'list-group-item-info';
        break;
      default:
        break;
    }
  };

  const importanceClass = getImportanceClass(todo.importance);

  const template = `<li class="list-group-item ${importanceClass}" data-isDone="${
    todo.isDone
  }" ${hideDone && todo.isDone ? 'style="display:none"' : ''}>
    <div class="row">
      <div class="col-md-8">
        <a href="/TodoItem/Edit?todoItemId=${todo.todoItemId}">${
    todo.isDone ? `<s>${todo.title}</s>` : `${todo.title}`
  }</a>
      </div>
    
      <div class="col-md-10">
        <strong>Rank</strong>
        <span class="badge">${todo.rank}</span>
      </div>
    
      <div class="col-md-4 text-left">
        <small>${todo.responsibleParty.userName}
        <strong data-gravatar-name data-hash="${hash}">Getting name</strong>
        <img data-gravatar-image data-hash="${hash}" src="../images/DefaultProfile.png" crossorigin="Anonymous"></small>
      </div>
    </div>
  </li>`;

  return template;
};
