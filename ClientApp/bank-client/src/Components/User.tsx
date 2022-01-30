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

    return !isDeleted ? 
    <li>    
        <div className='user'>
            <Link to={`/users/${props.id}`}><p>{props.name} {props.surname} {props.lastname}</p></Link> 
            <button onClick={onDelete}>Удалить</button>
        </div>    
    </li>
        : null;
}