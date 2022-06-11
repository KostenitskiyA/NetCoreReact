import React from "react";
import { connect } from "react-redux";
import {
  addNotification,
  deleteNotification,
  deleteAllNotification
} from "../stores/notification/actions";

import Notification from "../components/Notification";

import "../styles/notification";

class NotificationContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="notification-container">
        {this.props.notification.notifications.map((notification, key) => (
          <Notification
            key={key}
            id={notification.id}
            title={notification.title}
            description={notification.description}
            delete={this.props.deleteNotification}
          />
        ))}
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    notification: state.notification,
  };
};

const mapDispatchToProps = {
  addNotification,
  deleteNotification,
  deleteAllNotification
};

export default connect(mapStateToProps, mapDispatchToProps)(NotificationContainer);
