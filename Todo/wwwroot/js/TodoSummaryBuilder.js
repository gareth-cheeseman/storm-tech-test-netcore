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

  const gravatarNameHtml = 'test gravatar name';

  const gravatarImageHtml =
    '<img src="https://res.cloudinary.com/hellofresh/image/upload/f_auto,fl_lossy,q_auto,w_640/v1/hellofresh_s3/image/556c0f17f8b25e8d628b4568.png">';

  const template = `<li class="list-group-item ${importanceClass}">
    <div class="row">
      <div class="col-md-8">
        <a href="/TodoItem/Edit?todoItemId=${todo.todoItemId}">${todo.title}</a>
      </div>
    
      <div class="col-md-10">
        <strong>Rank</strong>
        <span class="badge">${todo.rank}</span>
      </div>
    
      <div class="col-md-4 text-left">
        <small>${todo.responsibleParty.userName}
        ${gravatarNameHtml}
        ${gravatarImageHtml}<small />
      </div>
    </div>
    </li>`;

  return template;
};
