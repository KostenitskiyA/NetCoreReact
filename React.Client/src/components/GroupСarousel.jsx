import React from "react";
import { connect } from "react-redux";

import { getGroupsByAccount } from "../stores/group/actions";

import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";
import GroupCard from "./GroupCard";

class GroupСarousel extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: false,
    };
  }

  componentDidMount() {
    this.props.getGroupsByAccount(this.props.userId);
    this.setState({ isLoaded: true });
  }

  render() {
    const { isLoaded } = this.state;
    const { groups } = this.props;

    if (!isLoaded) {
      return <div>Loading...</div>;
    }

    return (
      <div className="row">
        {groups.map((group, key) => (
          <GroupCard key={key} group={group} />
        ))}
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    userId: state.user.id,
    groups: state.group.groups,
  };
};

const mapDispatchToProps = {
  getGroupsByAccount,
};

export default connect(mapStateToProps, mapDispatchToProps)(GroupСarousel);
