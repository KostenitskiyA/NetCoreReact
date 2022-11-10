import React from "react";
import { Navigate } from "react-router-dom";
import { connect } from "react-redux";
import { getStatuses, getTodosByAccount } from "../stores/todo/actions";
import TodoTableRow from "./TodoTableRow";

import "bootstrap-icons/font/bootstrap-icons";
import "../styles/todoTable";

class TodoTable extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: false,
      searchName: null,
      fromDate: null,
      toDate: null
    };

    this.onChangeSearch = this.onChangeSearch.bind(this);
    this.onChangeFromDate = this.onChangeFromDate.bind(this);
    this.onChangeToDate = this.onChangeToDate.bind(this);
  }

  componentDidMount() {
    this.props.getTodosByAccount(this.props.userId);
    this.props.getStatuses();
    this.setState({ isLoaded: true });
  }

  onChangeSearch(e) {
    this.setState({ ...this.state, searchName: e.target.value });
  }

  onChangeFromDate(e) {
    this.setState({ ...this.state, fromDate: e.target.value });
  }

  onChangeToDate(e) {
    this.setState({ ...this.state, toDate: e.target.value });
  }

  render() {
    const { isLoaded, searchName, fromDate, toDate} = this.state;
    const { isLogin, statuses, todos } = this.props;

    if (isLogin) return <Navigate to="/login" />;

    let filteredTodos = todos;

    if (todos) {
      filteredTodos = todos
      .filter((todo) => todo.title.includes(searchName))
      .filter((todo) => todo.createDate > fromDate)
      .filter((todo) => todo.createDate < toDate);

      // if (searchName) {
      //   filteredTodos = todos.filter((todo) => todo.title.includes(searchName));
      // } else if (!fromDate && !toDate) {
      //   filteredTodos = todos;
      // }

      // if (fromDate && toDate) {
      //   filteredTodos = todos.filter((todo) => todo.createDate > fromDate && todo.createDate < toDate);
      // } else if (fromDate) {
      //   filteredTodos = todos.filter((todo) => todo.createDate > fromDate);
      // } else if (toDate) {
      //   filteredTodos = todos.filter((todo) => todo.createDate < toDate);
      // } else if (!searchName) {
      //   filteredTodos = todos;
      // }
    }

    if (isLoaded && statuses && todos) {
      return (
        <div className="todo-table">
          <div className="filters row">
            <div className="input search">
              <label>Search</label>
              <input type="search" value={searchName} onChange={this.onChangeSearch} />
            </div>
            <div className="input date">
              <label>From</label>
              <input type="date" value={fromDate} onChange={this.onChangeFromDate} />
            </div>
            <div className="input date">
              <label>To</label>
              <input type="date" value={toDate} onChange={this.onChangeToDate} />
            </div>
          </div>
          <div className="table">
            <table className="table">
              <thead className="thead">
                <tr className="tr">
                  <th className="th">Название</th>
                  <th className="th">Статус</th>
                  <th className="th">Дата создания</th>
                </tr>
              </thead>
              <tbody className="tbody">
                {filteredTodos.map((todo, key) => (
                  <TodoTableRow todo={todo} key={key}/>                
                ))}
              </tbody>
            </table>
          </div>
        </div>
      );
    } else {
      return <div>Loading...</div>;
    }
  }
}

const mapStateToProps = (state) => {
  return {
    user: state.user.isLogin,
    userId: state.user.id,
    statuses: state.todo.statuses,
    todos: state.todo.todos,
  };
};

const mapDispatchToProps = {
  getTodosByAccount,
  getStatuses,
};

export default connect(mapStateToProps, mapDispatchToProps)(TodoTable);
