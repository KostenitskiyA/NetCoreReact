import React from "react";

import { Navigate } from "react-router-dom";

import { connect } from "react-redux";
import { createGroup } from "../stores/group/actions";

import "../styles/groupForm";

class GroupForm extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isAdmin: true,
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
    const { user } = this.props;

    //if (!user.isLogin) return <Navigate to="/login" />;

    return (
      <form className="group-form" onSubmit={(e) => this.onSubmit(e)}>
        <div className="inputs">
          <div className="row">
            <div className="input">
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
          <div className="row">
            <div className="input">
              <label className="label">Код</label>
              <input
                className="input-text"
                type="text"
                required
                value={this.state.code}
                onChange={this.onChangeCode}
              />
            </div>
          </div>
        </div>
        <div className="buttons row">
          <button type="submit">Сохранить</button>
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
