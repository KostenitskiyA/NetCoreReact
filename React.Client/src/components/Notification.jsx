import React from "react";
import "../styles/notification";

class Notification extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      timer: 5
    }

    this.onClickContainer = this.onClickContainer.bind(this);
  }

  componentDidMount() {
    setInterval(() => {
      this.setState({ timer: this.state.timer - 1});
      if (this.state.timer <= 0) {
        this.props.delete(this.props.id);
      }
    }, 1000);

    //setTimeout(() => {}, 5000);
  }

  onClickContainer() {
    this.props.delete(this.props.id);
  }

  render() {
    return (
      <div className="notification" onClick={this.onClickContainer}>
        <div className="title">
          <span>{this.props.title}</span>
          <input type="button" value="X" />
        </div>
        <div className="description">
          <span>{this.props.description}</span>
        </div>
        <div className="timeline">
          <progress max="5" value={this.state.timer} />
        </div>
      </div>
    );
  }
}

export default Notification;
