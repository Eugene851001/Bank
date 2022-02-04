import React, { useEffect, useState } from "react";
import { AccountDTO } from "../Models/AccountDTO";
import { AccountsService } from "../Services/AccountsService";
import { Account } from "./Account";

export const Accounts = () => {

    const [accounts, setAccounts] = useState<AccountDTO[]>();

    useEffect(() => {
        async function loadData() {
            const response = await AccountsService.getAccounts();

            setAccounts(response);
        }

        loadData();
    }, []);

    return accounts ? 
        <ul>
            {accounts.map(ac => <li><Account {...ac} /></li>)}
        </ul> : <p>Loading...</p>;
}