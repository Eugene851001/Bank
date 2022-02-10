import React from "react";
import { AccountDTO } from "../Models/AccountDTO";

export interface AccountProps extends AccountDTO { 

}

export const Account = (props: AccountProps) => {

    const typeToName = new Map<number, string>([
        [1, 'Основной'],
        [2, 'Кредитный'],
        [3, 'Касса банка'],
        [4, 'Фонд развития банка'],
    ]);

    return (
    <tr>
        <td>
            {props.number}
        </td>
        <td>
            {props.balance}
        </td>
        <td>
            {typeToName.get(props.accountType)}
        </td>
    </tr>);
}