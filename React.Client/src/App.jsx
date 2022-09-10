import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { connect } from "react-redux";

import Navigation from "./components/Navigation";
import Home from "./components/Home";

import SignIn from "../src/components/SignIn";
import LogIn from "./components/LogIn";
import Profile from "./components/Profile";

import GroupForm from "./components/GroupForm";

import Group from "./components/Group";
import Board from "./components/Board";
import TodoTable from "./components/TodoTable";
import TodoForm from "./components/TodoForm";

import NotificationContainer from "./components/NotificationContainer";

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <BrowserRouter>
        <Navigation />

        <div className="main">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/login" element={<LogIn />} />
            <Route path="/signin" element={<SignIn />} />
            <Route path="/profile/:id" element={<Profile />} />

            <Route path="/group/:id" element={<Group />}>
              <Route path="board" element={<Board />} />
              <Route path="todotable" element={<TodoTable />} />
              <Route path="createTodo" element={<TodoForm />} />
            </Route>

            <Route path="/createGroup" element={<GroupForm />} />
          </Routes>
        </div>

        {/* <NotificationContainer /> */}
      </BrowserRouter>
    );
  }
}

const mapStateToProps = (state) => {
  return {};
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(App);
