import { CREATE_GROUP, UPDATE_GROUP, DELETE_GROUP } from "../constants.js";

const initialState = { groups: [] };

export const groupReducer = (state = initialState, action) => {
  switch (action.type) {
    // Добавление группы
    case CREATE_GROUP: {
      const newGroups = [...state.groups];
      newGroups.push(action.payload);

      return { ...state, groups: newGroups };
    }

    // Обновление группы
    case UPDATE_GROUP: {
      const newGroups = [...state.groups];
      const index = state.groups.findIndex(
        (group) => group.id == action.payload.id
      );
      newGroups[index] = action.payload;

      return { ...state, groups: newGroups };
    }

    // Удаление группы
    case DELETE_GROUP: {
      const newGroups = [...state.groups];
      const index = state.groups.findIndex(
        (group) => group.id == action.payload.id
      );
      newGroups.slice(index, 1);

      return { ...state, groups: newGroups };
    }
  }

  return state;
};
