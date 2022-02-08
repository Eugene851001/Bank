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
import './ContractsForm.css';

export const ContractsForm = () => {
    const { userId } = useParams();
    const [contract, setContract] = useState<CreateContractRequest>(Constants.Contracts.getNewItem());
    const [user, setUser] = useState<UserDTO>(Constants.Users.newItem);
    const [plans, setPlans] = useState<DepositPlanDTO[]>();

    useEffect(() => {
        async function loadData() {
            if (!userId) return;

            const [responseUsers, reponsePlans] = await Promise.all([UsersService.getUser(+userId), DeposistsService.getPlans()]);
            contract.user = +userId;
            setUser(responseUsers);
            setPlans(reponsePlans);
        }

        loadData();
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

    const onSelectPlan = (id: number) => {
        setContract({...contract, depositPlan: id});
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
            label: 'Суммма',
            element:  <input type="number" value={contract.sum} onChange={e => onChange(e, nameOf<CreateContractRequest>('sum'))}/>
        },
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
            <table className="plans-table">
                <tr><th>Имя</th><th>Отзывной?</th><th>Срок</th><th>Валюта</th><th>Процент</th><th>Онлайн</th></tr>
                {plans ? 
                plans.map(plan => 
                    <DepositPlan key={plan.id} plan={plan} onSelect={onSelectPlan}/>
                    ) : 
                    ''
                }
            </table>
            <input type="submit" onClick={e => onSubmit(e)}/>
        </form>);
}