import React from 'react';
import { AccountDTO } from '../Models/AccountDTO';
import { Account } from './Account';

export interface AccountViewProps {
    accounts: AccountDTO[];
}

export const AccountsView = ({accounts}: AccountViewProps) => {
    return ( 
        <table>
        <tr><th>Номер счёта</th><th>Баланс</th><th>Дебит</th><th>Кредит</th><th>Тип счёта</th></tr>
        {accounts.map(ac => <Account {...ac} />)}
     </table>);
}