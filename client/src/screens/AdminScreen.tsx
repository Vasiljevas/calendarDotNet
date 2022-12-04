import React, { useEffect, useState } from "react";
import { getUsers } from "../api/auth";
import { UserRole } from "../utils/enums";
import handleError from "../utils/errorHandler";
import { User } from "../utils/types";

const AdminScreen = () => {
  const [users, setUsers] = useState<User[]>([]);

  const loadUsers = async () => {
    try {
      const users = await getUsers();
      setUsers(users);
    } catch (e) {
      handleError(e, "Failed to get users");
    }
  };

  useEffect(() => {
    loadUsers();
  }, []);

  return (
    <div className="p-20">
      <div className="text-2xl normal-case">List of registered users:</div>
      <div className="flex flex-col w-64 pt-4 gap-6">
        {users.map((user) => (
          <div key={user.id} className="rounded border border-indigo-400">
            <div>Name: {user.name}</div>
            <div>Email: {user.email}</div>
            <div>
              Role: {user.role === UserRole.Normal ? "Normal" : "Admin"}
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default AdminScreen;
