import { UserDTO } from "./UserDTO";

export interface UpdateUserRequest {
    id: number;
    value: UserDTO;
}