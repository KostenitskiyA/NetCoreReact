import React from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

import { changeCurrentGroup } from "../stores/group/actions";

import "../styles/groupCard";
import "bootstrap-icons/font/bootstrap-icons";

class GroupCard extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { group } = this.props;

    return (
      <Link to={"/group/" + group.id + "/board"}>
        <div className="card">
          <div className="col">
            <div className="name">{group.name}</div>
            <div className="code">{group.code}</div>
          </div>
        </div>
      </Link>
    );
  }
}

const mapStateToProps = (state) => {
  return {};
};

const mapDispatchToProps = {
  changeCurrentGroup,
};

export default connect(mapStateToProps, mapDispatchToProps)(GroupCard);
