import React from "react";
import { Link, Navigate } from "react-router-dom";
import { connect } from "react-redux";

import "bootstrap-icons/font/bootstrap-icons";
import "../styles/style";
import "../styles/userTable";

class GroupMemberTable extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: true,
      searchName: "",
    };

    this.onChangeSearch = this.onChangeSearch.bind(this);
  }

  async onChangeSearch(e) {
    this.setState({ isLoaded: false, searchName: e.target.value });
    await fetch("https://localhost:7139/api/account/searchByName" + this.state.searchName, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    }).then(result => result.json());
    this.setState({ isLoaded: true });
  }

  render() {
    const { isLoaded, searchName } = this.state;
    const { isLogin } = this.props;

    if (isLogin) return <Navigate to="/login" />;

    var rows;

    if (isLoaded) {
      rows = accounts.map((account, key) => (
        <tr className="tr" key={key}>
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
      <div className="account-table">
        <div className="filters row">
          <div className="input search">
            <label>Search</label>
            <input
              type="search"
              value={searchName}
              onChange={this.onChangeSearch}
            />
          </div>
        </div>
        <div className="table">
          <table className="table">
            <thead className="thead">
              <tr className="tr">
                <th className="th">Имя</th>
              </tr>
            </thead>
            <tbody className="tbody">{rows}</tbody>
          </table>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    user: state.user.isLogin,
    userId: state.user.id,
  };
};

const mapDispatchToProps = {
};

export default connect(mapStateToProps, mapDispatchToProps)(GroupMemberTable);
