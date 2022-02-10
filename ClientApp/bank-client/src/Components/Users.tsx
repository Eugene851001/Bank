import React, {useEffect, useState } from 'react';
import { UserDemo } from '../Models/UserDemo';
import { User } from './User';
import { UsersService } from '../Services/UsersService';
import { Link } from 'react-router-dom';
import './Users.css'

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
        <div className='page-content'>
            <h1>Список пользователей</h1>
            <table className='users-table'> 
                <tr><th>Фамилия</th><th>Отчество</th><th>Имя</th></tr>
                {(users as UserDemo[]).map(u => <User key={u.id} {...u}/>)}
            </table>
            <Link to="/users/create">Добавить пользователя</Link>
            <Link to="/deposits">Депозиты</Link>
            <Link to="/credits">Кредиты</Link>
        </div>) : <p>Loading...</p>;
}