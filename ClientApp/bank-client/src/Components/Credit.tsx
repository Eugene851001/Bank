import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { AccountDTO } from "../Models/AccountDTO";
import { PaymentDTO } from "../Models/PaymentDTO";
import { Link } from "react-router-dom";
import './Deposit.css';
import { AccountsService } from "../Services/AccountsService";
import { UserDTO } from "../Models/UserDTO";
import { UsersService } from "../Services/UsersService";
import { ContractView } from "./ContractView";
import { CreditsService } from "../Services/CreditsService";
import { CreditDTO } from "../Models/CreditDTO";

export const Credit = () => {

    const { creditId } = useParams();
    const [accounts, setAccounts] = useState<AccountDTO[]>();
    const [credit, setCredit] = useState<CreditDTO>();
    const [user, setUser] = useState<UserDTO>()

    const [report, setReport] = useState<PaymentDTO[]>();

    async function loadData() {
        if (!creditId) return;

        const [bankAccount, responseAccounts, responseContract] = await Promise.all([
            AccountsService.getBankAccount(),
            CreditsService.getAccounts(+creditId),
            CreditsService.getSignle(+creditId),
        ]);

        if (!user) {
            const responseUser = await UsersService.getUser(responseAccounts[1].owner);

            setUser(responseUser);
        }

        setAccounts([...responseAccounts, bankAccount]);
        setCredit(responseContract);
    }

    useEffect(() => {
        loadData();

    }, []);

    const onGenerateReport = async (e: any) => {
        e.preventDefault();
        if (!creditId) return;

        const response = await CreditsService.getReport(+creditId);

        setReport(response);
    }

    return (
        <>
            <Link to="/credits">Кредиты</Link>
            <div className="deposit-info">
                <div>
                    <ContractView user={user} contract={credit} accounts={accounts} report={report} onCloseDay={loadData}/>
                    <div className="deposit-buttons">
                        <button onClick={onGenerateReport}>Сгенерировать график</button>
                    </div>
                </div>  
            </div>
        </>
    );
}