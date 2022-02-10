import { CreateContractRequest } from "./CreateContractRequest";

export interface CreateDepositRequest extends CreateContractRequest {
    depositPlan: number;
}