export const todoSummary = (todoItemId, title, rank, responsiblePartyId) => {
  const template = `<li class="list-group-item">
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

  return template;
};
