import React from 'react';
import { useAppDispatch } from '../Hooks';
import { resetAccount } from '../Store/AccountSlice';
import { resetCard } from '../Store/CardSlice';
import { PagesId, resetNavigation, setCurrentPage } from '../Store/NavigationSlice';

export const Menu = () => {

    const dispatch = useAppDispatch();

    const handleButton = (e: any, pageId: PagesId) => {
        e.preventDefault();

        dispatch(setCurrentPage({id: pageId, phase: 0}));
    }

    const onBalanceClick = (e: any) => {
        handleButton(e, PagesId.Balance);
    }

    const onWithdrawClick = (e: any) => {
        handleButton(e, PagesId.Withdraw);
    }

    const onPaymentsClick = (e: any) => {
        handleButton(e, PagesId.Payments);
    }

    const onCloseClick = (e: any) => {
        handleButton(e, PagesId.Logination);

        dispatch(resetAccount());
        dispatch(resetCard());
        dispatch(resetNavigation());
    }

    return <>
        <button onClick={onBalanceClick }>Balance</button>
        <button onClick={onWithdrawClick}>Withdraw</button>
        <button onClick={onPaymentsClick}>Payments</button>
        <button onClick={onCloseClick}>Close</button>
    </>
}