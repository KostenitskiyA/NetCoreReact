import { combineReducers } from "redux";

import { groupReducer } from "./group/reducer.js";
import { userReducer } from "./user/reducer.js";
import { todoReducer } from "./todo/reducer.js";
import { notificationReducer } from "./notification/reducer.js";

export default combineReducers({
  group: groupReducer,
  user: userReducer,
  todo: todoReducer,
  notification: notificationReducer,
});
