import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const groupApi = createApi({
  reducerPath: "groupApi",
  tagTypes: ["Groups"],
  baseQuery: fetchBaseQuery({ baseUrl: "https://localhost:7139/api/group/" }),
  endpoints: (build) => ({
    getGroup: build.query({
      query: (groupId) => ({
        url: `${groupId}`,
        method: "GET",
      }),      
    }),
    getGroupsByAccount: build.query({
      query: (accountId) => ({
        url: `${accountId}/groups`,
        method: "GET",
      }),
    }),

    createGroup: build.mutation({
      query: (body) => ({
        url: "create",
        method: "POST",
        body,
      }),
    }),
    updateGroup: build.mutation({
      query: (body) => ({
        url: "update",
        method: "POST",
        body,
      }),
    }),
    deleteGroup: build.mutation({
      query: (groupId) => ({
        url: `/${groupId}/delete`,
        method: "POST",
      })
    }),
  }),
});

export const {
  useGetGroupQuery,
  useGetGroupsByAccountQuery,
  useCreateGroupMutation,
  useUpdateGroupMutation,
  useDeleteGroupMutation,
} = groupApi;
