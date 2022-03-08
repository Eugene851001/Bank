import React, { useEffect } from "react";
import { useAppDispatch } from "../Hooks";
import { useAccount } from "../Hooks/useAccount";
import { useCardData } from "../Hooks/useCard";
import { getBalance } from "../Store/Actions/AccountActions";
import { PrintReceiptButton } from "./PrintReceiptButton";
import { ReturnButton } from "./ReturnButton";
import './General.css';

export const Balance = () => {

    const { balance } = useAccount();
    const { accountNumber, currency } = useCardData();
     const dispatch = useAppDispatch();

    useEffect(() => {
        dispatch(getBalance());
    }, []);

    return balance !== undefined ? (
        <div className="vertical-container">
            <p>Account number: {accountNumber}</p>
            <p>Current balance: {balance} {currency}</p>
            <div className="horizontal-container">
                <ReturnButton />
                <PrintReceiptButton operation="Watch balance" sum={balance || 0} date={new Date()}/>
            </div>
        </div> ) : <p>Loading...</p>;
}