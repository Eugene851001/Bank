export interface UserDTO {
    name: string;
    surname: string;
    lastname: string;
    birthDate: Date;
    sex: boolean;
    passportSeries: string;
    passportNumber: string;
    issuedBy: string;
    issuedDate: Date;
    passportId: string;
    birthPlace: string;
    residenceCity: number;
    residenceAddress: string;
    maritalStatus: number;
    citizenship: number;
    disability: number;
    isRetiree: boolean;
    monthlyIncome?: number;
    isConscripted: boolean;
    homePhone?: string;
    mobilePhone?: string;
    email?: string;
}