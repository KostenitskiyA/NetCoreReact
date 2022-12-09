import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const todoApi = createApi({
  reducerPath: "todoApi",
  tagTypes: ["Todos"],
  baseQuery: fetchBaseQuery({ baseUrl: "https://localhost:7139/api/todo/" }),
  endpoints: (build) => ({
    getStatuses: build.query({
      query: () => ({
        url: "statuses",
        method: "GET",
      }),
    }),
    getTodo: build.query({
      query: (todoId) => ({
        url: `${todoId}`,
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
      }),
      providesTags: (result) =>
        result
          ? [
              ...result.map(({ id }) => ({ type: "Todos", id })),
              { type: "Todos", id: "LIST" },
            ]
          : [{ type: "Todos", id: "LIST" }],
    }),
    getTodosByAccount: build.query({
      query: (accountId) => ({
        url: `account:${accountId}/todos`,
        method: "GET",
      }),
      providesTags: (result) =>
        result
          ? [
              ...result.map(({ id }) => ({ type: "Todos", id })),
              { type: "Todos", id: "LIST" },
            ]
          : [{ type: "Todos", id: "LIST" }],
    }),
    getTodosByGroup: build.query({
      query: (groupId) => ({
        url: `group:${groupId}/todos`,
        method: "GET",
      }),
      providesTags: (result) =>
        result
          ? [
              ...result.map(({ id }) => ({ type: "Todos", id })),
              { type: "Todos", id: "LIST" },
            ]
          : [
              {
                type: "Todos",
                id: "LIST",
              },
            ],
    }),

    createTodo: build.mutation({
      query: (body) => ({
        url: "create",
        method: "POST",
        body,
      }),
      invalidatesTags: [{ type: "Todos", id: "LIST" }],
    }),
    updateTodo: build.mutation({
      query: (body) => ({
        url: "update",
        method: "POST",
        body,
      }),
      invalidatesTags: [{ type: "Todos", id: "LIST" }],
    }),
    deleteTodo: build.mutation({
      query: (todoId) => ({
        url: `/${todoId}/delete`,
        method: "POST",
      }),
      invalidatesTags: [{ type: "Todos", id: "LIST" }],
    }),
  }),
});

export const {
  useGetStatusesQuery,
  useGetTodoQuery,
  useGetTodosByAccountQuery,
  useGetTodosByGroupQuery,
  useCreateTodoMutation,
  useUpdateTodoMutation,
  useDeleteTodoMutation,
} = todoApi;
