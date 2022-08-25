import React from "react";
import { connect } from "react-redux";
import { Outlet } from "react-router-dom";
import GroupMenu from "./GroupMenu";

import "../styles/group";
import "bootstrap-icons/font/bootstrap-icons";

class Group extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
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
}

const mapStateToProps = (state) => {
  return {};
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(Group);
