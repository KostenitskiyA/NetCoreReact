import React from "react";
import { connect } from "react-redux";
import { getStatuses } from "../stores/status/actions";
import { addTodo } from "../stores/todo/actions";
import "../styles/index";

class TodoForm extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      id: 0,
      title: "",
      description: "",
      statusId: 0,
      status: null,
      createDate: new Date(),
      changeDate: new Date(),
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
    this.setState({ title: e.target.value });
  }

  onChangeDescription(e) {
    this.setState({ description: e.target.value });
  }

  onChangeStatus(e) {
    this.setState({ statusId: e.target.value });
  }

  onSubmit(e) {
    e.preventDefault();
    console.log(this.state);
    this.props.addTodo(this.state);
  }

  render() {
    const { statuses } = this.props;

    return (
      <form className="form" onSubmit={(e) => this.onSubmit(e)}>
        <div className="container row">
          <div className="container col w-75">
            <label className="label">Заголовок</label>
            <input
              className="input-text"
              type="text"
              required
              value={this.state.title}
              onChange={this.onChangeTitle}
            />
          </div>
          <div className="container col w-25">
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
        <div className="container row">
          <div className="container col w-100">
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
    statuses: state.status.statuses,
  };
};

const mapDispatchToProps = {
  getStatuses,
  addTodo,
};

export default connect(mapStateToProps, mapDispatchToProps)(TodoForm);