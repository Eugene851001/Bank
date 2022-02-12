import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Constants } from '../Contants/Constants';
import { DepositPlanDTO } from '../Models/DepositPlanDTO';
import { UserDTO } from '../Models/UserDTO';
import { DeposistsService } from '../Services/DeposistsService';
import { UsersService } from '../Services/UsersService';
import { DepositPlan } from './DepositPlan';
import { Link } from 'react-router-dom';
import { CreateDepositRequest } from '../Models/CreateDepositRequest';
import './UserDetailsView.style.css';
import './ContractsForm.css';
import { ContractView } from './ContractView';
import { ContractForm } from './ContractForm';
import { ErrorDTO } from '../Models/ErrorDTO';

export const DepositForm = () => {
    const { userId } = useParams();
    const [contract, setContract] = useState<CreateDepositRequest>({...Constants.Contracts.getNewItem(), depositPlan: 1});
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
                const errorInfo: ErrorDTO = await response.json();
                alert(`Contract can not be added: ${errorInfo.message}`);
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


    return ( 
        <>
            <Link to="/">Пользователи</Link>
            <form className='main-form'>
                <ContractForm user={user} contract={contract} onChange={onChange} onChangeDate={onChangeDate} />
                <h2>Программы</h2>
                <table className="plans-table">
                    <tr><th>Имя</th><th>Отзывной?</th><th>Срок</th><th>Валюта</th><th>Процент</th><th>Онлайн</th></tr>
                    {plans ? 
                    plans.map(plan => 
                        <DepositPlan key={plan.id} plan={plan} onSelect={onSelectPlan}/>
                        ) : 
                        ''
                    }
                </table>
                <input type="submit" className="submit-button" value="Оформить" onClick={e => onSubmit(e)}/>
            </form>
        </>
        );
}