import React from "react";
import { Navigate, Link } from "react-router-dom";
import { connect } from "react-redux";
import { logout } from "../stores/user/actions";
import "../styles/navigation";

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
    const { id, name, avatar, isLogin } = this.props.user;

    const avatarImg = avatar ? (
      <img src={avatar} />
    ) : (
      <i className="bi bi-person-fill"></i>
    );

    var items;

    isLogin
      ? (items = (
          <React.Fragment>
            <li className="item">
              <a className="link" onClick={this.onLogout}>
                Logout
              </a>
            </li>
            <li className="item">
              <Link className="link" to={"/profile/" + id}>
                {name}
                <div className="avatar-img">{avatarImg}</div>
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
    user: state.user
  };
};

const mapDispatchToProps = {
  logout,
};

export default connect(mapStateToProps, mapDispatchToProps)(Navigation);
