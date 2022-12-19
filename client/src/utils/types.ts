import { UserRole } from "./enums";

export type User = {
  id: string;
  name: string;
  email: string;
  password: string;
  events: Event[];
  invitations: Invitation[];
  role: UserRole;
};

export type Event = any;

export interface LoginData {
  email: string;
  password: string;
}

export interface RegisterData extends LoginData {
  name: string;
  email: string;
  password: string;
  role: UserRole;
}

export type EventDTO = {
  title: string,
  description: string,
  startTime: string,
  endTime: string,
  inviteeIds: string[] | null,
}

export type EventListItem = {
  id: string,
  title: string,
  authorName: string,
}

export type Invitation = {
  id: string,
  title: string,
  authorName: string,
  startTime: string,
  endTime: string,
}