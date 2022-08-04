import React from "react";
import { connect } from "react-redux";
import { getStatuses, getTodosByGroup } from "../stores/todo/actions";
import "../styles/groupMenu";
import "bootstrap-icons/font/bootstrap-icons";
import { Link, Navigate } from "react-router-dom";

class GroupMenu extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {}

  render() {
    const currentGroupId = this.props.currentGroupId;
    const { id, name, isLogin } = this.props.user;

    if (!isLogin) return <Navigate to="/login" />;

    const sidebar =
      currentGroupId != 0 ? (
        <div className="menu col">
          <Link to="/board">Todo Board</Link>
          <Link to="/todotable">Todo Table</Link>
          <Link to="/createTodo">Create Todo</Link>
        </div>
      ) : null;

    return sidebar;
  }
}

const mapStateToProps = (state) => {
  return {
    user: {
      id: state.user.id,
      name: state.user.name,
      isLogin: state.user.isLogin,
    },
    currentGroupId: state.group.currentGroupId,
  };
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(GroupMenu);
