import React from "react";
import { Navigate } from "react-router-dom";
import { UserRole } from "../utils/enums";

type Props = {
  isAuthenticated: boolean;
  role?: UserRole;
  children: JSX.Element;
};

const AdminRoute = ({ isAuthenticated, role, children }: Props) => {
  if (isAuthenticated && role === UserRole.Admin) {
    return children;
  }

  return <Navigate to="/login" />;
};

export default AdminRoute;
