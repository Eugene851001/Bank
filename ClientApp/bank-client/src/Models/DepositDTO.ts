import { ContractDTO } from "./ContractDTO";

export interface DepositDTO extends ContractDTO{
    revocable: boolean;
}