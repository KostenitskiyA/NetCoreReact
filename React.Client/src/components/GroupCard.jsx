import React from "react";
import { connect } from "react-redux";

import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";

class GroupCard extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { group } = this.props;

    return (
      <div className="card">
        <div className="col">
          <div className="name">{group.name}</div>
          <div className="code">{group.code}</div>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {};
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(GroupCard);
