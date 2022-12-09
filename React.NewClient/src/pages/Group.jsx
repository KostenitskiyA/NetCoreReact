import React from "react";
import { Outlet } from "react-router-dom";
import GroupMenu from "../components/GroupMenu";

import "../styles/group"

const Group = () =>{
  return (
    <div className="group_wrapper">
      <div className="sidebar">
        <GroupMenu />
      </div>
      <div className="wrapper liquid">
        <Outlet />
      </div>
    </div>
  );
}

export default Group;
