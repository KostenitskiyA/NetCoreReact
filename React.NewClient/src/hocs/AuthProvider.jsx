import React, { createContext, useState } from "react";
import { useLoginMutation, useAutoLoginMutation } from "../store";

export const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [autoLogin] = useAutoLoginMutation();
  const [login] = useLoginMutation();

  const authCheck = async (callback) => {
    try {
      const responce = await autoLogin().unwrap();
      setUser(responce);
      callback();
    } catch (error) {
      throw error;
    }
  };

  const logIn = async (user, callback) => {
    try {
      const responce = await login(user).unwrap();
      localStorage.setItem("token", responce.token);
      setUser(responce);
      callback();
    } catch (error) {
      throw error;
    }
  };

  const logOut = (callback) => {
    localStorage.removeItem("token");
    setUser(null);
    callback();
  };

  const value = { user, authCheck, logIn, logOut };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
