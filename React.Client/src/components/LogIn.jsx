import React from "react";
import { connect } from "react-redux";
import { Navigate } from "react-router-dom";

import { login } from "../stores/user/actions";

import "../styles/loginForm";

class LogIn extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      login: "",
      password: "",
    };

    this.onChangeLogin = this.onChangeLogin.bind(this);
    this.onChangePassword = this.onChangePassword.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
  }

  onChangeLogin(event) {
    this.setState({ login: event.target.value });
  }

  onChangePassword(event) {
    this.setState({ password: event.target.value });
  }

  onSubmit(e) {
    e.preventDefault();

    const data = {
      login: this.state.login,
      password: this.state.password,
    };

    this.props.login(data);
  }

  render() {
    const { isLogin } = this.props.user;

    if (isLogin) return <Navigate to="/" />;

    return (
      <form className="login-form" onSubmit={(e) => this.onSubmit(e)}>
        <div className="title">Login</div>
        <div className="inputs">
          <div className="input">
            <label>Username</label>
            <input
              type="text"
              value={this.state.login}
              onChange={(event) => {
                this.onChangeLogin(event);
              }}
            />
          </div>
          <div className="input">
            <label>Password</label>
            <input
              type="password"
              value={this.state.password}
              onChange={(event) => {
                this.onChangePassword(event);
              }}
            />
          </div>
        </div>
        <div className="button">
          <button type="submit">Login</button>
        </div>
      </form>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    user: state.user,
  };
};

const mapDispatchToProps = {
  login,
};

export default connect(mapStateToProps, mapDispatchToProps)(LogIn);
