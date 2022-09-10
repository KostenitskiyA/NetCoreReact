import React from "react";
import { connect } from "react-redux";
import { Navigate, Link } from "react-router-dom";
import { updateAvatar } from "../stores/user/actions";
import "../styles/profile";
import "bootstrap-icons/font/bootstrap-icons";

class Profile extends React.Component {
  constructor(props) {
    super(props);

    this.imageUpload = this.imageUpload.bind(this);
    this.avatarChange = this.avatarChange.bind(this);
    this.deleteAvatar = this.deleteAvatar.bind(this);
  }

  imageUpload(e) {
    const reader = new FileReader();

    reader.onloadend = () => {
      this.avatarChange(reader.result);
    };

    reader.readAsDataURL(e.target.files[0]);
  }

  avatarChange(image) {
    this.props.updateAvatar({ accountId: this.props.user.id, avatar: image });
  }

  deleteAvatar() {
    this.props.updateAvatar({ accountId: this.props.user.id, avatar: "" });
  }

  render() {
    const { id, name, avatar, isLogin } = this.props.user;

    if (!isLogin) return <Navigate to="/login" />;

    const avatarImg = avatar ? (
      <img className="avatar-img" src={avatar} />
    ) : (
      <div className="avatar-img">
        <i className="bi bi-person-fill avatar-icon" />
      </div>
    );

    const avatarLoaded = avatar != "" ? true : false;

    return (
      <div className="wrapper">
        <div className="container">
          <div className="col">
            <div className="avatar">{avatarImg}</div>
            <div className="row">
              <button disabled={avatarLoaded}>
                <label htmlFor="avatar-input">
                  <i className="bi bi-plus-lg"></i>
                </label>
              </button>
              <button disabled={!avatarLoaded} onClick={this.deleteAvatar}>
                <i className="bi bi-trash"></i>
              </button>
            </div>
          </div>

          <input
            type="file"
            id="avatar-input"
            onChange={(e) => this.imageUpload(e)}
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
            {/* <div className="input-form">
              <Link to="settings">
                <button>Change password</button>
              </Link>
            </div> */}
          </div>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    user: state.user,
  };
};

const mapDispatchToProps = {
  updateAvatar,
};

export default connect(mapStateToProps, mapDispatchToProps)(Profile);
