import React from "react";
import { connect } from "react-redux";
import Modal from "./Modal";
import Todo from "./Todo";

import "../styles/todoTableRow";

class TodoTableRow extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isOpen: false,
    };

    this.onToggleModal = this.onToggleModal.bind(this);
  }

  onToggleModal() {
    this.setState({ ...this.state, isOpen: !this.state.isOpen });
  }

  render() {
    const { todo, key, statuses } = this.props;
    const { isOpen } = this.state;

    return (
      <React.Fragment>
        <tr className="tr" key={key} onClick={() => this.onToggleModal()}>
          <td className="td">{todo.title}</td>
          <td className="td">
            {statuses.find((status) => status.id == todo.statusId).name}
          </td>
          <td className="td">{new Date(todo.createDate).getFullYear()}</td>
        </tr>

        <Modal
          title={todo.title}
          isModalOpen={isOpen}
          onCloseModal={this.onToggleModal}
        >
          <Todo todo={todo} />
        </Modal>
      </React.Fragment>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    statuses: state.todo.statuses,
  };
};

const mapDispatchToProps = {
};

export default connect(mapStateToProps, mapDispatchToProps)(TodoTableRow);
