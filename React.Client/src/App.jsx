import React from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { connect } from "react-redux";

import { autoLogin } from "./stores/user/actions";

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
import Members from "./components/Members";

import NotificationContainer from "./components/NotificationContainer";

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  tokenCheck() {
    if (localStorage.getItem("token") && !this.props.isLogin) {
      this.props.autoLogin();
    } else {
      return <Navigate to="/login" />;
    }
  }  

  render() {
    this.tokenCheck();

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
              <Route path="members" element={<Members />} />
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
  return {
    isLogin: state.user.isLogin,
  };
};

const mapDispatchToProps = {
  autoLogin,
};

export default connect(mapStateToProps, mapDispatchToProps)(App);
