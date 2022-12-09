import React from "react";
import { Navigate } from "react-router-dom";
import { connect } from "react-redux";

import AvatarIcon from "./AvatarIcon";

import "../styles/member";
import "bootstrap-icons/font/bootstrap-icons";

class GroupMemberTable extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: false,
      accounts: null,
      // searchName: "",
    };

    // this.onChangeSearch = this.onChangeSearch.bind(this);
  }

  // async onChangeSearch(e) {
  //   this.setState({ isLoaded: false, searchName: e.target.value });
  //   await fetch("https://localhost:7139/api/account/searchByName" + this.state.searchName, {
  //     method: "GET",
  //     headers: { "Content-Type": "application/json" },
  //   }).then(result => result.json());
  //   this.setState({ isLoaded: true });
  // }

  async componentDidMount() {
    await fetch(
      "https://localhost:7139/api/account/{groupId}/members".replace(
        "{groupId}",
        this.props.currentGroup.id
      ),
      {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      }
    )
      .then((result) => result.json())
      .then((json) =>
        this.setState({ ...this.state, isLoaded: true, accounts: json })
      );
  }

  render() {
    const { isLoaded, accounts } = this.state;
    const { isLogin } = this.props;

    if (isLogin) return <Navigate to="/login" />;

    var rows;

    if (isLoaded && accounts) {
      rows = accounts.map((account, key) => (
        <tr className="tr" key={key}>
          <td className="td">
            <AvatarIcon avatar={account.avatar}/>            
          </td>
          <td className="td">{account.name}</td>
        </tr>
      ));
    } else {
      rows = (
        <tr>
          <td>Loading...</td>
        </tr>
      );
    }

    return (
      <div className="group-members-table">
        {/* <div className="filters row">
          <div className="input search">
            <label>Search</label>
            <input
              type="search"
              value={searchName}
              onChange={this.onChangeSearch}
            />
          </div>
        </div> */}
        <div className="table">
          <table>
            <thead>
              <tr>
                <th></th>
                <th>Имя</th>
              </tr>
            </thead>
            <tbody>{rows}</tbody>
          </table>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    user: state.user,
    currentGroup: state.group.currentGroup,
  };
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(GroupMemberTable);
