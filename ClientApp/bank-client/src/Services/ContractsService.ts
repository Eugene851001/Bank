import { CreateContractRequest } from "../Models/CreateContractRequest"

export const ContractsService = class {
    
    public static addContract(request: CreateContractRequest) {
        return fetch('/api/contracts', {
            method: 'POST', 
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request)
        })
    }
}