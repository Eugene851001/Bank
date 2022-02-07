
export interface CreateContractRequest {
    user: number;
    startDate: Date;
    endDate: Date;
    sum: number;
    percent: number;
    currency: number;
    revocable: boolean;
}