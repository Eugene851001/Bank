import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Constants } from '../Contants/Constants';
import { CreateContractRequest } from '../Models/CreateContractRequest';
import { UserDemo } from '../Models/UserDemo';
import { UserDTO } from '../Models/UserDTO';
import { DeposistsService } from '../Services/DeposistsService';
import { UsersService } from '../Services/UsersService';
import { DateUtils } from '../utils/DateUtils';
import { FieldData } from '../utils/FieldData';
import { nameOf } from '../utils/NameOf';
import { CurrenciesDropdown } from './Dropdown/CurrenciesDropdown';
import { RevocableDropdown } from './Dropdown/RevocableDropdown';

export const ContractsForm = () => {
    const { userId } = useParams();
    const [contract, setContract] = useState<CreateContractRequest>(Constants.Contracts.getNewItem());
    const [user, setUser] = useState<UserDTO>(Constants.Users.newItem);

    useEffect(() => {
        async function loadUser() {
            if (!userId) return;

            const response = await UsersService.getUser(+userId);
            contract.user = +userId;
            setUser(response);
        }

        loadUser();
    }, []);

    const onSubmit = async (e: any) => {
        e.preventDefault();

        if (contract) {
            const response = await DeposistsService.addContract(contract);
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
    };

    const onChangeRevocable = (e: any) => {
        const value = e.target.value;

        setContract({...contract, revocable: value == 1})
    }

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
        },
        {
            label: 'Отзывной',
            element: <RevocableDropdown selectedId={contract.revocable ? 0 : 1} onChange={e => onChangeRevocable(e)}/>
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