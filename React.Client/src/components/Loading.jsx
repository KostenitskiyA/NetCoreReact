import React from "react";

import "../styles/loading";
import "bootstrap-icons/font/bootstrap-icons";

class Loading extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="loading">
        <div className="spinner">
          <i className="bi bi-arrow-repeat" />
        </div>
        <div className="title">Loading...</div>
      </div>
    );
  }
}

export default Loading;
