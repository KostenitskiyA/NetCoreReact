import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { editTodo } from "../stores/todo/actions";

import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";
import BoardCard from "../components/BoardCard";

export const BoardColumnHook = (props) => {
  const todos = useSelector((state) => state.todo.todos.filter((todo) => todo.statusId == props.status.id));
  const filteredTodos = todos
    .map((todo, key) => <BoardCard key={key} todo={todo} />);
  const dispatch = useDispatch();

  const onDragEnter = (e) => {
    e.preventDefault();
  };
  const onDragOver = (e) => {
    e.preventDefault();
  };
  const onDragLeave = (e) => {
    e.preventDefault();
  };
  const onDrop = (e) => {
    const id = e.dataTransfer.getData("text");
    console.log(id);
    var editedTodo = todos.find((todo) => todo.id == id);
    console.log(editedTodo);
    editedTodo.statusId = props.status.id;
    editedTodo.status = null;
    dispatch(editTodo(editedTodo));
  };

  return (
    <div className="column">
      <div className="status-title">{props.status.name}</div>
      <div
        className="container"
        onDragEnter={(e) => onDragEnter(e)}
        onDragOver={(e) => onDragOver(e)}
        onDragLeave={(e) => onDragLeave(e)}
        onDrop={(e) => onDrop(e)}
      >
        {filteredTodos}
      </div>
    </div>
  );
};
