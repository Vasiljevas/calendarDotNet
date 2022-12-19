import { useEffect, useState } from "react";
import { getDaysInMonth } from "../utils/calendarUtils";
import { Months } from "../utils/enums";
import { EventCreateModal } from "./EventCreateModal";
import { User } from "../utils/types";
import { getEventDetails, getEvents } from "../api/event";
import { EventDetailsModal } from "./EventDetailsModal";
import { InvitiationsModal } from "./InvitationsModal";

type Props = {
  user?: User
}

export const Calendar = ({ user }: Props) => {
  const [month, setMonth] = useState<Months>(Months.December);
  const [year, setYear] = useState<number>(2022);
  const weekDay = new Date(year, month, 0).getDay();
  const daysInMonth = getDaysInMonth(year, month)
  let array = [];
  for (var i = - weekDay; i < daysInMonth - weekDay + weekDay - 1; i++) {
    array.push(i + 1);
  }

  const [events, setEvents] = useState<any[]>([]);
  const [selectedEvent, setSelectedEvent] = useState<any>(null)

  const [displayModal, setDisplayModal] = useState(false);
  const [selectedDay, setSelectedDay] = useState<number>(0);

  const [displayDetailsModal, setDisplayDetailsModal] = useState(false);

  useEffect(() => {
    getEvents(user?.id).then(events => setEvents(events))
  }, [displayModal, displayDetailsModal, month])
  
  console.log(selectedDay)
  return (
    <div>
      <EventCreateModal user={user} visible={displayModal} toggleVisible={setDisplayModal} selectedDate={new Date(year, month, selectedDay)} />
      <EventDetailsModal event={selectedEvent} visible={displayDetailsModal} toggleVisible={setDisplayDetailsModal} user={user} />
      <div className="text-gray-700">
        <div className="flex flex-grow w-screen h-screen overflow-auto">
          <div className="flex flex-col flex-grow margin-auto justify-center">
            <div className="flex items-center mt-4 justify-center">
              <button onClick={() => {
                  if (month === Months.January) {
                    setMonth(Months.December);
                    setYear(year - 1);
                  }
                  else {
                    setMonth(month - 1)
                  }
                }}>                <svg
                  className="w-6 h-6"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d="M15 19l-7-7 7-7"
                  />
                </svg>
              </button>
              <h2 className="mx-2 text-xl font-bold leading-none ">
                {`${Months[month]}, ${year}`}
              </h2>
              <button onClick={() => {
                if (month === Months.December) {
                  setMonth(Months.January);
                  setYear(year + 1);
                }
                else {
                  setMonth(month + 1)
                }
              }}>
                <svg
                  className="w-6 h-6"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d="M9 5l7 7-7 7"
                  />
                </svg>
              </button>
            </div>
            <div className="grid grid-cols-7 mt-4">
              <div className="pl-1 text-sm">Mon</div>
              <div className="pl-1 text-sm">Tue</div>
              <div className="pl-1 text-sm">Wed</div>
              <div className="pl-1 text-sm">Thu</div>
              <div className="pl-1 text-sm">Fri</div>
              <div className="pl-1 text-sm">Sat</div>
              <div className="pl-1 text-sm">Sun</div>
            </div>
            <div className="grid flex-grow w-full h-auto grid-cols-7 grid-rows-5 gap-px pt-px mt-1 bg-gray-200">
              {array.map((day, index) => {
                if (day < 1) {
                  return <div key={index} className="relative flex flex-col bg-gray group" />
                }
                return (
                  <div key={index} className="relative flex flex-col bg-white group">
                    <span className="mx-2 my-1 text-xs font-bold">{`${day}  ${Months[month]}`}</span>
                    <div className="flex flex-col px-1 py-1 overflow-auto">
                      {events.map(event => {
                        if (new Date(event.startTime).getDate() !== day || new Date(event.startTime).getMonth() !== month) {
                          return <></>
                        }
                        return (
                          <button onClick={() => { setSelectedEvent(event); setDisplayDetailsModal(true) }} className="flex items-center flex-shrink-0 h-5 px-1 text-xs hover:bg-gray-200">
                            <span className="flex-shrink-0 w-2 h-2 bg-gray-500 rounded-full"></span>
                            <span className="ml-2 font-light leading-none">{`${new Date(event.startTime).getHours()}:${new Date(event.startTime).getMinutes() < 10 ? new Date(event.startTime).getMinutes() + '0' : new Date(event.startTime).getMinutes()}`}</span>
                            <span className="ml-2 font-medium leading-none">
                              {event.title}
                            </span>
                          </button>
                        )
                      })}



                    </div>
                    <button onClick={() => { setDisplayModal(true); setSelectedDay( day ) }} className="absolute bottom-0 right-0 flex items-center justify-center hidden w-6 h-6 mb-2 mr-2 text-white bg-gray-400 rounded group-hover:flex hover:bg-gray-500">
                      <svg
                        className="w-5 h-5"
                        viewBox="0 0 20 20"
                        fill="currentColor"
                      >
                        <path
                          fillRule="evenodd"
                          d="M10 5a1 1 0 011 1v3h3a1 1 0 110 2h-3v3a1 1 0 11-2 0v-3H6a1 1 0 110-2h3V6a1 1 0 011-1z"
                          clipRule="evenodd"
                        ></path>
                      </svg>
                    </button>
                  </div>);
              }
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
