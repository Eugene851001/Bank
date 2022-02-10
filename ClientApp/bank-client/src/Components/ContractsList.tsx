import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { ContractDTO } from "../Models/ContractDTO";
import { DepositDemo } from "../Models/DepositDemo";
import { DeposistsService } from "../Services/DeposistsService";
import { DateUtils } from "../utils/DateUtils";

export interface ContractsListProps {
    getContracts: () => Promise<any>;
    contractType: string;
}

export const ContractsList = (props: ContractsListProps) => {
    const [contracts, setContracts] = useState<ContractDTO[]>();

    useEffect(() => {
        async function loadData() {
            const response = await props.getContracts();

            setContracts(response);
        }

        loadData();
    }, []);

    return contracts ? (
        <>
            <Link to="/">Пользователи</Link>
            <ul>
                {contracts.map(deposit => 
                    <li>
                       <Link to={`/${props.contractType}/${deposit.id}`}>
                        {deposit.id}: {DateUtils.dateFormat(deposit.startDate)}-{DateUtils.dateFormat(deposit.endDate)}
                       </Link>
                    </li>)}
            </ul>
        </>) : <p>Loading contracts...</p>
}