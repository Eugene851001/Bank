import React from 'react';
import { useAppDispatch } from '../Hooks';
import { getPrinted, IReceiptData, setReceipt } from '../Store/ReceiptSlice';


export const GetReceiptButton = () => {

    const dispatch = useAppDispatch();

    const onPrint = (e: any) => {
        e.preventDefault();

        dispatch(getPrinted());
    }

    return <button onClick={onPrint}>Get</button>
}