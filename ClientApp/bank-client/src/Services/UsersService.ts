import { AddUserResponse } from "../Models/AddUserResponse";
import { ErrorDTO } from "../Models/ErrorDTO";
import { UpdateUserRequest } from "../Models/UpdateUserRequest";
import { UserDemo } from "../Models/UserDemo";
import { UserDTO } from "../Models/UserDTO";

export const UsersService = class {

    public static getUsers(): Promise<UserDemo[]> {
        return fetch('/api/Users').then(response => response.json());
    }

    public static getUser(id: number): Promise<UserDTO> {
        return fetch(`/api/Users/${id}`).then(response => response.json());
    }

    public static addUser(user: UserDTO){
        return fetch('/api/users', {
            method: 'POST', 
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user)
        });
    }

    public static updateUser(request: UpdateUserRequest) {
        return fetch(`/api/users`, {
            method: 'PUT', 
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request)
        })
    }

    public static DeleteUser(id: number) {
        return fetch(`/api/users/${id}`, {method: 'DELETE'});
    }
}