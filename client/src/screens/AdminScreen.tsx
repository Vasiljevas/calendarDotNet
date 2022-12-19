import React, { useEffect, useState } from "react";
import { deleteUser, getUsers } from "../api/auth";
import { UserRole } from "../utils/enums";
import handleError from "../utils/errorHandler";
import { User } from "../utils/types";
import { Button, Table } from "react-daisyui";
import { getEvents } from "../api/event";

const AdminScreen = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [reload, setReload] = useState(false);

  const loadUsers = async () => {
    try {
      const users = await getUsers();
      const localEvents = users.map(u => {
        return getEvents(u.id);
      })
      setUsers(users);
      // setEvents(localEvents);
      console.log(localEvents)
    } catch (e) {
      handleError(e, "Failed to get users");
    }
  };

  useEffect(() => {
    loadUsers();
  }, [reload]);

  // {console.log(events)}
  return (
    <div className="p-20 flex flex-row gap-32">
      <div className="flex flex-col">
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
                <span><Button color="error" onClick={() => deleteUser(user.id).then(() => setReload(!reload))}>Remove</Button></span>
              </Table.Row>
            ))}
          </Table.Body>
        </Table>
      </div>
      {/* <div className="flex flex-col">
        <div className="text-2xl normal-case">List of registered events:</div>
        <Table>
          <Table.Head>
            <span>Name</span>
            <span>Email</span>
            <span>Role</span>
            <span>Remove User</span>
          </Table.Head>
          <Table.Body>
            {events.map(event => (
              <Table.Row>
                <span>{event?.title}</span>
                <span>{event?.startTime?.toUTCString()}</span>
                <span>{event?.endTime?.toUTCString()}</span>
                <span><Button color="error" onClick={() => console.log('remove user')}>Remove</Button></span>
              </Table.Row>
            ))}
          </Table.Body>
        </Table>
      </div> */}

    </div>
  );
};

export default AdminScreen;
