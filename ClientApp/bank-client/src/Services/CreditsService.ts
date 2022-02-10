import { CreateContractRequest } from "../Models/CreateContractRequest";
import { CreateCreditRequest } from "../Models/CreateCreditRequest";

export const CreditsService = class {

    public static addContract(request: CreateContractRequest) {
        return fetch('/api/credits', {
            method: 'POST', 
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request)
        })
    }

    public static getAll() {
        return fetch('/api/credits').then(response => response.json());
    }

    public static getAccounts(id: number) {
        return fetch(`/api/credits/${id}/accounts`).then(response => response.json());
    }

    public static getReport(id: number) {
        return fetch(`/api/credits/${id}/report`).then(response => response.json());
    }

    public static getSignle(id: number) {
        return fetch(`/api/credits/${id}`).then(response => response.json());
    }

    public static getPlans() {
        return fetch('/api/credits/plans').then(response => response.json());
    }
}