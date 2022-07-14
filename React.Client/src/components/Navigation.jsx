import React from "react";
import { Navigate, Link } from "react-router-dom";
import { connect } from "react-redux";
import { logout } from "../stores/user/actions";
import "../styles/style";

class Navigation extends React.Component {
  constructor(props) {
    super(props);

    this.onLogout = this.onLogout.bind(this);
  }

  onLogout() {
    this.props.logout();
    return <Navigate to="/" />;
  }

  render() {
    const { id, name, isLogin } = this.props.user;

    let items;

    isLogin
      ? (items = (
          <React.Fragment>
            <li className="item">
              <button className="link" onClick={this.onLogout}>
                Logout
              </button>
            </li>
            <li className="item">
              <Link className="link" to={"/profile/" + id}>
                {name}
              </Link>
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
            <Link className="link" to="/">
              Home
            </Link>
          </li>
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
              Create Todo
            </Link>
          </li>
          <li className="item">
            <Link className="link" to="/">
              Groups
            </Link>
          </li>
          <li className="item">
            <Link className="link" to="/createGroup">
              Create group
            </Link>
          </li>
        </ul>
        <ul className="list">{items}</ul>
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

const mapDispatchToProps = {
  logout,
};

export default connect(mapStateToProps, mapDispatchToProps)(Navigation);
