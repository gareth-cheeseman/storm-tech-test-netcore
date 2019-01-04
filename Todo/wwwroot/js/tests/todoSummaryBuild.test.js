import { todoSummaryBuild } from '../TodoSummaryBuilder';

const todoHighImportance = {
  todoItemId: 1,
  title: 'Todo High Importance',
  responsibleParty: {
    userName: 'qagctesting@gmail.com',
    email: 'qagctesting@gmail.com'
  },
  isDone: false,
  importance: 0,
  rank: 0
};

const hash = '43884624f97a7071cf13b6a3e9730169';
const hiddenDone = true;

const todoHighImportanceGoldMark = `<li class="list-group-item list-group-item-danger" data-isDone="false" >
  <div class="row">
    <div class="col-md-8">
      <a href="/TodoItem/Edit?todoItemId=1">Todo High Importance</a>
    </div>

    <div class="col-md-10">
      <strong>Rank</strong>
      <span class="badge">0</span>
    </div>

    <div class="col-md-4 text-left">
      <small>qagctesting@gmail.com
      <strong data-gravatar-name data-hash="43884624f97a7071cf13b6a3e9730169">Getting name</strong>
    <img data-gravatar-image data-hash="43884624f97a7071cf13b6a3e9730169" src="../images/DefaultProfile.png" crossorigin="Anonymous"></small>
    </div>
  </div>
</li>`;

test('high importance todo item', () => {
  expect(todoSummaryBuild(todoHighImportance, hash, hiddenDone).trim).toEqual(
    todoHighImportanceGoldMark.trim
  );
});
