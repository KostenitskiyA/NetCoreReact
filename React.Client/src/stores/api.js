const BASE_URL = "https://localhost:7139/api";

const GROUP_CONTROLLER = "/group";
export const GET_GROUP_API = BASE_URL + GROUP_CONTROLLER + "/";
export const GET_GROUPS_BY_ACCOUNT_API = BASE_URL + GROUP_CONTROLLER + "/byAccount/";
export const CREATE_GROUP_API = BASE_URL + GROUP_CONTROLLER + "/create";
export const UPDATE_GROUP_API = BASE_URL + GROUP_CONTROLLER + "/update";
export const DELETE_GROUP_API = BASE_URL + GROUP_CONTROLLER + "/delete/";

const USER_CONTROLLER = "/user";
export const SIGNIN_API = BASE_URL + USER_CONTROLLER + "/signin";
export const LOGIN_API = BASE_URL + USER_CONTROLLER + "/login";
export const LOGOUT_API = BASE_URL + USER_CONTROLLER + "/logout";

const ACCOUNT_CONTROLLER = "/account";
export const GET_ACCOUNT_API = BASE_URL + ACCOUNT_CONTROLLER + "/";
export const GET_ACCOUNTS_BY_GROUP_API = BASE_URL + ACCOUNT_CONTROLLER + "/accounts/";

const TODO_CONTROLLER = "/todo";
export const GET_STATUSES_API = BASE_URL + TODO_CONTROLLER + "/statuses";
export const GET_TODO_API = BASE_URL + TODO_CONTROLLER + "/";
export const GET_TODOS_BY_GROUP_API = BASE_URL + TODO_CONTROLLER + "/byGroup/";
export const GET_TODOS_BY_ACCOUNT_API = BASE_URL + TODO_CONTROLLER + "/byAccount/";
export const CREATE_TODO_API = BASE_URL + TODO_CONTROLLER + "/create";
export const UPDATE_TODO_API = BASE_URL + TODO_CONTROLLER + "/update";
export const DELETE_TODO_API = BASE_URL + TODO_CONTROLLER + "/delete/";
