import { useEffect, useState } from "react";
import { Button, Input, Modal, Select, Textarea } from "react-daisyui"
import "react-datepicker/dist/react-datepicker.css";
import { EventDTO, User } from "../utils/types";
import { createEvent } from "../api/event";
import { getUsers } from "../api/auth";

type Props = {
  visible: boolean;
  toggleVisible: React.Dispatch<React.SetStateAction<boolean>>;
  selectedDate: Date;
  user?: User;
}

export const EventCreateModal = ({ user, visible, toggleVisible, selectedDate }: Props) => {
  // console.log(selectedDate)
  const currentDate = new Date();
  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data: EventDTO = {
      title,
      description,
      startTime: new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), startHour, startMinute).toISOString(),
      endTime: new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), endHour, endMinute).toISOString(),
      inviteeIds: selectedUsers.map(user => user.id) //TODO: kai atsinaujins contractas pridet cia selected users.
    }
    await createEvent(data, user?.id);
    toggleVisible(false);
  };

  useEffect(() => {
    getUsers().then(users => setUsers(users))
  }, []);


  const [startHour, setStartHour] = useState<number>(currentDate.getHours())
  const [startMinute, setStartMinute] = useState<number>(Number('00'))

  const [endHour, setEndHour] = useState<number>(currentDate.getHours() + 1)
  const [endMinute, setEndMinute] = useState<number>(Number('00'))

  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');

  const [users, setUsers] = useState<User[]>([])
  const [selectedUsers, setSelectedUsers] = useState<User[]>([])

  useEffect(() => {
    setStartHour(currentDate.getHours());
    setStartMinute(Number('00'));
    setEndHour(currentDate.getHours());
    setEndMinute(Number('00'));
    setTitle('');
    setDescription('');
  }, [visible])

  return (
    <Modal open={visible} onClickBackdrop={() => toggleVisible(false)} className={'min-w-fit overflow-visible'}>
      <Modal.Header className="font-bold">
        Create Event
      </Modal.Header>

      <Modal.Body>
        <form className={`flex mx-8 flex-col`} onSubmit={handleSubmit}>
          <div className="flex flex-row gap-4 mb-4">
            <label className="my-auto">
              from
            </label>
            <div id='start-time'>
              <Select
                value={startHour}
                onChange={setStartHour}
              >
                {Array.from(Array(24).keys()).map(hour => (
                  <Select.Option key={hour} value={hour}>{hour}</Select.Option>
                ))}
              </Select>
              <Select
                value={startMinute}
                onChange={setStartMinute}
              >
                {['00', '15', '30', '45'].map(minute => (
                  <Select.Option key={minute} value={minute}>{minute}</Select.Option>
                ))}
              </Select>
            </div>
            <label className="my-auto">
              to
            </label>
            <div id='end-time'>
              <Select
                value={endHour}
                onChange={setEndHour}
              >
                {Array.from(Array(24).keys()).map(hour => (
                  <Select.Option key={hour} value={hour}>{hour}</Select.Option>
                ))}
              </Select>
              <Select
                value={endMinute}
                onChange={setEndMinute}
              >
                {['00', '15', '30', '45'].map(minute => (
                  <Select.Option key={minute} value={minute}>{minute}</Select.Option>
                ))}
              </Select>
            </div>
          </div>
          <Input value={title} onChange={e => setTitle(e.target.value)} className="mb-4" placeholder="Title" />
          <Textarea value={description} onChange={e => setDescription(e.target.value)} className="mb-4" placeholder="Description" />

          <label htmlFor="multiple_select" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Select an option</label>
          <select onChange={(e) => {
            const options = e.target?.options;
            for (let i = 0; i < options.length; i++) {
              if (options[i].selected) {
                setSelectedUsers([...selectedUsers, JSON.parse(options[i].value)])
              }
            }
          }} multiple id="multiple_select" className="mb-4 bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-gray-500 focus:border-gray-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-gray-500 dark:focus:border-gray-500">
            {users.filter((u) => u.id !== user?.id).map(u => (
              <option key={u.id} value={JSON.stringify(u)} >{`${u.name}, ${u.email}`}</option>
            )
            )}
          </select>
          <Button type="submit" value="Submit" >
            Create
          </Button>
        </form>
      </Modal.Body>
    </Modal>

  )
}