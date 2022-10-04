import {
  CHANGE_CURRENT_GROUP,
  GET_GROUP,
  GET_GROUPS_BY_ACCOUNT,
  CREATE_GROUP,
  UPDATE_GROUP,
  DELETE_GROUP,
} from "../constants.js";

const initialState = { groups: [], currentGroup: "" };

export const groupReducer = (state = initialState, action) => {
  switch (action.type) {
    // Изменение текущей группы
    case CHANGE_CURRENT_GROUP: {
      // const foundGroup = state.groups.find((group) => group.id == action.payload.id);
      
      // const newGroups = [...state.groups];

      // if (foundGroup) {        
      //   const index = state.groups.findIndex(
      //     (group) => group.id == action.payload.id
      //   );
      //   newGroups.slice(index, 1);        
      // }

      // newGroups.push(action.payload).id;

      return { ...state, currentGroup: action.payload };
    }

    // Получение групп аккаунта
    case GET_GROUPS_BY_ACCOUNT: {
      return { ...state, groups: action.payload };
    }

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
