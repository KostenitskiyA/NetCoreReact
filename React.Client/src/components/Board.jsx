import React from "react";
import { connect } from "react-redux";
import { getStatuses, getTodosByGroup } from "../stores/todo/actions";
import BoardColumn from "./BoardColumn";
import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";
import { Navigate } from "react-router-dom";
import Modal from "./Modal";

class Board extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: true,
      isModalShow: false,
      selectTodo: null,
    };
  }

  componentDidMount() {
    this.props.getStatuses();
    this.props.getTodosByGroup(this.props.userId);
  }

  render() {
    const { isLoaded } = this.state;
    const { userId, isLogin, statuses } = this.props;

    if (!isLogin) return <Navigate to="/login" />;

    var modal =
      this.state.selectTodo != null ? (
        <Modal title={"Задача"} isModalShow={this.state.isModalShow} />
      ) : null;

    if (isLoaded && statuses) {
      return (
        <div className="board">
          <div className="row">
            {statuses.map((status, key) => (
              <BoardColumn key={key} status={status} />
            ))}
          </div>

          {modal}
        </div>
      );
    } else {
      return <div>Loading...</div>;
    }
  }
}

const mapStateToProps = (state) => {
  return {
    userId: state.user.id,
    isLogin: state.user.isLogin,
    statuses: state.todo.statuses,
  };
};

const mapDispatchToProps = {
  getStatuses,
  getTodosByGroup,
};

export default connect(mapStateToProps, mapDispatchToProps)(Board);
