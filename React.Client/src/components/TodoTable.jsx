import React from "react";
import { Link } from "react-router-dom";
import Loading from "./Loading";
import { connect } from "react-redux";
import { getStatuses } from "../stores/status/actions";
import { getAllTodos } from "../stores/todo/actions";

import "../styles/index";
import "bootstrap-icons/font/bootstrap-icons";
import "../styles/table";

class TodoTable extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: false,
      searchName: null,
    };

    this.onChangeSearch = this.onChangeSearch.bind(this);
  }

  componentDidMount() {
    this.props.getStatuses();
    this.props.getAllTodos();
    this.setState({ isLoaded: true });
  }

  onChangeSearch(e) {
    this.setState({ searchName: e.target.value });
  }

  render() {
    const { isLoaded, searchName } = this.state;
    const { statuses, todos } = this.props;

    let filteredTodos = [];

    if (searchName) {
      filteredTodos = todos.filter((todo) =>
        todo.title.includes(searchName)
      );
    } else {
      filteredTodos = todos;
    }

    if (isLoaded && statuses && todos) {
      return (
        <div className="container">
          <div className="container col">
            <div className="container row">
              <div className="container col w-70">
                <input
                  className="input-text"
                  type="search"
                  onChange={this.onChangeSearch}
                />
              </div>
              <div className="container col w-15">
                <input className="input-date" type="date" />
              </div>
              <div className="container col w-15">
                <input className="input-date" type="date" />
              </div>
            </div>
            <div className="container col">
              <table className="table">
                <thead className="table-thead">
                  <tr className="table-thead-tr">
                    <th className="table-thead-tr-th">Название</th>
                    <th className="table-thead-tr-th">Описание</th>
                    <th className="table-thead-tr-th">Статус</th>
                    <th className="table-thead-tr-th">Дата создания</th>
                    <th className="table-tbody-tr-th"></th>
                  </tr>
                </thead>
                <tbody className="table-tbody">
                  {filteredTodos.map((todo, key) => (
                    <tr className="table-tbody-tr" key={key}>
                      <td className="table-tbody-tr-td">{todo.title}</td>
                      <td className="table-tbody-tr-td">{todo.description}</td>
                      <td className="table-tbody-tr-td">
                        {
                          statuses.find((status) => status.id == todo.statusId)
                            .name
                        }
                      </td>
                      <td className="table-tbody-tr-td">{todo.createDate}</td>
                      <td className="table-tbody-tr-td">
                        <Link to={"/todotable/" + todo.id}>
                          <button>
                            <i className="bi bi-search" />
                          </button>
                        </Link>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      );
    } else {
      return <Loading />;
    }
  }
}

const mapStateToProps = (state) => {
  return {
    statuses: state.status.statuses,
    todos: state.todo.todos,
  };
};

const mapDispatchToProps = {
  getStatuses,
  getAllTodos,
};

export default connect(mapStateToProps, mapDispatchToProps)(TodoTable);
