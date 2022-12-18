import React from "react";
import { Navigate } from "react-router-dom";

type Props = {
  isAuthenticated: boolean;
  children: JSX.Element;
};

const PrivateRoute = ({ isAuthenticated, children }: Props) => {
  if (!isAuthenticated) {
    return (
      <>
        <Navigate to="/login" />
      </>
    );
  }

  return children;
};

export default PrivateRoute;
