import React from 'react';
import { Calendar } from '../components/Calendar';
import { User } from '../utils/types';

type Props = {
    user?: User
}

export const MainScreen = ({ user }: Props) => {
    return (
        <Calendar user={user} />
    );
}