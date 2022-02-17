import React, { useEffect, useState } from 'react';
import { useAppDispatch, useAppSelector } from '../Hooks';
import { useCardData, useLoginStatus } from '../Hooks/useCard';
import { login, setCardData } from '../Store/CardSlice';

export const Logination = () => {
    
    const {number } = useCardData();
    const { errorMessage, success, attemp } = useLoginStatus();
    const [cardNumber, setCardNumber] = useState(number);
    const [cardPin, setCardPin] = useState('');

    const dispatch = useAppDispatch();

    useEffect(() => {
        if (errorMessage) {
            alert(errorMessage);
        }
    }, [errorMessage]);

    const onSubmit = (e: any) => {
        e.preventDefault();

        dispatch(setCardData({number: cardNumber, pin: cardPin}));
        dispatch(login());
    }

    return (
        <>
            <p>Attemps: {attemp}/3</p>
            <p>{success ? 'Redirecting to menu...' : ''}</p>
            <form>
                <input value={cardNumber} onChange={(e: any) => setCardNumber(e.target.value)}/>
                <input value={cardPin} onChange={(e: any) => setCardPin(e.target.value)}/>
                <button onClick={onSubmit}>Login</button>
            </form>
        </>
    );
}