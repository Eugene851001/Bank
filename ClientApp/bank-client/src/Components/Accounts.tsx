import React, { useEffect, useState } from "react";
import { Constants } from "../Contants/Constants";
import { AccountDTO } from "../Models/AccountDTO";
import { AccountsService } from "../Services/AccountsService";
import { Account } from "./Account";
import { AccountsView } from "./AccountsView";
import { CloseDayFrom } from "./CloseDayForm";
import { Link } from "react-router-dom";
import './UserDetailsView.style.css'

export const Accounts = () => {

    const [accounts, setAccounts] = useState<AccountDTO[]>();
    
    async function loadData() {
        const response = await AccountsService.getAccounts();

        setAccounts(response);
    }

    useEffect(() => {
        loadData();
    }, []);

    return accounts ? 
        <>
            <Link to="/">Пользователи</Link>
            <div className="main-form">
                <h3>Специальные счета</h3>
                <AccountsView accounts={accounts.filter(ac => ac.accountType == Constants.AccountTypes.bank 
                    || ac.accountType == Constants.AccountTypes.cash)}/>
                <h3>Депозитные счета</h3>
                <AccountsView accounts={accounts.filter(ac => ac.accountType != Constants.AccountTypes.bank
                    && ac.accountType != Constants.AccountTypes.cash && ac.active == 0)}/>
                <h3>Кредитные счета</h3>
                <AccountsView accounts={accounts.filter(ac => ac.accountType != Constants.AccountTypes.bank
                    && ac.accountType != Constants.AccountTypes.cash && ac.active == 1)}/>
                <CloseDayFrom onClose={loadData}/>
            </div>
        </>
        : <p>Loading...</p>;
}