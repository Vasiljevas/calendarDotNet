import React, { useEffect, useState } from "react";
import { getUsers } from "../api/auth";
import { UserRole } from "../utils/enums";
import handleError from "../utils/errorHandler";
import { User } from "../utils/types";
import { Button, Table } from "react-daisyui";

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
      <Table>
        <Table.Head>
          <span>Name</span>
          <span>Email</span>
          <span>Role</span>
          <span>Remove User</span>
        </Table.Head>
        <Table.Body>
          {users.map(user => (
            <Table.Row>
              <span>{user.name}</span>
              <span>{user.email}</span>
              <span>{user.role === UserRole.Normal ? "Normal" : "Admin"}</span>
              <span><Button color="error" onClick={() => console.log('remove user')}>Remove</Button></span>
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    </div>
  );
};

export default AdminScreen;
