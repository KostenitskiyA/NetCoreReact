import React from "react";
import { connect } from "react-redux";
import { Navigate } from "react-router-dom";
import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";
import GroupСarousel from "./GroupСarousel";

class Home extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { isLogin } = this.props;

    if (!isLogin) return <Navigate to="/login" />;
    
    return (
      <div>
        <div>Home</div>
        <GroupСarousel />
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    userId: state.user.id,
    isLogin: state.user.isLogin,
  };
};

const mapDispatchToProps = {
};

export default connect(mapStateToProps, mapDispatchToProps)(Home);
