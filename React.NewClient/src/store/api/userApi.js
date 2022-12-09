import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const userApi = createApi({
  reducerPath: "userApi",
  tagTypes: ["User"],
  baseQuery: fetchBaseQuery({ baseUrl: "https://localhost:7139/api/user/" }),
  endpoints: (build) => ({
    signin: build.mutation({
      query: (body) => ({
        url: "signin",
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body,
      }),
    }),
    autoLogin: build.mutation({
      query: () => ({
        url: "login",
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
      }),
    }),
    login: build.mutation({
      query: (body) => ({
        url: "login",
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body,
      }),
    }),
    logout: build.mutation({
      query: () => ({
        url: "logout",
        method: "GET",
        headers: { "Content-Type": "application/json" },
      }),
    }),
  }),
});

export const {
  useSigninMutation,
  useAutoLoginMutation,
  useLoginMutation,
  useLogoutMutation,
} = userApi;
