import React from "react";
import { connect } from "react-redux";
import { deleteTodo } from "../stores/todo/actions";
import Modal from "./Modal";
import Todo from "./Todo";

import "../styles/boardCard";
import "bootstrap-icons/font/bootstrap-icons";

class BoardCard extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isSelected: false,
      isOpen: false,
    };

    this.onDragStart = this.onDragStart.bind(this);
    this.onDragEnd = this.onDragEnd.bind(this);
    this.onDelete = this.onDelete.bind(this);

    this.onToggleModal = this.onToggleModal.bind(this);
  }

  onDragStart(e, id) {
    e.dataTransfer.setData("text/plain", id);
    this.setState({ isSelected: true });
  }

  onDragEnd(e) {
    e.dataTransfer.clearData();
    this.setState({ isSelected: false });
  }

  onDelete() {
    this.props.deleteTodo(this.props.todo);
  }

  onToggleModal() {
    this.setState({ ...this.state, isOpen: !this.state.isOpen });
  }

  render() {
    const { todo } = this.props;
    const className = this.state.isSelected ? "card selected" : "card";

    return (
      <React.Fragment>
        <div
          className={className}
          draggable
          onDragStart={(e) => this.onDragStart(e, todo.id)}
          onDragEnd={(e) => this.onDragEnd(e)}
          onClick={() => this.onToggleModal()}
        >
          <div className="col">
            <div className="tags"></div>
            <div className="title">{todo.title}</div>
            <div className="row">
              <div className="date">{new Date(todo.createDate).toLocaleDateString()}</div>
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
        <Modal
          title={todo.title}
          isModalOpen={this.state.isOpen}
          onCloseModal={this.onToggleModal}
        >
          <Todo todo={todo} />
        </Modal>
      </React.Fragment>
    );
  }
}

const mapStateToProps = (state) => {
  return {};
};

const mapDispatchToProps = {
  deleteTodo,
};

export default connect(mapStateToProps, mapDispatchToProps)(BoardCard);
