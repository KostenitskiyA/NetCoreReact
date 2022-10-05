import React from "react";
import { connect } from "react-redux";
import { Navigate, Link } from "react-router-dom";
import Modal from "./Modal";
import { updateAvatar } from "../stores/user/actions";
import "../styles/profile";
import "bootstrap-icons/font/bootstrap-icons";
import AvatarCropper from "./AvatarCropper";

class Profile extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isAvatarCropperModalOpen: false
    }

    this.onToggleAvatarCropperModal = this.onToggleAvatarCropperModal.bind(this);
  }

  onToggleAvatarCropperModal() {
    this.setState({ ...this.state, isAvatarCropperModalOpen: !this.state.isAvatarCropperModalOpen });
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

    return (
      <div className="wrapper">
        <div className="container">
          <div className="col">            
            <div className="avatar" onClick={() => {this.onToggleAvatarCropperModal()}}>{avatarImg}</div>
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
            {/* <div className="input-form">
              <Link to="settings">
                <button>Change password</button>
              </Link>
            </div> */}
          </div>
        </div>

        <Modal
          isModalOpen={this.state.isAvatarCropperModalOpen}
          onCloseModal={this.onToggleAvatarCropperModal}
        >
          <AvatarCropper />
        </Modal>
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
