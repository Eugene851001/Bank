import React from "react";
import { useAppDispatch } from "../Hooks";
import { resetAccount, setWithdrawSucess } from "../Store/AccountSlice";
import { setCardPin, setSuccess } from "../Store/CardSlice";
import { PagesId, setCurrentPage } from "../Store/NavigationSlice";
import './General.css'

export const ReturnButton = () => {
    const dispatch = useAppDispatch();

    const onReturn = (e: any) => {
        e.preventDefault();

        dispatch(setCurrentPage({id: PagesId.Menu, phase: 0}));
        dispatch(resetAccount());
        dispatch(setSuccess(false));
        dispatch(setCardPin(undefined));
    }
    return <button className="submit-button" onClick={onReturn}>Return</button>
}