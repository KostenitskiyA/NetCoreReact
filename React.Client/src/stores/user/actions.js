import { 
	SIGNIN_API, 
	LOGIN_API, 
	LOGOUT_API 
} from "../api.js";

import { 
	LOGIN, 
	LOGOUT, 
	ADD_NOTIFICATION 
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
      body: JSON.stringify(data),
    });

    if (responce.ok) {
      const json = await responce.json();

      dispatch({ type: LOGIN, payload: json });
      dispatch({
        type: ADD_NOTIFICATION,
        payload: { title: "Вход", description: "Чего вы пришли нахуй" },
      });
    } else {
      dispatch({
        type: ADD_NOTIFICATION,
        payload: { title: "Ошибка входа", description: responce.statusText },
      });
    }
  };
};

export const logout = () => {
  return async (dispatch) => {
    const responce = await fetch(LOGOUT_API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
    });

    dispatch({ type: LOGOUT, payload: json });
    // dispatch({
    //   type: ADD_NOTIFICATION,
    //   payload: { title: "Выход", description: "Идите нахуй" },
    // });
  };
};
