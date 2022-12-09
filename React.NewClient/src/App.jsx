import React from "react";
import { Provider } from "react-redux";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider,
} from "react-router-dom";

import { store } from "./store";

import { AuthProvider } from "./hocs/AuthProvider";
import RequireAuth from "./hocs/RequireAuth";

import Layout from "./pages/Layout";
import Home from "./pages/Home";
import LogIn from "./pages/LogIn";
import SignIn from "./pages/SignIn";
import Profile from "./pages/Profile";
import Group from "./pages/Group";
import GroupForm from "./pages/GroupForm";
import Board from "./pages/Board";
import TodoTable from "./pages/TodoTable";
import TodoForm from "./pages/TodoForm";
import Members from "./pages/Members";

import "./styles/style";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Layout />}>
      <Route path="login" element={<LogIn />} />
      <Route path="signin" element={<SignIn />} />

      <Route
        path="home"
        element={
          <RequireAuth>
            <Home />
          </RequireAuth>
        }
      />
      <Route
        path="profile/:id"
        element={
          <RequireAuth>
            <Profile />
          </RequireAuth>
        }
      />
      <Route
        path="createGroup"
        element={
          <RequireAuth>
            <GroupForm />
          </RequireAuth>
        }
      />
      <Route
        path="group/:groupId"
        element={
          <RequireAuth>
            <Group />
          </RequireAuth>
        }
      >
        <Route
          path="board"
          element={
            <RequireAuth>
              <Board />
            </RequireAuth>
          }
        />
        <Route
          path="todotable"
          element={
            <RequireAuth>
              <TodoTable />
            </RequireAuth>
          }
        />
        <Route
          path="createTodo"
          element={
            <RequireAuth>
              <TodoForm />
            </RequireAuth>
          }
        />
        <Route
          path="members"
          element={
            <RequireAuth>
              <Members />
            </RequireAuth>
          }
        />
      </Route>
    </Route>
  )
);

export default function App() {
  return (
    <Provider store={store}>
      <AuthProvider>
        <RouterProvider router={router} />
      </AuthProvider>
    </Provider>
  );
}
