import React from "react";
import { connect } from "react-redux";
import { Navigate } from "react-router-dom";

import { signin } from "../stores/user/actions";

import "../styles/loginForm";

class SignIn extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      name: "",
      login: "",
      password: "",
    };

    this.onChangeName = this.onChangeName.bind(this);
    this.onChangeLogin = this.onChangeLogin.bind(this);
    this.onChangePassword = this.onChangePassword.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
  }

  onChangeName(event) {
    this.setState({ name: event.target.value });
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
      name: this.state.name,
      login: this.state.login,
      password: this.state.password,
    };

    this.props.signin(data);
  }

  render() {
    const { isLogin } = this.props;

    if (isLogin) return <Navigate to="/" />;

    return (
      <form className="signin-form" onSubmit={(e) => this.onSubmit(e)}>
        <div className="title">Sign In</div>
        <div className="inputs">
          <div className="input">
            <label>Name</label>
            <input
              type="text"
              value={this.state.name}
              onChange={(event) => {
                this.onChangeName(event);
              }}
            />
          </div>
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
          <button type="submit">Signin</button>
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
  signin,
};

export default connect(mapStateToProps, mapDispatchToProps)(SignIn);
