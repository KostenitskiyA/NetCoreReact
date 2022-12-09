import React, { useState } from "react";

const TodoForm = () => {
  const [todoForm, setTodoForm] = useState({
    title: "",
    description: "",
    statusId: 0,
  });

  const onChangeTitle = (event) => {
    event.preventDefault();
    this.setState({ title: event.target.value });
  };

  onChangeDescription = (event) => {
    e.preventDefault();
    this.setState({ description: e.target.value });
  };

  onChangeStatus = (event) => {
    e.preventDefault();
    this.setState({ statusId: parseInt(e.target.value) });
  };

  onSubmit = (event) => {
    e.preventDefault();
    this.setState({ creatorId: this.props.user.id });
    this.props.createTodo(this.state);
  };

  return (
    <form className="todo-form" onSubmit={(e) => this.onSubmit(e)}>
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
              rows="15"
              value={this.state.description}
              onChange={this.onChangeDescription}
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

export default TodoForm;