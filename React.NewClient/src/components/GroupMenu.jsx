import React from "react";
import { NavLink, useParams } from "react-router-dom";
import {useGetGroupQuery } from "../store"

import "../styles/groupMenu"

const GroupMenu = () => {
  const { groupId } = useParams();
  const { data, isSuccess } = useGetGroupQuery(groupId);

  return (
    <div className="menu">
      <ul>
        <li className="group-name">
          <span>{isSuccess ? data.name : "Loading"}</span>
        </li>
        <li>
          <NavLink to="board" activeClassName="active">
            <i className="bi bi-kanban" />
            <span>Board</span>
          </NavLink>
        </li>
        <li>
          <NavLink to="todotable" activeClassName="active">
            <i className="bi bi-table" />
            <span>Table</span>
          </NavLink>
        </li>
        <li>
          <NavLink to="createTodo" activeClassName="active">
            <i className="bi bi-clipboard-plus" />
            <span>Create todo</span>
          </NavLink>
        </li>
        <li>
          <NavLink to="createTodo" activeClassName="active">
            <i className="bi bi-pie-chart-fill" />
            <span>Statistics</span>
          </NavLink>
        </li>
        <li>
          <NavLink to="members" activeClassName="active">
            <i className="bi bi-people-fill" />
            <span>Members</span>
          </NavLink>
        </li>
        <li>
          <NavLink to="createTodo" activeClassName="active">
            <i className="bi bi-trash3" />
            <span>Delete group</span>
          </NavLink>
        </li>
      </ul>
    </div>
  );
}

export default GroupMenu;