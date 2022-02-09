import { SystemVariableDTO } from "../Models/SystemVariableDTO"

export const SystemService = class {
    public static getCurrentTime(): Promise<SystemVariableDTO> {
        return fetch('/api/system').then(reponse => reponse.json());
    }

    public static updateCurrentTime(system: SystemVariableDTO) {
        return fetch('/api/system', {
            method: 'POST', 
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(system)
        });
    }
}