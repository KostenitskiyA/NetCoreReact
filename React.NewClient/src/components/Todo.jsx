import React from "react";
import { groupApi, useGetStatusesQuery } from "../store";

const Todo = (todo) => {
  const { statuses = [] } = useGetStatusesQuery();

  return (
    <div className="todo row">
      <div className="description col w-60">
        <div className="input">
          <label className="label">Описание</label>
          <textarea
            className="input-textarea"
            type="textarea"
            rows="10"
            defaultValue={todo.description}
          />
        </div>
      </div>
      <div className="details col w-40">
        <div className="input">
          <label className="label">Статус</label>
          <select
            className="input-select"
            required
            defaultValue={todo.statusId}
            onChange={this.onChangeStatus}
          >
            {statuses.map((status, key) => (
              <option key={key} value={status.id}>
                {status.name}
              </option>
            ))}
          </select>
        </div>
        <div className="input">
          <label className="label">Автор</label>
          {/* <input
              className="input-text"
              type="text"
              readOnly={true}
              value={this.props.statuses.filter((s) => s.Id == todo.statusId)}
            /> */}
        </div>
        <div className="input">
          <label className="label">Дата создания</label>
          <input
            className="input-date"
            type="date"
            value={new Date(todo.changeDate).toLocaleDateString("ru-RU")}
          />
        </div>
        <div className="input">
          <label className="label">Дата изменения</label>
          <input
            className="input-date"
            type="date"
            value={new Date(todo.changeDate).toLocaleDateString("ru-RU")}
          />
        </div>
      </div>
    </div>
  );
};

export default Todo;
