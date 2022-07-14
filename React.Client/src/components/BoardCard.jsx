import React from "react";
import { connect } from "react-redux";

import { deleteTodo } from "../stores/todo/actions";

import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";

class BoardCard extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isSelected: false,
    };

    this.onDragStart = this.onDragStart.bind(this);
    this.onDragEnd = this.onDragEnd.bind(this);
    this.onDelete = this.onDelete.bind(this);
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

  render() {
    const { todo } = this.props;
    const className = this.state.isSelected ? "card selected" : "card";

    const year = new Intl.DateTimeFormat('ru', { year: 'numeric' }).format(todo.createDate);
    const month = new Intl.DateTimeFormat('ru', { month: 'short' }).format(todo.createDate);
    const day = new Intl.DateTimeFormat('ru', { day: '2-digit' }).format(todo.createDate);
    const date = day + " " + month + " " + year;

    return (
      <div
        className={className}
        draggable
        onDragStart={(e) => this.onDragStart(e, todo.id)}
        onDragEnd={(e) => this.onDragEnd(e)}
      >
        <div className="col">
          <div className="tags"></div>
          <div className="title">{todo.title}</div>
          <div className="row">
            <div className="date">{date}</div>
            <div className="code">{todo.code}</div>
            <div className="avatar"></div>
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
