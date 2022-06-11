import {
  GET_TODO,
  GET_ALL_TODOS,
  ADD_TODO,
  EDIT_TODO,
  DELETE_TODO,
} from "../constants.js";

const initialState = {
  todos: [],
};

export const todoReducer = (state = initialState, action) => {
  switch (action.type) {
    case GET_TODO:
      return state;
    case GET_ALL_TODOS:
      return { todos: action.payload };

    // Добавление задачи
    case ADD_TODO: {
      const newTodos = [...state.todos];
      newTodos.push(action.payload);
  
      return { ...state, todos: newTodos };
    }
    // Редактирование задачи
    case EDIT_TODO: {
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
