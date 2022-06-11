import { GET_STATUSES_API } from "../api.js";
import { GET_STATUSES } from "../constants.js";

export const getStatuses = () => {
  return async (dispatch) => {
    const responce = await fetch(GET_STATUSES_API, {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    });
    const json = await responce.json();

    dispatch({ type: GET_STATUSES, payload: json });
  };
};