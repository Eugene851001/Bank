import React, { useEffect, useState } from "react";
import { useAppDispatch } from "../Hooks";
import { useAccount } from "../Hooks/useAccount";
import { useNavigation } from "../Hooks/useNavigation";
import { setWithdrawSucess, setWithdrawSum } from "../Store/AccountSlice";
import { withdrawMoney } from "../Store/Actions/AccountActions";
import { setCardPin } from "../Store/CardSlice";
import { PagesId, setCurrentPage } from "../Store/NavigationSlice";
import { PrintReceiptButton } from "./PrintReceiptButton";
import { ReturnButton } from "./ReturnButton";
import './General.css';
import { ErrorMessage } from "./ErrorMessage";
import { useCardData } from "../Hooks/useCard";

export const Withdraw = () => {

    const [sum, setSum] = useState();

    const { withdrawSum, withdrawError } = useAccount();
    const { number: account } = useCardData();
    const dispatch = useAppDispatch();

    const { currentPage } = useNavigation();
    const { phase } = currentPage;

    const onEnterSum = (e: any) => {

        setSum(e.target.value);
    }

    const onSubmit = (e: any) => {
        e.preventDefault();

        if (sum) {
            dispatch(setWithdrawSum(sum));
            dispatch(withdrawMoney());
        }
    }   

    return (
        <>
            {
                phase == 0 && 
                    <form className="vertical-container">
                        <p>Sum</p>
                        <input type="number" value={sum} onChange={onEnterSum}/>
                        <button className="submit-button" onClick={onSubmit}>Withdraw</button>
                    </form>
            }
            {
                phase == 1 && 
                    <div className="vertical-container">
                        <p>Money has been withdrawed</p>
                        <div className="horizontal-container">
                            <ReturnButton />
                            {<PrintReceiptButton operation="Withdraw" sum={withdrawSum || 0} date={new Date()}/>}
                        </div>
                    </div>
            }
            {
                phase == 2 && <ErrorMessage message={withdrawError || ''}/>
            }
        </>);
}