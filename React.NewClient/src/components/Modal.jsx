import React from "react";
import ReactDOM from "react-dom";

const modal = document.getElementById("modal-wrapper");

const Modal = () => {
  return ReactDOM.createPortal(
    <div className="modal">
      <div className="background" onClick={onCloseModal} />

      <div className="content">
        <div className="header">
          <div className="title">{title}</div>
          <div className="close">
            <button className="close-button" onClick={onCloseModal}>
              <i className="bi bi-x-lg" />
            </button>
          </div>
        </div>
        <div className="body">{children}</div>
        <div className="footer"></div>
      </div>
    </div>,
    modal
  );
}

export default Modal;