import React from "react";
import { Link, Navigate } from "react-router-dom";
import { connect } from "react-redux";
import { getStatuses, getTodosByAccount } from "../stores/todo/actions";

import "bootstrap-icons/font/bootstrap-icons";
import "../styles/style";

class TodoTable extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: false,
      searchName: null,
    };

    this.onChangeSearch = this.onChangeSearch.bind(this);
    this.onTaskOpen = this.onTaskOpen.bind(this);
  }

  componentDidMount() {
    this.props.getTodosByAccount(this.props.userId);
    this.props.getStatuses();
    this.setState({ isLoaded: true });
  }

  onChangeSearch(e) {
    this.setState({ searchName: e.target.value });
  }

  onTaskOpen(id) {
    return <Navigate to={"/todotable/" + id} />;
  }

  render() {
    const { isLoaded, searchName } = this.state;
    const { isLogin, statuses, todos } = this.props;

    if (isLogin) return <Navigate to="/login" />;

    let filteredTodos = [];

    if (todos) {
      if (searchName) {
        filteredTodos = todos.filter((todo) => todo.title.includes(searchName));
      } else {
        filteredTodos = todos;
      }
    }

    if (isLoaded && statuses && todos) {
      return (
        <div className="todo-table">
          <div className="filters">
            <div className="input search">
              <label>Search</label>
              <input type="search" onChange={this.onChangeSearch} />
            </div>
            <div className="input date">
              <label>From</label>
              <input type="date" />
            </div>
            <div className="input date">
              <label>To</label>
              <input type="date" />
            </div>
          </div>
          <div className="table">
            <table className="table">
              <thead className="thead">
                <tr className="tr">
                  <th className="th">Название</th>
                  <th className="th">Описание</th>
                  <th className="th">Статус</th>
                  <th className="th">Дата создания</th>
                </tr>
              </thead>
              <tbody className="tbody">
                {filteredTodos.map((todo, key) => (
                  <tr
                    className="tr"
                    key={key}
                    onClick={() => this.onTaskOpen(todo.id)}
                  >
                    <td className="td">{todo.title}</td>
                    <td className="td">{todo.description}</td>
                    <td className="td">
                      {
                        statuses.find((status) => status.id == todo.statusId)
                          .name
                      }
                    </td>
                    <td className="td">{todo.createDate}</td>
                  </tr>
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
