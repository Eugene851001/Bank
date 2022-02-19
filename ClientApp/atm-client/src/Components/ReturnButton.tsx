import React from "react";
import { useAppDispatch } from "../Hooks";
import { resetAccount, setWithdrawSucess } from "../Store/AccountSlice";
import { setCardPin } from "../Store/CardSlice";
import { PagesId, setCurrentPage } from "../Store/NavigationSlice";

export const ReturnButton = () => {
    const dispatch = useAppDispatch();

    const onReturn = (e: any) => {
        e.preventDefault();

        dispatch(setCurrentPage({id: PagesId.Menu, phase: 0}));
        dispatch(resetAccount());
        dispatch(setCardPin(undefined));
    }
    return <button onClick={onReturn}>Return</button>
}