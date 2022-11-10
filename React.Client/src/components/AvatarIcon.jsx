import React from "react";

import "../styles/AvatarIcon";
import "bootstrap-icons/font/bootstrap-icons";

class AvatarIcon extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { avatar } = this.props;

    const avatarImg = avatar ? (
      <img className="image" src={avatar} />
    ) : (
      <i className="bi bi-person-fill icon"></i>
    );

    return <div className="avatar">{avatarImg}</div>;
  }
}

export default AvatarIcon;
