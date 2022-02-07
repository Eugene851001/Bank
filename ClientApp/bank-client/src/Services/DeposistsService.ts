import { CreateContractRequest } from "../Models/CreateContractRequest"
import { CloseDayRequest } from "../Models/CloseDayRequest";
import { WithdrawPercentsRequest } from "../Models/WithdrawPercentsRequest";
import { CloseDepositRequest } from "../Models/CloseDepositRequest";

type DepositsOperation = 
    CloseDayRequest
    | WithdrawPercentsRequest
    | CloseDepositRequest;


export const DeposistsService = class {
    
    public static addContract(request: CreateContractRequest) {
        return fetch('/api/deposits', {
            method: 'POST', 
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request)
        })
    }

    public static getAll() {
        return fetch('/api/deposits').then(response => response.json());
    }

    public static getAccounts(id: number) {
        return fetch(`/api/deposits/${id}/accounts`).then(response => response.json());
    }

    public static getReport(id: number) {
        return fetch(`/api/deposits/${id}/report`).then(response => response.json());
    }

    public static getSignle(id: number) {
        return fetch(`/api/deposits/${id}`).then(response => response.json());
    }

    public static closeDay(request: CloseDayRequest) {
        return DeposistsService.performPutRequest('closeDay', request);
    }

    public static withdrawPercents(request: WithdrawPercentsRequest) {
        return DeposistsService.performPutRequest('withdrawPercents', request);
    }

    public static closeDeposit(request: CloseDepositRequest) {
        return DeposistsService.performPutRequest('closeDeposit', request);
    }

    // private stastic performGetRequest(controller: string) {
    //     return fetch(`/api/deposits/${controller}`)
    // }

    private static performPutRequest(operation: string, request: DepositsOperation) {
        return fetch(`/api/deposits/${operation}`, {
            method: 'PUT',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request),
        })
    }
}