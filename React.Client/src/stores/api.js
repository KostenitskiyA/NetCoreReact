const BASE_URL = "https://localhost:7139/api";

const GROUP_CONTROLLER = "/group";
export const GET_GROUP_API = BASE_URL + GROUP_CONTROLLER + "/{groupId}";
export const GET_GROUPS_BY_ACCOUNT_API = BASE_URL + GROUP_CONTROLLER + "/{accountId}/groups";
export const CREATE_GROUP_API = BASE_URL + GROUP_CONTROLLER + "/create";
export const UPDATE_GROUP_API = BASE_URL + GROUP_CONTROLLER + "/update";
export const DELETE_GROUP_API = BASE_URL + GROUP_CONTROLLER + "/{groupId}/delete";

const USER_CONTROLLER = "/user";
export const SIGNIN_API = BASE_URL + USER_CONTROLLER + "/signin";
export const LOGIN_API = BASE_URL + USER_CONTROLLER + "/login";
export const LOGOUT_API = BASE_URL + USER_CONTROLLER + "/logout";

const ACCOUNT_CONTROLLER = "/account";
export const GET_ACCOUNT_API = BASE_URL + ACCOUNT_CONTROLLER + "/{accountId}";
export const GET_FRIENDS_BY_ACCOUNT_API = BASE_URL + ACCOUNT_CONTROLLER + "/{accountId}/friends";
export const GET_ACCOUNTS_BY_GROUP_API = BASE_URL + ACCOUNT_CONTROLLER + "/{groupId}/members";
export const SEARCH_ACCOUNTS_BY_NAME_API = BASE_URL + ACCOUNT_CONTROLLER + "/searchByName/{searchName}";
export const SEARCH_ACCOUNTS_BY_NAME_IN_GROUP_API = BASE_URL + ACCOUNT_CONTROLLER + "/searchByName/{groupId}/{searchName}";
export const UPDATE_ACCOUNT_AVATAR_API = BASE_URL + ACCOUNT_CONTROLLER + "/updateAvatar";

const TODO_CONTROLLER = "/todo";
export const GET_STATUSES_API = BASE_URL + TODO_CONTROLLER + "/statuses";
export const GET_TODO_API = BASE_URL + TODO_CONTROLLER + "/{todoId}";
export const GET_TODOS_BY_ACCOUNT_API = BASE_URL + TODO_CONTROLLER + "/account:{accountId}/todos";
export const GET_TODOS_BY_GROUP_API = BASE_URL + TODO_CONTROLLER + "/group:{groupId}/todos";
export const CREATE_TODO_API = BASE_URL + TODO_CONTROLLER + "/create";
export const UPDATE_TODO_API = BASE_URL + TODO_CONTROLLER + "/update";
export const DELETE_TODO_API = BASE_URL + TODO_CONTROLLER + "/{groupId}/delete";
