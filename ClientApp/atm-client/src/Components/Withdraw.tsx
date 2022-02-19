import React, { useEffect, useState } from "react";
import { useAppDispatch } from "../Hooks";
import { useAccount } from "../Hooks/useAccount";
import { useNavigation } from "../Hooks/useNavigation";
import { setWithdrawSucess } from "../Store/AccountSlice";
import { withdrawMoney } from "../Store/Actions/AccountActions";
import { setCardPin } from "../Store/CardSlice";
import { PagesId, setCurrentPage } from "../Store/NavigationSlice";
import { PrintReceiptButton } from "./PrintReceiptButton";
import { ReturnButton } from "./ReturnButton";

export const Withdraw = () => {

    const [sum, setSum] = useState();

    const dispatch = useAppDispatch();

    const { currentPage } = useNavigation();
    const { phase } = currentPage;

    const onEnterSum = (e: any) => {

        setSum(e.target.value);
    }

    const onSubmit = (e: any) => {
        e.preventDefault();

        if (sum) {
            dispatch(withdrawMoney(sum));
        }
    }   

    return (
        <>
            {
                phase == 0 && 
                    <form>
                        <input type="number" value={sum} onChange={onEnterSum}/>
                        <button onClick={onSubmit}>Withdraw</button>
                    </form>
            }
            {
                phase == 1 && 
                    <>
                        <p>Money has been withdrawed</p>
                        <ReturnButton />
                        {sum && <PrintReceiptButton operation="Withdraw" sum={sum} date={new Date()}/>}
                    </>
            }
        </>);
}