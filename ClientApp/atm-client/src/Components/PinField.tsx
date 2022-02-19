import React, { useState } from 'react';
import { useAppDispatch } from '../Hooks';
import { useLoginStatus } from '../Hooks/useCard';
import { login } from '../Store/Actions/CardActions';
import { setCardData, setCardPin, setLoginAttemp } from '../Store/CardSlice';
import { Page } from '../Store/NavigationSlice';
import './PinField.css';

export interface PinFieldProps {
    nextPage: Page;
}

export const PinField = (props: PinFieldProps) => {
    const [pin, setPin] = useState('');
    const { attemp, success } = useLoginStatus();
    const dispatch = useAppDispatch();

    const onChange = (e: any) => {
        setPin(e.target.value);
    }

    const onSubmit = (e: any) => {
        e.preventDefault();

        dispatch(setCardPin(pin));
        dispatch(login(props.nextPage));
    }

    return (
        <form className='pin-container'>
            <p>Attemps: {attemp}/3</p>
            <p>Please, enter the pin</p>
            <input value={pin} onChange={onChange}/>
            <button className='pin-button' onClick={onSubmit}>Enter</button>
        </form>
    );
}