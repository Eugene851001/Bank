import { CreateContractRequest } from "../Models/CreateContractRequest";

export interface IContractService {
    addContract(request: CreateContractRequest): Promise<any>;
    getSingle(): Promise<any>;
    getAccounts(id: number): Promise<any>;
    getReport(id: number): Promise<any>;
    getSignle(id: number): Promise<any>;
    getPlans(): Promise<any>;
}