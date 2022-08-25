import React from "react";
import ReactDOM from "react-dom";
import { configureStore } from "@reduxjs/toolkit";
import { Provider } from "react-redux";
import reducers from "./stores/reducers.js";
import thunk from "redux-thunk";

import App from "./App.jsx";

const store = configureStore({ reducer: reducers, middleware: [thunk] });

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById("root")
);
