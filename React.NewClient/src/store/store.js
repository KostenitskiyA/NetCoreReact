import { configureStore } from "@reduxjs/toolkit";
import { groupApi } from "./api/groupApi";
import { userApi } from "./api/userApi";
import { accountApi } from "./api/accountApi";
import { todoApi } from "./api/todoApi";

export const store = configureStore({
  reducer: {
    [groupApi.reducerPath]: groupApi.reducer,
    [userApi.reducerPath]: userApi.reducer,
    [accountApi.reducerPath]: accountApi.reducer,
    [todoApi.reducerPath]: todoApi.reducer,
  },
  middleware: (getDefaultMiddlware) =>
    getDefaultMiddlware()
      .concat(groupApi.middleware)
      .concat(userApi.middleware)
      .concat(accountApi.middleware)
      .concat(todoApi.middleware),
});
