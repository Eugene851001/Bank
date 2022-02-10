import { CreateContractRequest } from "./CreateContractRequest";

export interface CreateCreditRequest extends CreateContractRequest {
    creditPlan: number;
}