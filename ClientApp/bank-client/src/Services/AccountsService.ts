import { CloseDayRequest } from "../Models/CloseDayRequest";

export const AccountsService = class {
    
    public static getAccounts() {
        return fetch('/api/accounts').then(response => response.json());
    }

    public static getUserAccounts(userId: number) {
        return fetch(`/api/accounts/${userId}`).then(response => response.json());
    }

    public static getBankAccount() {
        return fetch('/api/accounts/bank').then(response => response.json());
    }
}