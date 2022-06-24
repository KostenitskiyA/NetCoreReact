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
      return { statuses: action.payload };
    }
    // Получение задачи
    case GET_TODO: {
      return state;
    }
    // Получение задач группы
    case GET_TODOS_BY_GROUP: {
      return { todos: action.payload };
    }
    // Получение задач аккаунта
    case GET_TODOS_BY_ACCOUNT: {
      return { todos: action.payload };
    }
    // Создание задачи
    case CREATE_TODO: {
      const newTodos = [...state.todos];
      newTodos.push(action.payload);

      return { ...state, todos: newTodos };
    }
    // Обновление задачи
    case UPDATE_TODO: {
      const index = state.todos.findIndex(
        (todo) => todo.id == action.payload.id
      );
      const newTodos = [...state.todos];
      newTodos[index] = action.payload;
      return { ...state, todos: newTodos };
    }
    // Удаление задачи
    case DELETE_TODO: {
      const index = state.todos.findIndex(
        (todo) => todo.id == action.payload.id
      );
      const newTodos = [...state.todos];
      newTodos.slice(index, 1);
      return { ...state, todos: newTodos };
    }
  }

  return state;
};
