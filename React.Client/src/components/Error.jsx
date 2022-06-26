import React from "react";
import "../styles/board";
import "bootstrap-icons/font/bootstrap-icons";

export const Error = (props) => {
  const { statusCode, error } = this.props;

  return (
    <div>
      <div>{statusCode}</div>
      <div>{error}</div>
    </div>
  );
};
