import React from 'react';
import { useReceiptPrinted } from '../Hooks/useReceipt';
import { GetReceiptButton } from './GetReceiptButton';
import { Receipt } from './Receipt';

export const ReceiptContainer = () => {
    const printed = useReceiptPrinted();

    return printed ? (<>
        <Receipt />
        <GetReceiptButton />
    </>) : <p>There will be receipt</p>;
}