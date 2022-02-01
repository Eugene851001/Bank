import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { UserDTO } from '../Models/UserDTO';
import { UsersService } from '../Services/UsersService';
import { UserDetailsView } from './UserDetailsView';

interface IUserParams {
    userId: string;
}

export const UserDetails = () => {

    const [user, setUser] = useState<UserDTO>();
    const [loaded, setLoaded] = useState(false);

    const {userId} = useParams();

    useEffect(() => {
        async function loadData() {
            if (userId) {  
                const response = await UsersService.getUser(+userId);

                setUser({...response, birthDate: new Date(response.birthDate), issuedDate: new Date(response.issuedDate)});
            }

            setLoaded(true);
        }

        loadData();
    }, []);

    return loaded && userId ? <UserDetailsView data={user} userId={+userId}/> : <p>Loading...</p>;
}