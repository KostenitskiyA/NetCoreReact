import React from "react";

import { Navigate } from "react-router-dom";

import { connect } from "react-redux";
import { getStatuses } from "../stores/todo/actions";
import { createTodo } from "../stores/todo/actions";

import "../styles/todoForm";

class TodoForm extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      title: "",
      description: "",
      statusId: 0,
      creatorId: 0,
      executorId: 0,
    };

    this.onChangeTitle = this.onChangeTitle.bind(this);
    this.onChangeDescription = this.onChangeDescription.bind(this);
    this.onChangeStatus = this.onChangeStatus.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
  }

  componentDidMount() {
    this.props.getStatuses();
  }

  onChangeTitle(e) {
    e.preventDefault();
    this.setState({ title: e.target.value });
  }

  onChangeDescription(e) {
    e.preventDefault();
    this.setState({ description: e.target.value });
  }

  onChangeStatus(e) {
    e.preventDefault();
    this.setState({ statusId: parseInt(e.target.value) });
    console.log(this.state);
  }

  onSubmit(e) {
    e.preventDefault();
    this.setState({ creatorId: this.props.user.id });
    this.props.createTodo(this.state);
  }

  render() {
    const { user, statuses } = this.props;

    //if (!user.isLogin) return <Navigate to="/login" />;

    return (
      <form className="form" onSubmit={(e) => this.onSubmit(e)}>
        <div className="inputs">
        <div className="row">
          <div className="input liquid">
            <label className="label">Заголовок</label>
            <input
              className="input-text"
              type="text"
              required
              value={this.state.title}
              onChange={this.onChangeTitle}
            />
          </div>
          <div className="input">
            <label className="label">Статус</label>
            <select
              className="input-select"
              required
              value={this.state.status}
              onChange={this.onChangeStatus}
            >
              {statuses.map((status, key) => (
                <option key={key} value={status.id}>
                  {status.name}
                </option>
              ))}
            </select>
          </div>
        </div>
        <div className="row">
          <div className="input w-100">
            <label className="label">Описание</label>
            <textarea
              className="input-textarea"
              type="textarea"
              rows="10"
              value={this.state.description}
              onChange={this.onChangeDescription}
            />
          </div>
        </div>
        </div>        
        <div className="buttons row">
          <button type="submit">
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
    statuses: state.todo.statuses,
  };
};

const mapDispatchToProps = {
  getStatuses,
  createTodo,
};

export default connect(mapStateToProps, mapDispatchToProps)(TodoForm);
