import {
  generateHash,
  gravatarNameUrl,
  getGravatarName,
  getGravatarNameCallback,
  gravatarImageUrl,
  getGravatarImage
} from './Gravatar.js';

export const todoSummaryBuild = todo => {
  const getImportanceClass = impt => {
    switch (impt) {
      case 0:
        return 'list-group-item-danger';
        break;
      case 2:
        return 'list-group-item-infor';
        break;
      default:
        break;
    }
  };

  const importanceClass = getImportanceClass(todo.importance);

  const titleWithTag = todo.isDone ? `<s>${todo.title}</s>` : `${todo.title}`;

  const hash = generateHash(todo.responsibleParty.email);

  const template = `<li class="list-group-item ${importanceClass}">
    <div class="row">
      <div class="col-md-8">
        <a href="/TodoItem/Edit?todoItemId=${
          todo.todoItemId
        }">${titleWithTag}</a>
      </div>
    
      <div class="col-md-10">
        <strong>Rank</strong>
        <span class="badge">${todo.rank}</span>
      </div>
    
      <div class="col-md-4 text-left">
        <small>${todo.responsibleParty.userName}
        <strong data-gravatar-name data-hash="${hash}">Getting Gravatar Name</strong>
        <img data-gravatar-image data-hash="${hash}" src="../images/DefaultProfile.png"></small>
      </div>
    </div>
    </li>`;

  return template;
};
