import React from "react";

import { Navigate } from "react-router-dom";

import { connect } from "react-redux";
import { createGroup } from "../stores/group/actions";
import "../styles/index";

class GroupForm extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      name: "",
      code: "",
    };

    this.onChangeName = this.onChangeName.bind(this);
    this.onChangeCode = this.onChangeCode.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
  }

  onChangeName(e) {
    e.preventDefault();
    this.setState({ name: e.target.value });
  }

  onChangeCode(e) {
    e.preventDefault();
    this.setState({ code: e.target.value });
  }

  onSubmit(e) {
    e.preventDefault();
    this.props.createGroup(this.state);
  }

  render() {
    const { user, statuses } = this.props;

    //if (!user.isLogin) return <Navigate to="/login" />;

    return (
      <form className="form" onSubmit={(e) => this.onSubmit(e)}>
        <div className="container row">
          <div className="container col w-75">
            <label className="label">Название</label>
            <input
              className="input-text"
              type="text"
              required
              value={this.state.name}
              onChange={this.onChangeName}
            />
          </div>
        </div>
        <div className="container row">
          <div className="container col w-100">
            <label className="label">Код</label>
            <input
              className="input-text"
              type="text"
              required
              value={this.state.сщву}
              onChange={this.onChangeCode}
            />
          </div>
        </div>
        <div className="container">
          <button className="input-button" type="submit">
            Сохранить
          </button>
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
  createGroup,
};

export default connect(mapStateToProps, mapDispatchToProps)(GroupForm);
