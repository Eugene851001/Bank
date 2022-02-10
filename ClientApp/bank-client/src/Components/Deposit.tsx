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
import { UserDemo } from "../Models/UserDemo";
import { UserDTO } from "../Models/UserDTO";
import { UsersService } from "../Services/UsersService";
import { ContractView } from "./ContractView";

export const Deposit = () => {

    const {currentDate, setCurrentDate } = useCurrentDate(); 
    const { depositId } = useParams();
    const [accounts, setAccounts] = useState<AccountDTO[]>();
    const [deposit, setDeposit] = useState<DepositDTO>();
    const [user, setUser] = useState<UserDTO>()

    const [report, setReport] = useState<PaymentDTO[]>();

    async function loadData() {
        if (!depositId) return;

        const [bankAccount, responseAccounts, responseDeposit] = await Promise.all([
            AccountsService.getBankAccount(),
            DeposistsService.getAccounts(+depositId),
            DeposistsService.getSignle(+depositId),
        ]);

        if (!user) {
            const responseUser = await UsersService.getUser(responseAccounts[1].owner);

            setUser(responseUser);
        }

        setAccounts([...responseAccounts, bankAccount]);
        setDeposit(responseDeposit);
    }

    useEffect(() => {
        loadData();

    }, []);

    const performOperation = async (operation: () => Promise<Response>) => {
        const response = await operation();
        
        if (response.status == 200) {
            alert('Operation has been performed');
            loadData();
        } else {
            const errorInfo = await  response.json();
            alert(`Somethig went wrong: ${errorInfo.message}`)
        }
    }

    const onWithdrawPercents = async (e: any) => {
        e.preventDefault();

        if (!depositId || !accounts) return;
        
        performOperation(() =>  DeposistsService.withdrawPercents({depositId: +depositId, currentDate}));
    }

    const onCloseDeposit = async (e: any) => {
        e.preventDefault();

        if (!depositId) return;

        performOperation(() => DeposistsService.closeDeposit({contractId: +depositId, currentDate}));
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
                    <ContractView user={user} contract={deposit} accounts={accounts} report={report} onCloseDay={loadData}/>
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