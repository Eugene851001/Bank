import React, { useEffect, useState } from 'react';
import { useAppDispatch, useAppSelector } from '../Hooks';
import { useCardData, useLoginStatus } from '../Hooks/useCard';
import { setCardData, setCardNumber } from '../Store/CardSlice';
import { login } from '../Store/Actions/CardActions';
import { useNavigation } from '../Hooks/useNavigation';
import { PinField } from './PinField';
import { PagesId, setCurrentPage } from '../Store/NavigationSlice';
import './General.css';

export const Logination = () => {
    
    const {number } = useCardData();
    const [cardNumber, setNumber] = useState(number);

    const { currentPage } = useNavigation();
    const { phase } = currentPage;

    const dispatch = useAppDispatch();

    const onSubmit = (e: any) => {
        e.preventDefault();

        dispatch(setCardNumber(cardNumber));
        dispatch(setCurrentPage({id: PagesId.Logination, phase: 1}))
    }

    return (
        <>
            {phase == 0 && 
                <>
                    <form className='vertical-container'>
                        <p>Номер карты</p>
                        <input value={cardNumber} onChange={(e: any) => setNumber(e.target.value)}/>
                        <button className='submit-button' onClick={onSubmit}>Login</button>
                    </form>
                </>
            }
            {phase == 1 &&
                <PinField nextPage={{id: PagesId.Menu, phase: 0}}/> 
            } 
        </>
    );
}