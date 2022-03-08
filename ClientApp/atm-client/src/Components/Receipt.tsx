import React from "react";
import { useCardData } from "../Hooks/useCard";
import { useReceiptData } from "../Hooks/useReceipt";
import { AccountReducer } from "../Store/AccountSlice";
import './Receipt.css';

export const Receipt = () => {

    const data = useReceiptData();
    const { accountNumber, currency } = useCardData();

    if (!data) {
        return <p>No info</p>;
    }

    const { operation, sum, date, destinationAccount } = data;

    const dateFormat = (date: Date) => {
        const hours = date.getHours();
        const minutes = date.getMinutes();
        const seconds = date.getSeconds();

        date.setHours(12);

        return `${date.toISOString().substring(0, 10)} ${hours}:${minutes}:${seconds}`
    }

    return (<div className="receipt">
        <p>BNB Bank</p>
        <p>--------</p>
        <p>Account number: {accountNumber}</p>
        {destinationAccount ? <p>Destination account: {destinationAccount}</p> : ''}
        <p>Operation: {operation}</p>
        <p>Sum: {sum}</p>
        <p>Currency: {currency}</p>
        <p>Time: {dateFormat(date)}</p>
        <p>--------</p>
        <p>Thanks for using bankomat</p>
    </div>);
}