import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

import "../styles/loginForm";

const SignIn = () =>{
  const navigate = useNavigate();
  const { signIn } = useAuth();

  const [userForm, setUserForm] = useState({
    name: "",
    login: "",
    password: "",
  });

  const onChangeName = (event) => {
    setUserForm({ ...userForm, name: event.target.value });
  };
  const onChangeLogin = (event) => {
    setUserForm({ ...userForm, login: event.target.value });
  };
  const onChangePassword = (event) => {
    setUserForm({ ...userForm, password: event.target.value });
  };
  const onSubmit = (event) => {
    event.preventDefault();
    signIn(userForm, () => navigate("/"));
  };

  return (
    <form onSubmit={(event) => onSubmit(event)}>
      <div>Sign In</div>
      <div>
        <div>
          <label>Name</label>
          <input
            type="text"
            value={userForm.name}
            onChange={(event) => onChangeName(event)}
          />
        </div>
        <div>
          <label>Login</label>
          <input
            type="text"
            value={userForm.username}
            onChange={(event) => onChangeLogin(event)}
          />
        </div>
        <div>
          <label>Password</label>
          <input
            type="password"
            value={userForm.password}
            onChange={(event) => onChangePassword(event)}
          />
        </div>
      </div>
      <div>
        <button type="submit">Signin</button>
      </div>
    </form>
  );
}

export default SignIn;