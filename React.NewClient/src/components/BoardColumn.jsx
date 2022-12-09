import React from "react";
import { ApiProvider } from "@reduxjs/toolkit/dist/query/react";
import { todoApi, useUpdateTodoMutation } from "../store";

import BoardCard from "./BoardCard";

import "../styles/boardColumn";

const BoardColumn = ({ status, todos }) => {
  const [updateTodo] = useUpdateTodoMutation();
  const [trigger, result] = todoApi.endpoints.getTodo.useLazyQuery();

  const onDragEnter = (event) => {
    event.preventDefault();
  };

  const onDragOver = (event) => {
    event.preventDefault();
  };

  const onDragLeave = (event) => {
    event.preventDefault();
  };

  const onDrop = async (event) => {
    const data = event.dataTransfer.getData("text");
    const result = trigger(1);
    console.log(data);
    // const editedTodo = todos.filter((todo) => todo.id == id);
    // console.log(todos);
    // console.log(editedTodo);
    data.statusId = status.id;
    data.status = null;
    console.log(data);
    const responce = await updateTodo(data);
    console.log(responce);
  };

  return (
    <div className="column">
      <div className="title">{status.name}</div>
      <div
        className="container"
        onDragEnter={(e) => onDragEnter(e)}
        onDragOver={(e) => onDragOver(e)}
        onDragLeave={(e) => onDragLeave(e)}
        onDrop={(e) => onDrop(e)}
      >
        {todos?.map((todo, key) => {
          return <BoardCard key={key} todo={todo} />;
        })}
      </div>
    </div>
  );
};

export default BoardColumn;
