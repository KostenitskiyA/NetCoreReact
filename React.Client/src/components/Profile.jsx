import React from "react";
import { connect } from "react-redux";
import { Navigate, Link } from "react-router-dom";
import "../styles/index";
import "bootstrap-icons/font/bootstrap-icons";

class Profile extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { id, name, isLogin } = this.props;

    if (!isLogin) return <Navigate to="/login" />;

    return (
      <div className="container col">
        <div className="container row">
          <div className="profile-img">
            <div className="avatar">
              <i class="bi bi-person-fill"></i>
            </div>
          </div>
        </div>
        <div className="container row">
          <div className="profile-info">
            <div className="login">
              <input type="text" readOnly value={id}></input>
            </div>
            <div className="name">
              <input type="text" readOnly value={name}></input>
            </div>
          </div>
          <div className="profile-statistics">
            <Link to="/settings">
              Settings
            </Link>
          </div>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    id: state.user.id,
    name: state.user.name,
    isLogin: state.user.isLogin,
  };
};

const mapDispatchToProps = () => {
  return {};
};

export default connect(mapStateToProps, mapDispatchToProps)(Profile);
