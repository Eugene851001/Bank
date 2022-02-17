import { LoginRequest } from "../Models/LoginRequest";

export const CardService = class {

    public static login(request: LoginRequest): Promise<Response> {
        return fetch('/api/atm/login', {
            method: 'POST',
            body: JSON.stringify(request),
        });
    }

}