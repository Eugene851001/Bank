import React, { useState } from 'react';
import { useAppDispatch } from '../Hooks';
import { useNavigation } from '../Hooks/useNavigation';
import { setDestinationAcount, setTransferSum } from '../Store/AccountSlice';
import { transferMoney } from '../Store/Actions/AccountActions';
import { PagesId, setCurrentPage } from '../Store/NavigationSlice';
import { PrintReceiptButton } from './PrintReceiptButton';
import { ReturnButton } from './ReturnButton';
import './General.css';

export const Payment = () => {
    const { currentPage } = useNavigation();

    const [destination, setDestination] = useState('');
    const [sum, setSum] = useState(0);

    const dispatch = useAppDispatch();

    const onChangeDestination = (e: any)  => {
        setDestination(e.target.value);
    }

    const onSubmitDestination = (e: any) => {
        e.preventDefault();

        dispatch(setDestinationAcount((destination)));
        dispatch(setCurrentPage({id: PagesId.Payments, phase: 1}));
    }

    const onChangeSum = (e: any) => {
        setSum(e.target.value);
    }

    const onSubmitSum = (e: any) => {
        e.preventDefault();

        dispatch(setTransferSum(sum));
        dispatch(transferMoney());
    }

    return (
        <>
            {currentPage.phase == 0 && <>
                <form className='flex-container'>
                    <p>Destination account</p>
                    <input type="number" onChange={onChangeDestination} />
                    <button onClick={onSubmitDestination}>Submit</button>
                </form>
            </>}
            {currentPage.phase == 1 && <>
                <form className='flex-container'>
                    <p>Sum</p>
                    <input type="number" onChange={onChangeSum}/>
                    <button onClick={onSubmitSum}>Submit</button>
                </form>
            </>}
            {currentPage.phase == 2 && <div className='flex-container'>
                <p>Operation has been performed</p>
                <ReturnButton />
                <PrintReceiptButton operation='Transfer' sum={+sum} date={new Date()}/>
            </div>
            }
        </>);
}