import {
  SIGNIN_API,
  LOGIN_API,
  LOGOUT_API,
  UPDATE_ACCOUNT_AVATAR_API,
} from "../api.js";

import {
  LOGIN,
  LOGOUT,
  ADD_NOTIFICATION,
  UPDATE_ACCOUNT_AVATAR,
} from "../constants.js";

export const signin = (data) => {
  return async (dispatch) => {
    const responce = await fetch(SIGNIN_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });

    const json = await responce.json();
    dispatch({ type: LOGIN, payload: json });
  };
};

export const login = (data) => {
  return async (dispatch) => {
    const responce = await fetch(LOGIN_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      credentials: "include",
      body: JSON.stringify(data),
    });

    if (responce.ok) {
      const json = await responce.json();

      localStorage.setItem("token", json.token);

      dispatch({ type: LOGIN, payload: json });
      dispatch({
        type: ADD_NOTIFICATION,
        payload: { title: "Вход", description: "" },
      });
    } else {
      responce.json().then(error => console.log(error.errors));
      dispatch({
        type: ADD_NOTIFICATION,
        payload: { title: "Ошибка входа", description: responce.statusText },
      });
    }
  };
};

export const logout = () => {
  return async (dispatch) => {
    // const responce = await fetch(LOGOUT_API, {
    //   method: "POST",
    //   headers: { "Content-Type": "application/json" },
    // });

    sessionStorage.clear();

    dispatch({ type: LOGOUT, payload: null });
    // dispatch({
    //   type: ADD_NOTIFICATION,
    //   payload: { title: "Выход", description: "" },
    // });
  };
};

export const updateAvatar = (data) => {
  return async (dispatch) => {
    const responce = await fetch(UPDATE_ACCOUNT_AVATAR_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });

    if (responce.ok) {
      dispatch({ type: UPDATE_ACCOUNT_AVATAR, payload: data.avatar });
    }
  };
};
