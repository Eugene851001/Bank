import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Constants } from '../Contants/Constants';
import { UserDTO } from '../Models/UserDTO';
import { UsersService } from '../Services/UsersService';
import { nameOf } from '../utils/NameOf';
import { CommonDropdown } from './CommonDropdown';
import { SelectableItemsService } from '../Services/SelectableItemsService';
import './UserDetailsView.style.css';
import { MaritalStatusesDropdown } from './MaritalStatuses';
import { CountriesDropdown } from './CountriesDropdown';

export interface IUserDetailsViewProps {
    data?: UserDTO;
    userId?: number;
}

export const UserDetailsView = (props: IUserDetailsViewProps) => {

    const [user, setUser] = useState(props.data || Constants.Users.newItem);

    const onChange = (e: any, property: string) => {
        const value = e.target.value;

        setUser({...user, [property]: value});
    }

    const toggleCheckbox = (property: string) => {
        setUser({...user, [property]: !(user as any)[property]})
    }

    const onChangeDate = (e: any, property: string) => {
        const value = new Date(e.target.value);

        setUser({...user, [property]: value});
    }

    const isValidForm = () => {
        const form = document.getElementById('user-form');
        for (const field of form?.childNodes || []) {
            if ((field as any).checkValidity && !(field as any).checkValidity()) {
                return false;
            }
        } 

        return true;
    }

    const isValidData = () => {
        const namePattern = /^[a-zA-ZА-Яа-я]+$/

        if (!user.name.match(namePattern) || !user.surname.match(namePattern) || !user.lastname.match(namePattern)) {
            alert('ФИО должно содержать только буквы');
            return false;
        }

        const phonePattern = /^[0-9]{7}$/;

        if (user.mobilePhone && !user.mobilePhone.match(phonePattern)) {
            alert('Мобильнйы телефон должен быть из 7 цифр')
            return false;
        }

        if (user.residenceAddress.length == 0) {
            alert('Адресс проживания явялется обязательным');
            return false;
        }

        const emailPattern = /[a-zA-Z.-]\@/;

        if (user.email && !user.email.match(emailPattern)) {
            alert('Проверьте email');
            return false;
        }

        return true;
    }

    const onUpdate = async (e: any) => {

        if (props.userId && isValidForm()) {
            e.preventDefault();
            await UsersService.updateUser({id: props.userId, value: user});
            alert('User has been updated');
        }
    }

    const onCreate = async (e: any) => {
        e.preventDefault();

        if (isValidData()) {
            await UsersService.addUser(user);
            alert('User has been added');
        }
    }

    const dateFormat = (value: Date) => {
        console.log(value);
        return value.toISOString?.().substring(0, 10);
    }

    const namePatter = '[a-zA-ZА-Яа-я]+'

    const fields: {label: string, element: JSX.Element}[] = [
        {
            label: 'Имя', 
            element: <input type="text" defaultValue={user.name} required pattern={namePatter} onChange={(e) => onChange(e, nameOf<UserDTO>('name'))}/>
        }, 
        {
            label: 'Отчество',
            element: <input type="text" value={user.surname} required onChange={(e) => onChange(e, nameOf<UserDTO>('surname'))}/>
        },
        {
            label: 'Фамилия',
            element: <input type="text" value={user.lastname} required onChange={(e) => onChange(e, nameOf<UserDTO>('lastname'))}/>
        },
        {
            label: 'Дата рождения',
            element:  <input type="date" value={dateFormat(user.birthDate)} required onChange={(e) => onChangeDate(e, nameOf<UserDTO>('birthDate'))}/>
        },
        {
            label: 'Есть y-хромосома?',
            element: <input type="checkbox" checked={user.sex} value={'Sex'} onChange={() => toggleCheckbox(nameOf<UserDTO>('sex'))}/>
        },
        {
            label: 'Серия паспорта',
            element: <input type="text" value={user.passportSeries} pattern='[A-Z]{2}' onChange={(e) => onChange(e, nameOf<UserDTO>('passportSeries'))}/>,
        },
        {
            label: 'Номер паспорта',
            element: <input type="text" value={user.passportNumber} onChange={(e) => onChange(e, nameOf<UserDTO>('passportNumber'))}/>
        },
        {
            label: 'Кем выдан',
            element: <input type="text" value={user.issuedBy} onChange={(e) => onChange(e, nameOf<UserDTO>('issuedBy'))}/>
        }, 
        {
            label: 'Дата выдачи',
            element: <input type="date" value={dateFormat(user.issuedDate)} onChange={(e) => onChange(e, nameOf<UserDTO>('issuedDate'))}/>
        },
        {
            label: 'Ид. номер',
            element: <input type="text" value={user.passportId} onChange={(e) => onChange(e, nameOf<UserDTO>('passportId'))}/>
        },
        {
            label: 'Место рождения',
            element: <input type="text" value={user.birthPlace} required onChange={(e) => onChange(e, nameOf<UserDTO>('birthPlace'))}/>
        },
        {
            label: 'Город проживания',
            element: <CommonDropdown selectedId={user.residenceCity} loadItems={SelectableItemsService.getCities} onChange={(e) => onChange(e, nameOf<UserDTO>('residenceCity'))}/>

        },
        {
            label: 'Адресс проживания',
            element: <input type="text" value={user.residenceAddress} onChange={(e) => onChange(e, nameOf<UserDTO>('residenceAddress'))}/>
        },
        {
            label: 'Семейный статус',
            element: <MaritalStatusesDropdown selectedId={user.maritalStatus} onChange={(e) => onChange(e, nameOf<UserDTO>('maritalStatus'))}/>
        },
        {
            label: 'Гражданство',
            element: <CountriesDropdown selectedId={user.citizenship} onChange={(e) => onChange(e, nameOf<UserDTO>('citizenship'))}/>
        },
        {
            label: 'Инвалидность',
            element: <input type="number" value={user.disability} onChange={(e) => onChange(e, nameOf<UserDTO>('disability'))}/>
        },
        {
            label: 'Пенсионер?',
            element: <input type="checkbox" value='Is retiree' checked={user.isRetiree} onChange={() => toggleCheckbox(nameOf<UserDTO>('isRetiree'))}/>
        },
        {
            label: 'Сколько зарабатываешь?',
            element: <input type="number" value={user.monthlyIncome} onChange={(e) => onChange(e, nameOf<UserDTO>('monthlyIncome'))}/>
        },
        {
            label: 'Служил?',
            element: <input type="checkbox" checked={user.isConscripted} value='Is conscripted' onChange={() => toggleCheckbox(nameOf<UserDTO>('isConscripted'))}/>
        },
        {
            label: 'Мобильный телефон',
            element: <input type="number" value={user.mobilePhone} onChange={(e) => onChange(e, nameOf<UserDTO>('mobilePhone'))}/>
        },
        {
            label: 'Домашний телефон',
            element: <input type="number" value={user.homePhone} onChange={(e) => onChange(e, nameOf<UserDTO>('homePhone'))}/>
        },
        {
            label: 'Email',
            element: <input type="text" value={user.email} onChange={(e) => onChange(e, nameOf<UserDTO>('email'))}/>
        }
    ];

    return (
        <>
            <Link to="/">Список пользователей</Link>
            <form id="user-form" className='main-form'>
                {fields.map(f => 
                    <div>
                        <p>{f.label}</p>
                        {f.element}
                    </div>)}
                {props.userId ? <input type='submit' value='Update' onClick={onUpdate}/> : <input type="submit" value='Create' onClick={onCreate}/>}
            </form>
        </>
    );
}