import { todoSummaryBuild } from '../TodoSummaryBuilder';
import { todoHighImportanceGoldMark } from './todoHighImportanceGoldMark';
import { todoMediumImportanceGoldMark } from './todoMediumImportanceGoldMark';
import { todoLowImportanceGoldMark } from './todoLowImportanceGoldMark';

const hash = '43884624f97a7071cf13b6a3e9730169';

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

const todoMediumImportance = {
  todoItemId: 1,
  title: 'Todo Medium Importance',
  responsibleParty: {
    userName: 'qagctesting@gmail.com',
    email: 'qagctesting@gmail.com'
  },
  isDone: false,
  importance: 1,
  rank: 0
};

const todoLowImportance = {
  todoItemId: 1,
  title: 'Todo Low Importance',
  responsibleParty: {
    userName: 'qagctesting@gmail.com',
    email: 'qagctesting@gmail.com'
  },
  isDone: false,
  importance: 2,
  rank: 0
};

test('high importance todo item', () => {
  expect(todoSummaryBuild(todoHighImportance, hash)).toEqualIgnoringWhiteSpace(
    todoHighImportanceGoldMark
  );
});

test('medium importance todo item', () => {
  expect(
    todoSummaryBuild(todoMediumImportance, hash)
  ).toEqualIgnoringWhiteSpace(todoMediumImportanceGoldMark);
});

test('low importance todo item', () => {
  expect(todoSummaryBuild(todoLowImportance, hash)).toEqualIgnoringWhiteSpace(
    todoLowImportanceGoldMark
  );
});
