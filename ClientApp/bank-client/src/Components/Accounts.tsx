import React, { useEffect, useState } from "react";
import { AccountDTO } from "../Models/AccountDTO";
import { AccountsService } from "../Services/AccountsService";
import { Account } from "./Account";
import { AccountsView } from "./AccountsView";
import { CloseDayFrom } from "./CloseDayForm";

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
            <AccountsView accounts={accounts}/>
            <CloseDayFrom onClose={loadData}/>
        </>
        : <p>Loading...</p>;
}