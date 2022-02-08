import React from 'react';
import { DepositPlanDTO } from '../Models/DepositPlanDTO';

export interface DepositPlanProps {
    plan: DepositPlanDTO;
    onSelect: (id: number) => void;
}

export const DepositPlan = ({ plan, onSelect }: DepositPlanProps) => {

    return (<tr>
        <td><input type="radio" name="plan" id={`plan${plan.id}`} onChange={() => onSelect(plan.id)}/><label htmlFor={`plan${plan.id}`}>{plan.name}</label>
        </td>
        <td>{plan.revocable ? 'Отзывной' : 'Безотзывной'}</td>
        <td>{plan.duration}</td>
        <td>{plan.currency}</td>
        <td>{plan.percent}</td>
        <td>{plan.online ? 'Онлайн' : 'В офисе'}</td>
    </tr>);
}