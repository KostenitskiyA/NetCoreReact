import {
  ADD_NOTIFICATION,
  DELETE_NOTIFICATION,
  DELETE_ALL_NOTIFICATIONS,
} from "../constants.js";

const initialState = { notifications: [] };

export const notificationReducer = (state = initialState, action) => {
  switch (action.type) {
    case ADD_NOTIFICATION: {
      const newNotifications = [...state.notifications];
      newNotifications.push(action.payload);
      return { ...state, notifications: newNotifications };
    }
    case DELETE_NOTIFICATION: {
      const index = state.notifications.findIndex(
        (notification) => notification.id == action.payload.id
      );
      const newNotifications = [...state.notifications];
      newNotifications.slice(index, 1);
      return { ...state, notifications: newNotifications };
    }
    case DELETE_ALL_NOTIFICATIONS: {
      return { ...state, notifications: [] };
    }
  }

  return state;
};
