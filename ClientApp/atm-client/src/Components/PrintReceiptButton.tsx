import React from 'react';
import { useAppDispatch } from '../Hooks';
import { IReceiptData, printReceipt, setReceipt } from '../Store/ReceiptSlice';
import './General.css';

export interface PrintReceiptButtonProps extends IReceiptData {
}

export const PrintReceiptButton = (props: PrintReceiptButtonProps) => {

    const dispatch = useAppDispatch();

    const onPrint = (e: any) => {
        e.preventDefault();

        dispatch(setReceipt(props));
        dispatch(printReceipt());
    }

    return <button className='submit-button' onClick={onPrint}>Print receipt</button>
}