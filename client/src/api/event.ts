import axios from "axios";
import { EventDTO, EventListItem } from "../utils/types";

export const createEvent = async (data: EventDTO, id?: string): Promise<EventDTO> =>
  await (
    await axios.post(`https://localhost:7237/${id}`, data)
  ).data;

export const getEvents = async (id?: string): Promise<EventListItem[]> =>
  await (
    await axios.get(`https://localhost:7237/user/${id}`)
  ).data

export const getEventDetails = async (id?: string): Promise<any> =>
  await (
    await axios.get(`https://localhost:7237/event/${id}`)
  ).data

export const putEvent = async (data: EventDTO, userId?: string): Promise<EventDTO[]> =>
  await (
    await axios.post(`https://localhost:7237/${userId}`, data)
  ).data