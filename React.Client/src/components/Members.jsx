import React from "react";
import { connect } from "react-redux";
import { Navigate } from "react-router-dom";
import GroupMemberTable from "../components/GroupMemberTable";
import "../styles/member";
import "bootstrap-icons/font/bootstrap-icons";

class Members extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { isLogin } = this.props.user;

    if (!isLogin) return <Navigate to="/login" />;

    return (
      <div className="wrapper">
        <GroupMemberTable />
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    user: state.user,
  };
};

const mapDispatchToProps = {
};

export default connect(mapStateToProps, mapDispatchToProps)(Members);
