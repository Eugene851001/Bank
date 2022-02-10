import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Constants } from '../Contants/Constants';
import { CreateContractRequest } from '../Models/CreateContractRequest';
import { DepositPlanDTO } from '../Models/DepositPlanDTO';
import { UserDemo } from '../Models/UserDemo';
import { UserDTO } from '../Models/UserDTO';
import { DeposistsService } from '../Services/DeposistsService';
import { UsersService } from '../Services/UsersService';
import { DateUtils } from '../utils/DateUtils';
import { FieldData } from '../utils/FieldData';
import { nameOf } from '../utils/NameOf';
import { DepositPlan } from './DepositPlan';
import { CurrenciesDropdown } from './Dropdown/CurrenciesDropdown';
import { RevocableDropdown } from './Dropdown/RevocableDropdown';
import { Link } from 'react-router-dom';
import { CreateDepositRequest } from '../Models/CreateDepositRequest';
import './UserDetailsView.style.css';
import './ContractsForm.css';
import { ContractDTO } from '../Models/ContractDTO';

export interface ContractFormProps {
    user: UserDTO;
    contract: CreateContractRequest;
    onChange: (e:any, field: string) => void;
    onChangeDate: (e: any, field: string) => void;
}

export const ContractForm = ({user, contract, onChange, onChangeDate}: ContractFormProps) => {

    const fields: FieldData[] = [
        {
            label: 'Фамилия',
            element: <input type="text" value={user.lastname} />
        },
        {
            label: 'Имя',
            element: <input type="text" value={user.name} /> 
        },
        {
            label: 'Отчество',
            element: <input type="text" value={user.surname} />
        },
        {
            label: 'Дата начала',
            element: <input type="date" value={DateUtils.dateFormat(contract.startDate)} onChange={e => onChangeDate(e, nameOf<CreateContractRequest>('startDate'))} />
        },
        {
            label: 'Суммма',
            element:  <input type="number" value={contract.sum} onChange={e => onChange(e, nameOf<CreateContractRequest>('sum'))}/>
        },
    ];

    return ( 
                <table>
                        {fields.map(f => 
                            <tr>
                                <td>{f.label}</td>
                                <td className={f.required ? 'required' : ''}>{f.element}</td>
                            </tr>)}
                </table>
        );
}