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

export type Invitation = any;

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
