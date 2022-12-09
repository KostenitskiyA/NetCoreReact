import React, { useState } from "react";
import { useParams } from "react-router-dom";
import { useGetStatusesQuery, useGetTodosByGroupQuery } from "../store";

import BoardColumn from "../components/BoardColumn";

import Modal from "../components/Modal";

import "../styles/board";

const Board = () => {
  const [isModalShow, setIsModalShow] = useState(false);
  const [selectTodo, setSelectTodo] = useState(null);
  const { groupId } = useParams();
  const statusQuery = useGetStatusesQuery();
  const todoQuery = useGetTodosByGroupQuery(groupId);
  //const modal = <Modal title={"Задача"} isModalShow={isModalShow} />;

  if (statusQuery.isSuccess && todoQuery.isSuccess) {
    return (
      <div className="board">
        <div className="row">
          {statusQuery?.data.map((status, key) => (
            <BoardColumn
              key={key}
              status={status}
              todos={todoQuery?.data.filter(
                (todo) => todo.statusId == status.id
              )}
            />
          ))}
        </div>

        {/* selectTodo ? modal : null */}
      </div>
    );
  } else {
    <h1>Loading</h1>;
  }
};

export default Board;
