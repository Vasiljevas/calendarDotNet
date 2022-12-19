import axios from "axios";
import { LoginData, RegisterData, User } from "../utils/types";

export const login = async (data: LoginData): Promise<User> =>
  await (
    await axios.post("https://localhost:7237/api/login/check", data)
  ).data;

export const register = async (data: RegisterData): Promise<User> =>
  await (
    await axios.post("https://localhost:7237/api/register/add", data)
  ).data;

export const getUsers = async (): Promise<User[]> =>
  await (
    await axios.get("https://localhost:7237/api/login/users")
  ).data;

export const deleteUser = async (userId?: string): Promise<User[]> =>
  await (
    await axios.delete("https://localhost:7237/api/login", {params: {userId: userId}})
  ).data;
