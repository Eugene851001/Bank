import { ContractDTO } from "./ContractDTO";

export interface CreditDTO extends ContractDTO {
    annuity: boolean;
}