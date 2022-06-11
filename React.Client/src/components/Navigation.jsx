import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { login, logout } from "../stores/user/actions";
import "../styles/navigation";

class Navigation extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { id, name, isLogin } = this.props.user;

    let items;

    isLogin
      ? (items = (
          <React.Fragment>
            <li className="item">
              <Link className="link" to="/logout">
                Logout
              </Link>
            </li>
            <li className="item">
              <div className="link">{name}</div>
            </li>
          </React.Fragment>
        ))
      : (items = (
          <React.Fragment>
            <li className="item">
              <Link className="link" to="/signin">
                SignIn
              </Link>
            </li>
            <li className="item">
              <Link className="link" to="/login">
                Login
              </Link>
            </li>
          </React.Fragment>
        ));

    return (
      <nav className="nav">
        <ul className="list">
          <li className="item">
            <Link className="link" to="/todotable">
              Todo Table
            </Link>
          </li>
          <li className="item">
            <Link className="link" to="/board">
              Todo Board
            </Link>
          </li>
          <li className="item">
            <Link className="link" to="/createTodo">
              Crete Todo
            </Link>
          </li>
        </ul>
        <ul className="list">
          {items}
        </ul>
      </nav>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    user: {
      id: state.user.id,
      name: state.user.name,
      isLogin: state.user.isLogin,
    },
  };
};

const mapDispatchToProps = () => {
  return {
    login: login,
    logout: logout,
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Navigation);
