import React, { useState } from "react";

import "../styles/boardCard"

const BoardCard = ({ todo }) => {
  const [isSelected, setIsSelected] = useState();
  const [isOpen, setIsOpen] = useState();

  const onDragStart = (event, todoId) => {
    event.dataTransfer.setData("text/plain", todoId);
    setIsSelected(true);
  };

  const onDragEnd = (event) => {
    event.dataTransfer.clearData();
    setIsSelected(false);
  };

  const onDelete = (event) => {
    this.props.deleteTodo(this.props.todo);
  };

  const onToggleModal = (event) => {
    setIsOpen(!isOpen);
  };

  return (
    <>
      <div
        className="card"
        draggable
        onDragStart={(event) => onDragStart(event, todo.id)}
        onDragEnd={(event) => onDragEnd(event)}
        onClick={() => onToggleModal()}
      >
        <div className="col">
          <div className="tags"></div>
          <div className="title">{todo.title}</div>
          <div className="row">
            <div className="date">
              {new Date(todo.createDate).toLocaleDateString()}
            </div>
            <div className="code">{todo.id}</div>
            <div className="avatars"></div>
          </div>
        </div>
        {/* <div ></div>
    <div className="description">{todo.description}</div>
    <div className="dates">
      <div className="date">            
      </div>
      <div className="date">
        {new Date(todo.changeDate).toLocaleDateString("ru-RU")}
      </div>
    </div>
    <button onClick={this.onDelete}>
      <i className="bi bi-x" />
    </button> */}
      </div>

      {/* <Modal
        title={todo.title}
        isModalOpen={isOpen}
        onCloseModal={onToggleModal}
      >
        <Todo todo={todo} />
      </Modal> */}
    </>
  );
};

export default BoardCard;
