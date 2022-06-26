import {
  GET_GROUP_API,
  GET_GROUPS_BY_ACCOUNT_API,
  CREATE_GROUP_API,
  UPDATE_GROUP_API,
  DELETE_GROUP_API,
} from "../api.js";

import {
  GET_GROUP,
  GET_GROUPS_BY_ACCOUNT,
  CREATE_GROUP,
  UPDATE_GROUP,
  DELETE_GROUP,
} from "../constants.js";

// Получение группы
export const getGroup = (data) => {
  return async (dispatch) => {
    const responce = await fetch(GET_GROUP_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });

    const json = await responce.json();
    dispatch({ type: GET_GROUP, payload: json });
  };
};

// Получение групп аккаунта
export const getGroupsByAccount = (data) => {
  return async (dispatch) => {
    const responce = await fetch(GET_GROUPS_BY_ACCOUNT_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });

    const json = await responce.json();
    dispatch({ type: GET_GROUPS_BY_ACCOUNT, payload: json });
  };
};

// Создание группы
export const createGroup = (data) => {
  return async (dispatch) => {
    const responce = await fetch(CREATE_GROUP_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });

    const json = await responce.json();
    dispatch({ type: CREATE_GROUP, payload: json });
  };
};

// Обновление группы
export const updateGroup = (data) => {
  return async (dispatch) => {
    const responce = await fetch(UPDATE_GROUP_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });

    const json = await responce.json();
    dispatch({ type: UPDATE_GROUP, payload: json });
  };
};

// Удаление группы
export const deleteGroup = (data) => {
  return async (dispatch) => {
    const responce = await fetch(DELETE_GROUP_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });

    const json = await responce.json();
    dispatch({ type: DELETE_GROUP, payload: json });
  };
};
