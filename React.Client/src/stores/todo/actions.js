import {
  GET_TODO_API,
  GET_TODOS_API,
  CREATE_TODO_API,
  EDIT_TODO_API,
  DELETE_TODO_API,
} from "../api.js";

import {
  GET_TODO,
  GET_ALL_TODOS,
  ADD_TODO,
  EDIT_TODO,
  DELETE_TODO,
  ADD_NOTIFICATION,
} from "../constants.js";

export const getTodo = (id) => {
  return async (dispatch) => {
    const responce = await fetch(GET_TODO_API + "/" + id, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });
    const json = await responce.json();

    dispatch({ type: GET_TODO, payload: json });
    dispatch({
      type: ADD_NOTIFICATION,
      payload: { title: json.title, description: json.description },
    });
  };
};

export const getAllTodos = () => {
  return async (dispatch) => {
    const responce = await fetch(GET_TODOS_API, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });
    const json = await responce.json();

    dispatch({ type: GET_ALL_TODOS, payload: json });
  };
};

// Добавление задачи
export const addTodo = (data) => {
  return async (dispatch) => {
    await fetch(CREATE_TODO_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    })
      .then((responce) => responce.json())
      .then((json) =>
        dispatch({
          type: ADD_TODO,
          payload: json,
        })
      )
      .catch((error) =>
        dispatch({
          type: ADD_NOTIFICATION,
          payload: { title: error.name, description: error.message },
        })
      );
  };
};

// Редактирование задачи
export const editTodo = (data) => {
  return async (dispatch) => {
    await fetch(EDIT_TODO_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    })
      .then((responce) => responce.json())
      .then((json) =>
        dispatch({
          type: EDIT_TODO,
          payload: json,
        })
      )
      .catch((error) =>
        dispatch({
          type: ADD_NOTIFICATION,
          payload: { title: error.name, description: error.message },
        })
      );
  };
};

// Удаление задачи
export const deleteTodo = (data) => {
  return async (dispatch) => {
    await fetch(DELETE_TODO_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    })
      .then((responce) =>
        dispatch({
          type: DELETE_TODO,
          payload: data,
        })
      )
      .catch((error) =>
        dispatch({
          type: ADD_NOTIFICATION,
          payload: { title: error.name, description: error.message },
        })
      );
  };
};
