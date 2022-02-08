import { SystemVariableDTO } from "../Models/SystemVariableDTO"

export const SystemService = class {
    public static getCurrentTime(): Promise<SystemVariableDTO> {
        return fetch('/api/system').then(reponse => reponse.json());
    }

    public static updateCurrentTime() {
        return fetch('');
    }
}