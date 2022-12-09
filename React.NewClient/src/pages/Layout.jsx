import React from "react";
import { Outlet } from "react-router-dom";

import Navigation from "../components/Navigation";

const Layout = () => {
  return (
    <>
      <Navigation />

      <div className="main">
        <Outlet />
      </div>
    </>
  );
}

export default Layout;