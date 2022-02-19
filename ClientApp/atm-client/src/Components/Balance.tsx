import React, { useEffect } from "react";
import { useAppDispatch } from "../Hooks";
import { useAccount } from "../Hooks/useAccount";
import { useCardData } from "../Hooks/useCard";
import { getBalance } from "../Store/Actions/AccountActions";
import { PrintReceiptButton } from "./PrintReceiptButton";
import { ReturnButton } from "./ReturnButton";

export const Balance = () => {

    const { balance } = useAccount();
     const dispatch = useAppDispatch();

    useEffect(() => {
        dispatch(getBalance());
    }, []);

    return balance !== undefined ? (
        <>
            <p>Current balance: {balance}</p>
            <ReturnButton />
            <PrintReceiptButton operation="Watch balance" sum={balance || 0} date={new Date()}/>
        </> ) : <p>Loading...</p>;
}