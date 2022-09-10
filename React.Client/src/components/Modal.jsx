import React from "react";
import ReactDOM from "react-dom";
import "../styles/modal";

const modal = document.getElementById("modal");

class Modal extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    var title = this.props.title;
    var isOpen = this.props.isModalOpen;
    var onClose = this.props.onCloseModal;

    if (!isOpen) return null;

    return ReactDOM.createPortal(
      <div className="modal">
        <div className="background"/>

        <div className="content">
          <div className="header">
            <div className="title">{title}</div>
            <div className="close">
              <button onClick={onClose}>
                <i className="bi bi-x-lg" />
              </button>
            </div>
          </div>
          <div className="body">{this.props.children}</div>
          <div className="footer"></div>
        </div>        
      </div>,
      modal
    );
  }
}

export default Modal;
