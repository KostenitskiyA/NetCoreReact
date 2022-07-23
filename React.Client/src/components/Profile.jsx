import React from "react";
import { connect } from "react-redux";
import { Navigate, Link } from "react-router-dom";
import "../styles/profile";
import "bootstrap-icons/font/bootstrap-icons";

class Profile extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      image: "",
    };

    this.imageChange = this.imageChange.bind(this);
  }

  imageChange(e) {
    const img = URL.createObjectURL(e.target.files[0]);
    this.setState({ image: img });
  }

  render() {
    const { id, name, isLogin } = this.props;

    if (!isLogin) return <Navigate to="/login" />;

    let avatarImg;

    this.state.image == "" ? (
      <i className="bi bi-person-fill"></i>
    ) : (
      <img src={this.state.image} />
    );

    return (
      <div className="wrapper">
        <div className="container">
          <div className="avatar">{avatarImg}</div>
          <label className="avatar-change" htmlFor="avatar-input">
            <i className="bi bi-pencil"></i>
          </label>
          <input
            type="file"
            id="avatar-input"
            onChange={(e) => this.imageChange(e)}
          />
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
            <div className="input-form">
              <Link to="settings">
                <button>Change password</button>
              </Link>
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
