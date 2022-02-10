import React from 'react';
import { CreditDTO } from '../Models/CreditDTO';
import { DepositDTO } from '../Models/DepositDTO';
import { UserDTO } from '../Models/UserDTO';
import { PaymentDTO } from '../Models/PaymentDTO';
import { AccountsView } from './AccountsView';
import { CloseDayFrom } from './CloseDayForm';
import { DateUtils } from '../utils/DateUtils';
import { AccountDTO } from '../Models/AccountDTO';
import { Payments } from './Payments';

export interface ContractViewProps {
    user?: UserDTO;
    contract?: DepositDTO | CreditDTO;
    accounts?: AccountDTO[];
    report?: PaymentDTO[];
    onCloseDay?: () => void;
}

export const ContractView = ({user, contract, accounts, report, onCloseDay}: ContractViewProps) => {

    let contractType = '';
    if (contract) {
        if ('revocable' in contract) {
            contractType = contract.revocable ? 'Отзывной' : 'Безотзывной';
        } else {
            contractType = contract.annuity ? 'Аннуитетный' : 'Диффренциальный';
        }
    }

    return (
        <>
         {user ? 
            <>
                <p>Владелец: {user.name} {user.surname} {user.lastname}</p>
            </> : ''}
            {contract ? <>
                <p>Дата начала: {DateUtils.dateFormat(contract.startDate)}</p> 
                <p>Дата окончания: {DateUtils.dateFormat(contract.endDate)}</p>
                <p>{contractType}</p>
                <p>Сумма: {contract.sum}</p>
                <p>Проценты: {contract.percent}</p>
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
                <CloseDayFrom onClose={onCloseDay}/>
            </div>
        </>
           
    );
}