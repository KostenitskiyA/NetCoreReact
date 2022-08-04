import React, { StrictMode } from "react";
import "../styles/modal";

class Modal extends React.Component {
  constructor(props) {
    super(props);

    this.onClose = this.onClose.bind(this);
  }

  onClose() {
  }

  render() {
    return (
      <React.Fragment>
        <div className="modal">
          <div className="content">
            <div className="header">
              <div className="title">{props.title}</div>
              <div className="close">
                <button onClick={() => this.onClose}>
                  <i class="bi bi-x-lg" />
                </button>
              </div>
            </div>
            <div className="body">
              {props.children}
            </div>
            <div className="footer"></div>
          </div>

          <div className="background" />
        </div>
      </React.Fragment>
    );
  }
}

export default Modal;
