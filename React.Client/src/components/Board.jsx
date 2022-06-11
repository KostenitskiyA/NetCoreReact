import React from "react";
import { connect } from "react-redux";
import { getStatuses } from "../stores/status/actions";
import { getAllTodos } from "../stores/todo/actions";
import BoardColumn from "./BoardColumn";
import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";

class Board extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: true,
    };
  }

  componentDidMount() {
    this.props.getStatuses();
    this.props.getAllTodos();
  }

  render() {
    const { isLoaded } = this.state;
    const { stauses } = this.props;

    if (isLoaded && stauses) {
      return (
        <div className="row">
          {stauses.map((status, key) => (
            <BoardColumn
              key={key}
              status={status}
            />
          ))}
        </div>
      );
    } else {
      return <div>Loading...</div>;
    }
  }
}

const mapStateToProps = (state) => {
  return {
    stauses: state.status.statuses,
  };
};

const mapDispatchToProps = {
  getStatuses,
  getAllTodos,
};

export default connect(mapStateToProps, mapDispatchToProps)(Board);
