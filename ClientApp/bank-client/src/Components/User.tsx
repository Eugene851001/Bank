import React, { useState } from 'react';
import { UserDemo } from '../Models/UserDemo';
import { UserDTO } from '../Models/UserDTO';
import { Link } from 'react-router-dom';
import './User.css'
import { UsersService } from '../Services/UsersService';

export interface UserProps extends UserDemo {

}

export const User = (props: UserProps) => {

    const [isDeleted, setIsDeleted] = useState(false);

    const onDelete = async () => {
        await UsersService.DeleteUser(props.id);
        
        setIsDeleted(true);
    }

    const constracts =  (userId: number) => ``;

    return !isDeleted ? 
        <tr>    
            <td>
                {props.lastname}
            </td>
            <td>
                {props.surname}
            </td>
            <td>
                {props.name}
            </td>
            <td>
                <Link to={`/users/${props.id}`}><p>Редактировать</p></Link> 
            </td>
            <td>
                <Link to={`/depositForm/${props.id}`}>Оформить депозит</Link>
            </td>
            <td>
                <Link to={`/creditForm/${props.id}`}>Оформить кредит</Link>
            </td>
            <td>
                <button className='delete-button' onClick={onDelete}>Удалить</button>
            </td>
        </tr> : null;
}