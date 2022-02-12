import React from 'react';
import { DepositPlanDTO } from '../Models/DepositPlanDTO';
import { CreditPlanDTO } from '../Models/CreditPlanDTO';

export interface CreditPlanProps {
    plan: CreditPlanDTO;
    onSelect: (id: number) => void;
}

export const CreditPlan = ({ plan, onSelect }: CreditPlanProps) => {

    return (<tr>
        <td><input type="radio" name="plan" id={`plan${plan.id}`} onChange={() => onSelect(plan.id)}/><label htmlFor={`plan${plan.id}`}>{plan.name}</label>
        </td>
        <td>{plan.annuity ? 'Аннуитетный' : 'Дифференцированный'}</td>
        <td>{plan.duration}</td>
        <td>{plan.currency}</td>
        <td>{plan.percent}</td>
        <td>{plan.object}</td>
        <td>{plan.minValue}</td>
    </tr>);
}