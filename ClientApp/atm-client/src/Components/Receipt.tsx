import React from "react";
import { useReceiptData } from "../Hooks/useReceipt";
import './Receipt.css';

export const Receipt = () => {

    const data = useReceiptData();

    if (!data) {
        return <p>No info</p>;
    }

    const { operation, sum, date } = data;

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
        <p>Operation: {operation}</p>
        <p>Sum: {sum}</p>
        <p>Time: {dateFormat(date)}</p>
        <p>--------</p>
        <p>Thanks for using bankomat</p>
    </div>);
}