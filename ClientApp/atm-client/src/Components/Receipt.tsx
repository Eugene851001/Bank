import React from "react";
import { useReceiptData } from "../Hooks/useReceipt";
import './Receipt.css';

export const Receipt = () => {

    const data = useReceiptData();

    if (!data) {
        return <p>No info</p>;
    }

    const { operation, sum, date } = data;

    return (<div className="receipt">
        <p>BNB Bank</p>
        <p>--------</p>
        <p>Operation: {operation}</p>
        <p>Sum: {sum}</p>
        <p>Date: {date.toISOString()}</p>
        <p>--------</p>
        <p>Thanks for using bankomat</p>
    </div>);
}