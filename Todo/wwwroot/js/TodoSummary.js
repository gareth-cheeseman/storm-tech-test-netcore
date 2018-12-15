export const todoSummary = (
  todoItemId,
  title,
  responsibleParty,
  importance,
  rank
) => {
  const impStyle = impt => {
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
  const template = `<li class="list-group-item ${impStyle(importance)}">
    <div class="row">
      <div class="col-md-8">
        <a href="/TodoItem/Edit?todoItemId=${todoItemId}">${title}</a>
      </div>
    
      <div class="col-md-10">
        <strong>Rank</strong>
        <span class="badge">${rank}</span>
      </div>
    
      <div class="col-md-4 text-left">
        <small>${responsibleParty.userName}<small />
      </div>
    </div>
    </li>`;

  return template;
};
