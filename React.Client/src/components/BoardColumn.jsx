import React from "react";
import { connect } from "react-redux";
import { updateTodo } from "../stores/todo/actions";
import BoardCard from "../components/BoardCard";

import "../styles/boardColumn";
import "bootstrap-icons/font/bootstrap-icons";

class BoardColumn extends React.Component {
  constructor(props) {
    super(props);

    this.onDragEnter = this.onDragEnter.bind(this);
    this.onDragOver = this.onDragOver.bind(this);
    this.onDragLeave = this.onDragLeave.bind(this);
    this.onDrop = this.onDrop.bind(this);
  }

  onDragEnter(e) {
    e.preventDefault();
  }

  onDragOver(e) {
    e.preventDefault();
  }

  onDragLeave(e) {
    e.preventDefault();
  }

  onDrop(e) {
    const id = e.dataTransfer.getData("text");
    var editedTodo = this.props.todos.find((todo) => todo.id == id);
    editedTodo.statusId = this.props.status.id;
    editedTodo.status = null;
    this.props.updateTodo(editedTodo);
  }

  render() {
    const { status, todos } = this.props;

    return (
      <div className="column">
        <div className="title">{status.name}</div>
        <div
          className="container"
          onDragEnter={(e) => this.onDragEnter(e)}
          onDragOver={(e) => this.onDragOver(e)}
          onDragLeave={(e) => this.onDragLeave(e)}
          onDrop={(e) => this.onDrop(e)}
        >
          {todos
            .filter((todo) => todo.statusId == status.id)
            .map((todo, key) => {
              return <BoardCard key={key} todo={todo} />;
            })}
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    todos: state.todo.todos,
  };
};

const mapDispatchToProps = {
  updateTodo,
};

export default connect(mapStateToProps, mapDispatchToProps)(BoardColumn);
