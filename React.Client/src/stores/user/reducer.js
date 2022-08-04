import { LOGIN, LOGOUT, UPDATE_ACCOUNT_AVATAR } from "../constants.js";

const initialState = {
  id: 0,
  name: "",
  avatar: "",
  isLogin: false,
};

export const userReducer = (state = initialState, action) => {
  switch (action.type) {
    case LOGIN:
      return {
        ...state,
        id: action.payload.id,
        name: action.payload.name,
        avatar: action.payload.avatar,
        isLogin: true,
      };
    case LOGOUT:
      return initialState;
    case UPDATE_ACCOUNT_AVATAR:
      return {
        ...state,
        avatar: action.payload,
      };
  }

  return state;
};
