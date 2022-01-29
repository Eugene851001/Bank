import React from 'react';
import { UserDemo } from '../Models/UserDemo';
import { UserDTO } from '../Models/UserDTO';
import { Link } from 'react-router-dom';

export interface UserProps extends UserDemo {

}

export const User = (props: UserProps) => {

    return <Link to={`/users/${props.id}`}><p>{props.name} {props.surname} {props.lastname}</p></Link>;
}