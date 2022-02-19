import { GetBalanceResponse } from "../Models/GetBalanceResponse";
import { LoginRequest } from "../Models/LoginRequest";
import { TRansferMoneyRequest } from "../Models/TransferMoneyRequest";
import { withdrawMoneyRequest } from "../Models/WithdrawMoneyRequest";

export const CardService = class {

    public static login(request: LoginRequest): Promise<Response> {
        return fetch('/api/atm/login', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request),
        });
    }

    public static getBalance(cardNumber: string): Promise<GetBalanceResponse> {
        return fetch(`/api/atm/balance/${cardNumber}`).then(response => response.json());
    }

    public static withdrawMoney(request: withdrawMoneyRequest) {
        return fetch('/api/atm/withdraw', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request) 
        });
    }

    public static transferMoney(request: TRansferMoneyRequest) {
        return fetch('/api/atm/transfer', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request),
        });
    }

}