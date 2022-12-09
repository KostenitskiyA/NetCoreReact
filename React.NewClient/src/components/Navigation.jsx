import React from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

import "../styles/navigation";

const Navigation = () => {
  const { logOut, user } = useAuth();

  const userMenu = user ? (
    <>
      <li className="element">
        <a className="link" onClick={logOut}>
          Logout
        </a>
      </li>
      <li className="element">
        <Link className="link" to={"/profile/" + user.id}>
          {user.name}
          {/* <AvatarIcon avatar={user.avatar} /> */}
        </Link>
      </li>
    </>
  ) : (
    <>
      <li className="element">
        <Link className="link" to="/signin">
          SignIn
        </Link>
      </li>
      <li className="element">
        <Link className="link" to="/login">
          Login
        </Link>
      </li>
    </>
  );

  return (
    <nav className="navigation">
      <ul className="menu">
        <li className="element">
          <Link className="link" to="/home">
            Home
          </Link>
        </li>
        <li className="element">
          <Link className="link" to="/createGroup">
            Create group
          </Link>
        </li>
      </ul>
      <ul className="menu">{userMenu}</ul>
    </nav>
  );
}

export default Navigation;
