const BASE_URL = "https://localhost:7139/api";

const AUTHENTICATION_CONTROLLER = "/authentication";
export const SIGNIN_API = BASE_URL + AUTHENTICATION_CONTROLLER + "/signin";
export const LOGIN_API = BASE_URL + AUTHENTICATION_CONTROLLER + "/login";
export const LOGOUT_API = BASE_URL + AUTHENTICATION_CONTROLLER + "/logout";

const USER_CONTROLLER = "/user";
export const GET_USER_API = BASE_URL + USER_CONTROLLER + "/user";
export const GET_USERS_API = BASE_URL + USER_CONTROLLER + "/users";

const TODO_CONTROLLER = "/todo";
export const GET_STATUSES_API = BASE_URL + TODO_CONTROLLER + "/statuses";
export const GET_TODO_API = BASE_URL + TODO_CONTROLLER + "/todo";
export const GET_TODOS_API = BASE_URL + TODO_CONTROLLER + "/todos";
export const CREATE_TODO_API = BASE_URL + TODO_CONTROLLER + "/create";
export const EDIT_TODO_API = BASE_URL + TODO_CONTROLLER + "/edit";
export const DELETE_TODO_API = BASE_URL + TODO_CONTROLLER + "/delete";
