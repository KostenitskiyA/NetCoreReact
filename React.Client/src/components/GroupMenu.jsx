import React from "react";
import { Link, Navigate } from "react-router-dom";
import { connect } from "react-redux";
import "../styles/groupMenu";
import "bootstrap-icons/font/bootstrap-icons";

class GroupMenu extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    //const user = this.props.user;
    //const group = this.props.group;

    return (
      <div className="menu col">
        <ul>
          {/* <li>
            <span>{group.name}</span>
          </li> */}
          <li>
            <Link to="board">
              <i className="bi bi-kanban" />
              <span>Board</span>
            </Link>
          </li>
          <li>
            <Link to="todotable">
              <i className="bi bi-table" />
              <span>Table</span>
            </Link>
          </li>
          <li>
            <Link to="createTodo">
              <i className="bi bi-clipboard-plus" />
              <span>Create todo</span>
            </Link>
          </li>
          <li>
            <Link to="createTodo">
              <i className="bi bi-pie-chart-fill" />
              <span>Statistics</span>
            </Link>
          </li>
          <li>
            <Link to="createTodo">
              <i className="bi bi-people-fill" />
              <span>Users</span>
            </Link>
          </li>
          <li>
            <Link to="createTodo">
              <i className="bi bi-trash3" />
              <span>Delete group</span>
            </Link>
          </li>
        </ul>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    user: state.user,
    group: state.group.currentGroup,
  };
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(GroupMenu);
