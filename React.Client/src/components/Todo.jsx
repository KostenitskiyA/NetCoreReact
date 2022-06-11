import React from "react";
import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import "../styles/index";

export const Todo = () => {
  let { id } = useParams();
  const todo = useSelector((state) => state.todo.todos.find(todo => todo.id == id));
  const status = useSelector((state) => state.status.statuses.find(status => status.id == todo.statusId));

  return (
    <div className="todo">
      <div className="title">
        <input type="text" readOnly="true" value={todo.title} />
        <input type="text" readOnly="true" value={status.name} />
      </div>
      <div className="description">
        <input type="text" readOnly="true" value={todo.description} />
      </div>
      <div className="dates">
        <input type="date" readOnly="true" defaultValue={new Date(todo.createDate)} />
        <input type="date" readOnly="true" defaultValue={new Date(todo.changeDate)} />
      </div>
    </div>
  );
}
