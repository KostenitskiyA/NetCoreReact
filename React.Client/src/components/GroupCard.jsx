import React from "react";
import { connect } from "react-redux";

import { changeCurrentGroup } from "../stores/group/actions";

import "../styles/groupCard";
import "bootstrap-icons/font/bootstrap-icons";

class GroupCard extends React.Component {
  constructor(props) {
    super(props);

    this.onOpenGroup = this.onOpenGroup.bind(this);
  }

  onOpenGroup(id) {    
    this.props.changeCurrentGroup(id);
  }

  render() {
    const { group } = this.props;

    return (
      <div className="card" onClick={() => this.onOpenGroup(group.id)}>
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

const mapDispatchToProps = {
  changeCurrentGroup
};

export default connect(mapStateToProps, mapDispatchToProps)(GroupCard);
