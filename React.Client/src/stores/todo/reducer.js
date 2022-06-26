import {
  GET_STATUSES,
  GET_TODO,
  GET_TODOS_BY_GROUP,
  GET_TODOS_BY_ACCOUNT,
  CREATE_TODO,
  UPDATE_TODO,
  DELETE_TODO,
} from "../constants.js";

const initialState = {
  statuses: [],
  todos: [],
};

export const todoReducer = (state = initialState, action) => {
  switch (action.type) {
    // Получение статусов
    case GET_STATUSES: {
      return { ...state, statuses: action.payload };
    }
    // Получение задачи
    case GET_TODO: {
      return { ...state, todos: action.payload };
    }
    // Получение задач группы
    case GET_TODOS_BY_GROUP: {
      return { ...state, todos: action.payload };
    }
    // Получение задач аккаунта
    case GET_TODOS_BY_ACCOUNT: {
      return { ...state, todos: action.payload };
    }
    // Создание задачи
    case CREATE_TODO: {
      const newTodos = [...state.todos];
      newTodos.push(action.payload);

      return { ...state, todos: newTodos };
    }
    // Обновление задачи
    case UPDATE_TODO: {
      const newTodos = [...state.todos];
      const index = state.todos.findIndex(
        (todo) => todo.id == action.payload.id
      );
      newTodos[index] = action.payload;

      return { ...state, todos: newTodos };
    }
    // Удаление задачи
    case DELETE_TODO: {
      const newTodos = [...state.todos];
      const index = state.todos.findIndex(
        (todo) => todo.id == action.payload.id
      );
      newTodos.slice(index, 1);

      return { ...state, todos: newTodos };
    }
  }

  return state;
};
