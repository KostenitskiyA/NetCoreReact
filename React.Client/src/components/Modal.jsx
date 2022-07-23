import React from "react";
import "../styles/modal";

class Modal extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      image: "",
    };

    
  }

  

  render() {
    return (
      <>
        <div className="modal">
          <div className="header">
            <div className="title"></div>
            <div className="close"></div>
          </div>
          <div className="body">
            <div className="preview">
              <img src={this.state.image}></img>
            </div>

            
          </div>
          <div className="footer"></div>
        </div>

        <div className="background" />
      </>
    );
  }
}

export default Modal;
