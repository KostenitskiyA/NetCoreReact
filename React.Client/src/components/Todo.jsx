import React from "react";
import { connect } from "react-redux";
import { getStatuses } from "../stores/todo/actions";
import "../styles/style";
import "../styles/modal";

class Todo extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.getStatuses();
  }

  render() {
    const { todo, statuses } = this.props;

    return (
      <div className="todo row">
        <div className="description col w-60">
          <div className="input">
            <label className="label">Описание</label>
            <textarea
              className="input-textarea"
              type="textarea"
              rows="10"
              value={todo.description}
            />
          </div>
        </div>
        <div className="details col w-40">
          <div className="input">
            <label className="label">Статус</label>
            <select
              className="input-select"
              required
              value={todo.statusId}
              onChange={this.onChangeStatus}
            >
              {statuses.map((status, key) => (
                <option key={key} value={status.id}>
                  {status.name}<i className="bi bi-person-fill"></i>
                </option>
              ))}
            </select>
          </div>
          <div className="input">
            <label className="label">Автор</label>
            {/* <input
              className="input-text"
              type="text"
              readOnly="true"
              value={this.props.statuses.filter((s) => s.Id == todo.statusId)}
            /> */}
          </div>
          <div className="input">
            <label className="label">Дата создания</label>
            <input
              className="input-date"
              type="date"
              readOnly="true"
              value={todo.createDate}
            />
          </div>
          <div className="input">
            <label className="label">Дата изменения</label>
            <input
              className="input-date"
              type="date"
              readOnly="true"
              value={todo.changeDate}
            />
          </div>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    statuses: state.todo.statuses,
  };
};

const mapDispatchToProps = {
  getStatuses,
};

export default connect(mapStateToProps, mapDispatchToProps)(Todo);
