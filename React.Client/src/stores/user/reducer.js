import { LOGIN, LOGOUT } from "../constants.js";

const initialState = {
  id: 0,
  name: "",
  isLogin: false,
};

export const userReducer = (state = initialState, action) => {
  switch (action.type) {
    case LOGIN:
      return {
        ...state,
        id: action.payload.id,
        name: action.payload.name,
        isLogin: true,
      };
    case LOGOUT:
      return {
        initialState,
      };
  }

  return state;
};
