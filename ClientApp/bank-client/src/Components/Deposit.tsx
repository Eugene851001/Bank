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
import { AccountsView } from "./AccountsView";
import { Link } from "react-router-dom";
import './Deposit.css';
import { DateUtils } from "../utils/DateUtils";
import { AccountsService } from "../Services/AccountsService";

export const Deposit = () => {

    const {currentDate, setCurrentDate } = useCurrentDate(); 
    const { depositId } = useParams();
    const [accounts, setAccounts] = useState<AccountDTO[]>();
    const [deposit, setDeposit] = useState<DepositDTO>();

    const [report, setReport] = useState<PaymentDTO[]>();

    async function loadData() {
        if (!depositId) return;

        const [bankAccount, responseAccounts, responseDeposit] = await Promise.all([
            AccountsService.getBankAccount(),
            DeposistsService.getAccounts(+depositId),
            DeposistsService.getSignle(+depositId),
        ]);

        setAccounts([...responseAccounts, bankAccount]);
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
            loadData();
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
            loadData();
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
            <Link to="/deposits">Депозиты</Link>
            <div className="deposit-info">
                <div>
                    {deposit ? <>
                        <p>Дата начала: {DateUtils.dateFormat(deposit.startDate)}</p> 
                        <p>Дата окончания: {DateUtils.dateFormat(deposit.endDate)}</p>
                        <p>{deposit.revocable ? 'Отзывной' : 'Безотзывной'}</p>
                        <p>Сумма: {deposit.sum}</p>
                        <p>Проценты: {deposit.percent}</p>
                    </>
                    : ''}
                    {accounts ? 
                    <>
                        <h2>Счета</h2>
                        <AccountsView accounts={accounts}/>
                    </>
                    : <p>Loading accounts...</p>}
                    {report ?<><h2>Платежи</h2><Payments payments={report}/></> : ''}
                    <div className="deposit-close-day">
                        <CloseDayFrom onClose={loadData}/>
                    </div>
                    <div className="deposit-buttons">
                        <button onClick={e => onWithdrawPercents(e)}>Снять проценты</button>
                        <button onClick={(e => onCloseDeposit(e))}>Закрыть депозит</button>
                        <button onClick={onGenerateReport}>Сгенерировать отчёт</button>
                    </div>
                </div>  
            </div>
        </>
    );
}