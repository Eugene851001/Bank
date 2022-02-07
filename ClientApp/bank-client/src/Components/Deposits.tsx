import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { DepositDemo } from "../Models/DepositDemo";
import { DeposistsService } from "../Services/DeposistsService";

export const Deposits = () => {
    const [deposits, setDeposits] = useState<DepositDemo[]>();

    useEffect(() => {
        async function loadData() {
            const response = await DeposistsService.getAll();

            setDeposits(response);
        }

        loadData();
    }, []);

    return deposits ? (
        <>
            <ul>
                {deposits.map(deposit => 
                    <li>
                       <Link to={`/Deposits/${deposit.id}`}>
                        {deposit.id}: {deposit.startDate}-{deposit.endDate}
                       </Link>
                    </li>)}
            </ul>
        </>) : <p>Loading deposits...</p>
}