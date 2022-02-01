import { UserDTO } from "../Models/UserDTO"

export const Constants = class {
    public static  Users = class {
        public static get newItem(): UserDTO {
            return {
                name: 'name',
                surname: 'surname',
                lastname: 'lastname',
                birthDate: new Date(),
                sex: false,
                passportSeries: 'KB',
                passportNumber: '1234567',
                issuedBy: 'Stan',
                issuedDate: new Date(),
                passportId: '12345678901234',
                birthPlace: 'Moscow',
                residenceCity: 1,
                residenceAddress: 'sadda',
                maritalStatus: 2,
                citizenship: 1,
                disability: 1,
                isRetiree: false,
                monthlyIncome: 120,
                isConscripted: false
            }
        }
    } 
}