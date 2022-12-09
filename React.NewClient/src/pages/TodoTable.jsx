import React, { useState } from "react";

const TodoTable = () => {
  const [search, setSearch] = useState("");
  const [fromDate, setFromDate] = useState(null);
  const [toDate, setToDate] = useState(null);

  const { statuses = [] } = useGetStatusesQuery();
  const { todos = [] } = useGetTodosByGroupQuery();

  return (
    <div className="todo-table">
      <div className="filters row">
        <div className="input search">
          <label>Search</label>
          <input
            type="search"
            value={searchName}
            onChange={this.onChangeSearch}
          />
        </div>
        <div className="input date">
          <label>From</label>
          <input
            type="date"
            value={fromDate}
            onChange={this.onChangeFromDate}
          />
        </div>
        <div className="input date">
          <label>To</label>
          <input type="date" value={toDate} onChange={this.onChangeToDate} />
        </div>
      </div>
      <div className="table">
        <table className="table">
          <thead className="thead">
            <tr className="tr">
              <th className="th">Название</th>
              <th className="th">Статус</th>
              <th className="th">Дата создания</th>
            </tr>
          </thead>
          <tbody className="tbody">
            {filteredTodos.map((todo, key) => (
              <TodoTableRow todo={todo} key={key} />
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default TodoTable;