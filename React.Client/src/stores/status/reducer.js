import { GET_STATUSES } from "../constants.js";

const initialState = {
  statuses: [],
};

export const statusReducer = (state = initialState, action) => {
  switch (action.type) {
    case GET_STATUSES:
      return { statuses: action.payload };
  }

  return state;
};
