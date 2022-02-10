export interface CreditPlanDTO {
    id:  number;
    name: string;
    currency: number;
    duration: number;
    annuity: boolean;
    percent: number;
    object: string;
    minValue: number;
}