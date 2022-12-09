import React, { useState } from "react";
import { useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

import "../styles/loginForm";

const LogIn = () => {
  const { logIn, authCheck } = useAuth();
  const navigate = useNavigate();
  const location = useLocation();
  const fromPage = location.state?.from?.pathname || "/home";

  const [userForm, setUserForm] = useState({ login: "", password: "" });
  const [errorForm, setErrorForm] = useState(null);

  useEffect(() => {
    if (localStorage.getItem("token"))
      authCheck(() => navigate(fromPage, { replace: true }));
  }, []);

  const onChangeLogin = (event) => {
    setUserForm({ ...userForm, login: event.target.value });
  };
  const onChangePassword = (event) => {
    setUserForm({ ...userForm, password: event.target.value });
  };
  const onSubmit = (event) => {
    event.preventDefault();
    logIn(userForm, () => navigate(fromPage, { replace: true })).catch(
      (error) => setErrorForm(error)
    );
  };

  return (
    <form onSubmit={(event) => onSubmit(event)}>
      <div>Login</div>
      <div>
        <div>
          <label>Username</label>
          <input
            type="text"
            value={userForm.login}
            onChange={(event) => onChangeLogin(event)}
          />
          {errorForm ? <label>{errorForm?.data?.errors?.Login}</label> : null}
        </div>
        <div>
          <label>Password</label>
          <input
            type="password"
            value={userForm.password}
            onChange={(event) => onChangePassword(event)}
          />
          {errorForm ? <label>{errorForm?.data?.errors?.Password}</label> : null}
        </div>
      </div>
      <div>
        <button type="submit">Login</button>
      </div>
    </form>
  );
};

export default LogIn;
