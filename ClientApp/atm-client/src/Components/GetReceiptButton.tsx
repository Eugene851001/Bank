import React from 'react';
import { useAppDispatch } from '../Hooks';
import { getPrinted, IReceiptData, setReceipt } from '../Store/ReceiptSlice';
import './GetReceiptButton.css'

export const GetReceiptButton = () => {

    const dispatch = useAppDispatch();

    const onPrint = (e: any) => {
        e.preventDefault();

        dispatch(getPrinted());
    }

    return <button className='get-receipt-button' onClick={onPrint}>Get</button>
}