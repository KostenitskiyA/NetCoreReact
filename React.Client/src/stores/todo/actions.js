import {
  GET_STATUSES_API,
  GET_TODO_API,
  GET_TODOS_BY_GROUP_API,
  GET_TODOS_BY_ACCOUNT_API,
  CREATE_TODO_API,
  UPDATE_TODO_API,
  DELETE_TODO_API,
} from "../api.js";

import {
  GET_STATUSES,
  GET_TODO,
  GET_TODOS_BY_GROUP,
  GET_TODOS_BY_ACCOUNT,
  CREATE_TODO,
  UPDATE_TODO,
  DELETE_TODO,
  ADD_NOTIFICATION,
} from "../constants.js";

// Получение статусов
export const getStatuses = () => {
  return async (dispatch) => {
    const responce = await fetch(GET_STATUSES_API, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });

    const json = await responce.json();
    dispatch({ type: GET_STATUSES, payload: json });
  };
};

// Получение задачи
export const getTodo = (id) => {
  return async (dispatch) => {
    const responce = await fetch(GET_TODO_API + id, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });

    const json = await responce.json();
    dispatch({ type: GET_TODO, payload: json });
  };
};

// Получение задач группы
export const getTodosByGroup = (id) => {
  return async (dispatch) => {
    const responce = await fetch(GET_TODOS_BY_GROUP_API + id, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });

    const json = await responce.json();
    dispatch({ type: GET_TODOS_BY_GROUP, payload: json });
  };
};

// Получение задач аккаунта
export const getTodosByAccount = (id) => {
  return async (dispatch) => {
    const responce = await fetch(GET_TODOS_BY_ACCOUNT_API + id, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });

    const json = await responce.json();
    dispatch({ type: GET_TODOS_BY_ACCOUNT, payload: json });
  };
};

// Создание задачи
export const createTodo = (data) => {
  return async (dispatch) => {
    await fetch(CREATE_TODO_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    })
      .then((responce) => responce.json())
      .then((json) =>
        dispatch({
          type: CREATE_TODO,
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

// Обновление задачи
export const updateTodo = (data) => {
  return async (dispatch) => {
    await fetch(UPDATE_TODO_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    })
      .then((responce) => responce.json())
      .then((json) =>
        dispatch({
          type: UPDATE_TODO,
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
export const deleteTodo = (id) => {
  return async (dispatch) => {
    await fetch(DELETE_TODO_API + id, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
    })
      .then((responce) =>
        dispatch({
          type: DELETE_TODO,
          payload: id,
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
