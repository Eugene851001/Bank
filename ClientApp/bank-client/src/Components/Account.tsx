import React from "react";
import { AccountDTO } from "../Models/AccountDTO";

export interface AccountProps extends AccountDTO { 

}

export const Account = (props: AccountProps) => {

    return (<p>Number: {props.number} Balance: {props.balance} UserId {props.owner}</p>);
}