import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Constants } from '../Contants/Constants';
import { DepositPlanDTO } from '../Models/DepositPlanDTO';
import { UserDTO } from '../Models/UserDTO';
import { DeposistsService } from '../Services/DeposistsService';
import { UsersService } from '../Services/UsersService';
import { DepositPlan } from './DepositPlan';
import { Link } from 'react-router-dom';
import './UserDetailsView.style.css';
import './ContractsForm.css';
import { ContractForm } from './ContractForm';
import { CreateCreditRequest } from '../Models/CreateCreditRequest';
import { CreditsService } from '../Services/CreditsService';
import { CreditPlanDTO } from '../Models/CreditPlanDTO';
import { CreditPlan } from './CreditPlan';

export const CreditForm = () => {
    const { userId } = useParams();
    const [contract, setContract] = useState<CreateCreditRequest>({...Constants.Contracts.getNewItem(), creditPlan: 1});
    const [user, setUser] = useState<UserDTO>(Constants.Users.newItem);
    const [plans, setPlans] = useState<CreditPlanDTO[]>();

    useEffect(() => {
        async function loadData() {
            if (!userId) return;

            const [responseUsers, reponsePlans] = await Promise.all([UsersService.getUser(+userId), CreditsService.getPlans()]);
            contract.user = +userId;
            setUser(responseUsers);
            setPlans(reponsePlans);
        }

        loadData();
    }, []);

    const onSubmit = async (e: any) => {
        e.preventDefault();

        if (contract) {
            const response = await CreditsService.addContract(contract);
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
        setContract({...contract, creditPlan: id});
    }


    return ( 
        <>
            <Link to="/">Пользователи</Link>
            <form className='main-form'>
                <ContractForm user={user} contract={contract} onChange={onChange} onChangeDate={onChangeDate} />
                <h2>Программы</h2>
                <table className="plans-table">
                    <tr><th>Имя</th><th>Аннуитентный</th><th>Срок</th><th>Валюта</th><th>Процент</th><th>Цель</th></tr>
                    {plans ? 
                    plans.map(plan => 
                        <CreditPlan key={plan.id} plan={plan} onSelect={onSelectPlan}/>
                        ) : 
                        ''
                    }
                </table>
                <input type="submit" className="submit-button" value="Оформить" onClick={e => onSubmit(e)}/>
            </form>
        </>
        );
}