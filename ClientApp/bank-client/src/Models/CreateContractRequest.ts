
export interface CreateContractRequest {
    user: number;
    accountCode: string;
    startDate: Date;
    endDate: Date;
    sum: number;
    percent: number;
    currency: number;
    depositType: number;
}