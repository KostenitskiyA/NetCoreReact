import React from "react";
import { useLocation, Navigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

const RequireAuth = ({ children }) => {
  const location = useLocation();
  const { user } = useAuth();

  if (user) {
    return children;
  } else {
    return <Navigate to="/login" state={{ from: location }} />;
  }
};

export default RequireAuth;
