import React from 'react';
import { PaymentDTO } from '../Models/PaymentDTO';
import { DateUtils } from '../utils/DateUtils';

export interface PaymentsProps {
    payments: PaymentDTO[];
}

export const Payments = (props: PaymentsProps) => {

    return <table>
        <tr><th>Дата</th><th>Сумма</th></tr>
        {props.payments.map(payment => 
            <tr>
                <td>{DateUtils.dateFormat(payment.date)}</td>
                <td>{payment.sum}</td>
            </tr>)}
    </table>
}