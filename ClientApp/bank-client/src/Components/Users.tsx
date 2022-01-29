import React, {useEffect, useState } from 'react';
import { UserDemo } from '../Models/UserDemo';
import { User } from './User';
import { UsersService } from '../Services/UsersService';
import { Link } from 'react-router-dom';

export const Users = () => {
 
    const [users, setUsers] = useState<UserDemo[]>();

    useEffect(() => {
        async function loadData() {
            const response = await UsersService.getUsers();

            setUsers(response);
        }

        loadData();
    }, []);

    return users ? (
        <>
            <ul>
                {(users as UserDemo[]).map(u => <li key={u.id}><User {...u}/></li>)}
            </ul>
            <Link to="/users/create">Add user</Link>
        </>) : <p>Loading...</p>;
}