import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useCurrentDate } from "../Contexts/CurrentDateContext";
import { AccountDTO } from "../Models/AccountDTO";
import { DeposistsService } from "../Services/DeposistsService";
import { Account } from "./Account";
import { CloseDayFrom } from "./CloseDayForm";
import { PaymentDTO } from "../Models/PaymentDTO";
import { Payments } from "./Payments";
import { DepositDTO } from "../Models/DepositDTO";

export const Deposit = () => {

    const {currentDate, setCurrentDate } = useCurrentDate(); 
    const { depositId } = useParams();
    const [accounts, setAccounts] = useState<AccountDTO[]>();
    const [deposit, setDeposit] = useState<DepositDTO>();

    const [report, setReport] = useState<PaymentDTO[]>();

    async function loadData() {
        if (!depositId) return;

        const [responseAccounts, responseDeposit] = await Promise.all([
            DeposistsService.getAccounts(+depositId),
            DeposistsService.getSignle(+depositId),
        ]);

        setAccounts(responseAccounts);
        setDeposit(responseDeposit);
    }

    useEffect(() => {
        loadData();
    }, []);

    const onWithdrawPercents = async (e: any) => {
        e.preventDefault();

        if (!depositId || !accounts) return;
        
        const response = await DeposistsService.withdrawPercents({depositId: +depositId, currentDate})
        
        if (response.status == 200) {
            alert('Operation has been performed');
        } else {
            const errorInfo = await  response.json();
            alert(`Somethig went wrong: ${errorInfo.message}`)
        }
    }

    const onCloseDeposit = async (e: any) => {
        e.preventDefault();

        if (!depositId) return;

        const response = await DeposistsService.closeDeposit({contractId: +depositId, currentDate});

        if (response.status == 200) {
            alert('Operation has been performed');
        } else {
            const errorInfo = await  response.json();
            alert(`Something went wrong: ${errorInfo.message}`);
        }
    }

    const onGenerateReport = async (e: any) => {
        e.preventDefault();
        if (!depositId) return;

        const response = await DeposistsService.getReport(+depositId);

        setReport(response);
    }

    return (
        <>
            {accounts ? 
                <ul>
                   {accounts.map(ac => 
                   <li>
                       <Account {...ac} />
                   </li>)}
                </ul>
            : <p>Loading accounts...</p>}
            {report ? <Payments payments={report}/> : ''}
            <CloseDayFrom onClose={loadData}/>
            {deposit ? 
            <p>{deposit.startDate}-{deposit.endDate}</p> : ''}
            <button onClick={e => onWithdrawPercents(e)}>Снять проценты</button>
            <button onClick={(e => onCloseDeposit(e))}>Закрыть депозит</button>
            <button onClick={onGenerateReport}>Сгенерировать отчёт</button>
        </>
    );
}