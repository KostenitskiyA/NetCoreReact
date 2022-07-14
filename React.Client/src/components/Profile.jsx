import React from "react";
import { connect } from "react-redux";
import { Navigate, Link } from "react-router-dom";
import "../styles/profile";
import "bootstrap-icons/font/bootstrap-icons";

class Profile extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { id, name, isLogin } = this.props;

    if (!isLogin) return <Navigate to="/login" />;

    return (
      <div className="wrapper">
        <div className="container">
          <div className="avatar">
            <i class="bi bi-person-fill"></i>
          </div>
          <div className="avatar-change">
            <i class="bi bi-pencil"></i>
          </div>
        </div>
        <div className="container">
          <div className="col">
            <div className="input-form">
              <label className="input-label">Id</label>
              <input type="text" readOnly value={id}></input>
            </div>
            <div className="input-form">
              <label className="input-label">Name</label>
              <input type="text" readOnly value={name}></input>
            </div>
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
