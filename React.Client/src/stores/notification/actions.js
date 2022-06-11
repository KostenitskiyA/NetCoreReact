import {
  ADD_NOTIFICATION,
  DELETE_NOTIFICATION,
  DELETE_ALL_NOTIFICATIONS,
} from "../constants.js";

export const addNotification = (state) => {
  return {
    type: ADD_NOTIFICATION,
    payload: state,
  };
};

export const deleteNotification = (state) => {
  return {
    type: DELETE_NOTIFICATION,
    payload: state,
  };
};

export const deleteAllNotification = (state) => {
  return {
    type: DELETE_ALL_NOTIFICATIONS,
    payload: state,
  };
};
