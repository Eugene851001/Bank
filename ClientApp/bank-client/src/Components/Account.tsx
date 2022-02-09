import React from "react";
import { AccountDTO } from "../Models/AccountDTO";

export interface AccountProps extends AccountDTO { 

}

export const Account = (props: AccountProps) => {

    return (
    <tr>
        <td>
            {props.number}
        </td>
        <td>
            {props.balance}
        </td>
        <td>
            {props.owner ? 'Пользовательский' : 'Системный'}
        </td>
    </tr>);
}