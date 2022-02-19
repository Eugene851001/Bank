import { useAppSelector } from "."; 

export const useAccount = () => {
    const account = useAppSelector(state => state.account);
    
    return account;
}

export const usePayment = () => {

    const sum = useAppSelector(state => state.account.transferSum);
    const destinaton = useAppSelector(state => state.account.destinationAccount);

    return { sum, destinaton };
}