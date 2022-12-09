import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const accountApi = createApi({
  reducerPath: "accountApi",
  tagTypes: ["Account"],
  baseQuery: fetchBaseQuery({ baseUrl: "https://localhost:7139/api/account/" }),
  endpoints: (build) => ({
    getAccount: build.query({
      query: (accountId) => ({
        url: `${accountId}`,
        method: "GET",
      }),      
    }),
    getFriendsByAccount: build.query({
      query: (accountId) => ({
        url: `${accountId}/friends`,
        method: "GET",
      }),
    }),
    getAccountsByGroup: build.query({
      query: (groupId) => ({
        url: `${groupId}/members`,
        method: "GET",
      }),
    }),
    searchAccountsByName: build.query({
      query: (searchName) => ({
        url: `searchByName/${searchName}`,
        method: "GET",
      }),
    }),
    searchAccountsByNameInGroup: build.query({
      query: (groupId, searchName) => ({
        url: `searchByName/${groupId}/${searchName}`,
        method: "GET",
      }),
    }),

    updateAccountAvatar: build.mutation({
      query: (body) => ({
        url: "updateAvatar",
        method: "POST",
        body,
      }),
    }),
  }),
});

export const {
  useGetAccountQuery,
  useGetFriendsByAccountQuery,
  useGetAccountsByGroupQuery,
  useSearchAccountsByNameQuery,
  useSearchAccountsByNameInGroupQuery,
  useUpdateAccountAvatarMutation,
} = accountApi;
