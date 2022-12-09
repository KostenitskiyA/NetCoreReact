import React from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";
import { useGetGroupsByAccountQuery } from "../store";

const Home = () => {
  const navigate = useNavigate();
  const { user } = useAuth();
  const { data = [] } = useGetGroupsByAccountQuery(user.id);

  return data.map((group, key) => (
    <div key={key}>
      <div>{group.name}</div>
      <button onClick={() => navigate(`/group/${group.id}/board`)}>Выбрать</button>
    </div>
  ));
};

export default Home;
