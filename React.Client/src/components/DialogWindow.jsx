import React from "react";
import { connect } from "react-redux";
import { updateTodo } from "../stores/todo/actions";
import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";

class DialogWindow extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="modal-window">
        <div className="modal-container">
          <div className="modal-container-header"></div>
          <div className="modal-container-body"></div>
          <div className="modal-container-footer"></div>
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

export default connect(mapStateToProps, mapDispatchToProps)(DialogWindow);
