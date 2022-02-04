import React, { useState } from 'react';
import { Constants } from '../Contants/Constants';
import { CreateContractRequest } from '../Models/CreateContractRequest';
import { ContractsService } from '../Services/ContractsService';
import { DateUtils } from '../utils/DateUtils';
import { FieldData } from '../utils/FieldData';
import { nameOf } from '../utils/NameOf';
import { CurrenciesDropdown } from './Dropdown/CurrenciesDropdown';

export const ContractsForm = () => {
 
    const [contract, setContract] = useState<CreateContractRequest>(Constants.Contracts.newItem);

    const onSubmit = async (e: any) => {
        e.preventDefault();

        if (contract) {
            const response = await ContractsService.addContract(contract);
            if (response.status == 200) {
                alert('Contract has been added');
            } else {
                alert('Contract can not be added');
            }
        }
    }

    const onChangeDate = (e: any, property: string) => {
        const value = new Date(e.target.value);

        setContract({...contract, [property]: value});
    };


    const onChange = (e: any, property: string) => {
        const value = e.target.value;

        setContract({...contract, [property]: value});
    }

    const fields: FieldData[] = [
        {
            label: 'Пользователь',
            element: <input type="number" value={contract.user} onChange={e => onChange(e, nameOf<CreateContractRequest>('user'))} />
        },
        {
            label: 'Номер счёта',
            element: <input type="text" value={contract.accountNumber} onChange={e => onChange(e, nameOf<CreateContractRequest>('accountNumber'))} />
        },
        {
            label: 'Код',
            element:  <input type="text" value={contract.accountCode} onChange={e => onChange(e, nameOf<CreateContractRequest>('accountCode'))} />
        },
        {
            label: 'Дата начала',
            element: <input type="date" value={DateUtils.dateFormat(contract.startDate)} onChange={e => onChangeDate(e, nameOf<CreateContractRequest>('startDate'))} />
        },
        {
            label: 'Дата окончания',
            element: <input type="date" value={DateUtils.dateFormat(contract.endDate)} onChange={e => onChangeDate(e, nameOf<CreateContractRequest>('endDate'))}/> 
        },
        {
            label: 'Процент',
            element: <input type="number" value={contract.percent} onChange={e => onChange(e, nameOf<CreateContractRequest>('percent'))}/>
        },
        {
            label: 'Суммма',
            element:  <input type="number" value={contract.sum} onChange={e => onChange(e, nameOf<CreateContractRequest>('sum'))}/>
        },
        {
            label: 'Валюта',
            element: (
                <CurrenciesDropdown 
                    selectedId={contract.currency} 
                    onChange={e => onChange(e, nameOf<CreateContractRequest>('currency'))}
                />)
        }
    ];

    return ( 
        <form>
            <table>
                    {fields.map(f => 
                        <tr>
                            <td>{f.label}</td>
                            <td className={f.required ? 'required' : ''}>{f.element}</td>
                        </tr>)}
                </table>
            <input type="submit" onClick={e => onSubmit(e)}/>
        </form>);
}