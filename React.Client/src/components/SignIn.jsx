import React from "react";
import { connect } from "react-redux";
import { Navigate } from "react-router-dom";
import { signin } from "../stores/user/actions";

import "../styles/forms";

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

  onSubmit() {
    const data = {
      name: "",
      login: this.state.login,
      password: this.state.password,
    };

    this.props.signin(data);
  }

  render() {
    const { isLogin } = this.props;

    if (isLogin) 
      return <Navigate to="/" />;

    return (
      <div className="signin-form">
        <label>Имя пользователя</label>
        <input
          type="text"
          value={this.state.name}
          onChange={(event) => {
            this.onChangeName(event);
          }}
        />

        <label>Логин</label>
        <input
          type="text"
          value={this.state.login}
          onChange={(event) => {
            this.onChangeLogin(event);
          }}
        />

        <label>Пароль</label>
        <input
          type="password"
          value={this.state.password}
          onChange={(event) => {
            this.onChangePassword(event);
          }}
        />

        <button onClick={this.onSubmit}>Регистрация</button>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    userId: state.user.userId,
    userName: state.user.userName,
    isLogin: state.user.isLogin,
  };
};

const mapDispatchToProps = () => {
  return {
    signin,
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(SignIn);
