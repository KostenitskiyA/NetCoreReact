import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { configureStore } from "@reduxjs/toolkit";
import { Provider } from "react-redux";
import reducers from "./stores/reducers.js";
import thunk from "redux-thunk";

import Navigation from "./components/Navigation";
import Home from "./components/Home";
import TodoTable from "./components/TodoTable";
import { Todo } from "./components/Todo";
import Board from "./components/Board";
import TodoForm from "./components/TodoForm";
import SignIn from "../src/components/SignIn";
import LogIn from "./components/LogIn";
import NotificationContainer from "./components/NotificationContainer";

import "./styles/index.scss";
import "./styles/navigation.scss";

const store = configureStore({ reducer: reducers, middleware: [thunk] });

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Provider store={store}>
        <BrowserRouter>
          <Navigation />

          <div className="main">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/login" element={<LogIn />} />
              <Route path="/signin" element={<SignIn />} />
              <Route path="/todotable" element={<TodoTable />} />
              <Route path="/todotable/:id" element={<Todo />} />
              <Route path="/board" element={<Board />} />
              <Route path="/createTodo" element={<TodoForm />} />
            </Routes>
          </div>

          <NotificationContainer />
        </BrowserRouter>
      </Provider>
    );
  }
}

export default App;
