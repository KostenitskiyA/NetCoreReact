import React from "react";
import { connect } from "react-redux";
import { login, logout } from "../stores/user/actions";
import "../styles/forms";

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

  onSubmit() {
    const data = {
      id: 0,
      name: "",
      authentication: {
        id: 0,
        login: this.state.login,
        password: this.state.password,
        userId: 0,
        user: null,
      },
    };

    this.props.login(data);
  }

  render() {
    return (
      <form className="login-form" onSubmit={this.onSubmit}>
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
        <button type="submit">Вход</button>
      </form>
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

const mapDispatchToProps = {
  login,
  logout,
};

export default connect(mapStateToProps, mapDispatchToProps)(LogIn);
