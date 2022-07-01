import React from "react";
import { connect } from "react-redux";
import { Navigate } from "react-router-dom";
import "../styles/index";
import "bootstrap-icons/font/bootstrap-icons";

class Settings extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      avatar: "",
    };

    this.onFileChange = this.onFileChange.bind(this);
  }

  onFileChange(e) {
    e.preventDefault();
    this.setState({ avatar: URL.createObjectURL(e.target.files[0]) });
  }

  render() {
    const { id, name, isLogin } = this.props;

    const img = this.state.avatar != "" ? <img src={this.state.avatar}></img> : <i class="bi bi-person-fill"></i>

    if (!isLogin) return <Navigate to="/login" />;

    return (
      <div className="container">
        {img}
        <label>Profile picture</label>
        <input type="file" onChange={(e) => this.onFileChange(e)} />
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

export default connect(mapStateToProps, mapDispatchToProps)(Settings);
