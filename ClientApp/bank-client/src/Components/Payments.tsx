import React from 'react';
import { PaymentDTO } from '../Models/PaymentDTO';

export interface PaymentsProps {
    payments: PaymentDTO[];
}

export const Payments = (props: PaymentsProps) => {

    return <table>
        <tr><th>Дата</th><th>Сумма</th></tr>
        {props.payments.map(payment => 
            <tr>
                <td>{payment.date}</td>
                <td>{payment.sum}</td>
            </tr>)}
    </table>
}