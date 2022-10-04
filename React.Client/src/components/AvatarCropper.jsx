import React from "react";
import { connect } from "react-redux";
import Cropper from "react-cropper";
import "../styles/avatarCropper";
import "cropperjs/dist/cropper.css";
import "bootstrap-icons/font/bootstrap-icons";
import "../styles/profile";
import { updateAvatar } from "../stores/user/actions";

class AvatarCropper extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      image: undefined,
      cropper: undefined,
    };

    this.setCropper = this.setCropper.bind(this);
    this.uploadImage = this.uploadImage.bind(this);
    this.deleteImage = this.deleteImage.bind(this);
    this.avatarChange = this.avatarChange.bind(this);
  }

  uploadImage(e) {
    const reader = new FileReader();

    reader.onloadend = () => {
      this.setState({ ...this.state, image: reader.result });
    };

    reader.readAsDataURL(e.target.files[0]);
  }

  deleteImage() {
    this.setState({ ...this.state, image: undefined });
  }

  setCropper(instance) {
    this.setState({ ...this.state, cropper: instance });
  }

  avatarChange() {
    this.props.updateAvatar({
      accountId: this.props.user.id,
      avatar: this.state.cropper.getCroppedCanvas().toDataURL(),
    });
  }

  render() {
    const { avatar } = this.props.user;

    const croppedImage = avatar != "" ? true : false;

    const cropperRing = this.state.image ? (
      <Cropper
        initialAspectRatio={1}
        src={this.state.image}
        onInitialized={(instance) => this.setCropper(instance)}
      />
    ) : (
      <div className="avatar-img">
        <label htmlFor="upload-button">
          <i className="bi bi-person-fill avatar-icon" />
        </label>
      </div>
    );

    return (
      <div className="cropper">
        {cropperRing}
        <div className="row">
          <button
            onClick={() => {
              this.avatarChange();
            }}
          >
            <i className="bi bi-plus-lg" />
          </button>
          <button
            onClick={() => {
              this.deleteImage();
            }}
          >
            <i className="bi bi-trash" />
          </button>
        </div>

        <input
          type="file"
          id="upload-button"
          onChange={(e) => this.uploadImage(e)}
        />
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

export default connect(mapStateToProps, mapDispatchToProps)(AvatarCropper);
