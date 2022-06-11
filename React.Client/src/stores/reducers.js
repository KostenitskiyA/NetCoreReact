import { combineReducers } from "redux";

import { userReducer } from "./user/reducer.js";
import { statusReducer } from "./status/reducer.js";
import { todoReducer } from "./todo/reducer.js";
import { notificationReducer } from "./notification/reducer.js";

export default combineReducers({
  user: userReducer,
  status: statusReducer,
  todo: todoReducer,
  notification: notificationReducer,
});
