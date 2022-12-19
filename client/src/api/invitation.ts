import { Invitation } from './../utils/types';
import axios from "axios";

export const getInivatations = async (userId?: string): Promise<Invitation[]> =>
  await (
    await axios.get(`https://localhost:7237/${userId}`)
  ).data

export const acceptInvitation = async (id?: string, userId?: string): Promise<Invitation[]> =>
  await (
    await axios.post(`https://localhost:7237/accept/${id}/${userId}`)
  ).data

export const declineInvitation = async (id?: string, userId?: string): Promise<Invitation[]> =>
  await (
    await axios.delete(`https://localhost:7237/decline/${id}/${userId}`)
  ).data