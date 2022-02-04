import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Constants } from '../Contants/Constants';
import { UserDTO } from '../Models/UserDTO';
import { UsersService } from '../Services/UsersService';
import { nameOf } from '../utils/NameOf';
import { CommonDropdown } from './Dropdown/CommonDropdown';
import { SelectableItemsService } from '../Services/SelectableItemsService';
import './UserDetailsView.style.css';
import { MaritalStatusesDropdown } from './Dropdown/MaritalStatuses';
import { CountriesDropdown } from './Dropdown/CountriesDropdown';
import { ErrorDTO } from '../Models/ErrorDTO';
import { DisabilitiesDropdown } from './Dropdown/DisabilitiesDropdown';
import { SexDropdown } from './Dropdown/SexDropown';
import { FieldData } from '../utils/FieldData';
import { DateUtils } from '../utils/DateUtils';

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

    const onChangeSex = (e: any) => {
        const value = e.target.value;

        user.sex = value == 0 ? false : true;
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
            alert('ФИО обязательно и должно содержать только буквы и не быть пустым');
            return false;
        }

        const phonePattern = /^[0-9]{9}$/;

        if (user.mobilePhone && !user.mobilePhone.match(phonePattern)) {
            alert('Мобильнйы телефон должен быть из 9 цифр')
            return false;
        }

        const homePhonePattern = /^\d{6}$/;

        if (user.homePhone && !user.homePhone.match(homePhonePattern)) {
            alert('Домашний телефон должен быть из 6 цифр')
            return false;
        }

        const emailPattern = /[a-zA-Z.-]\@/;

        if (user.email && !user.email.match(emailPattern)) {
            alert('Проверьте email');
            return false;
        }

        const passportSeriesPattern = /^[A-Z]{2}$/;

        if (!user.passportSeries || !user.passportSeries.match(passportSeriesPattern)) {
            alert('Неверный формат серии паспорта');
            return false;
        }

        const passportNumberPattern = /^\d{7}$/;
        if (!user.passportNumber || !user.passportNumber.match(passportNumberPattern)) {
            alert('Неверный формат номера паспорта');
            return false;
        }

        const passportIdPattern = /^\w{14}$/;
        if (!user.passportId || !user.passportId.match(passportIdPattern)) {
            alert('Неверный формат ид. номера паспорта');
            return false;
        }

        const checkRequired = (value: string) => value && value.length > 0; 

        if (!checkRequired(user.birthPlace)) {
            alert('Место рождения является обязательным');
            return false;
        }

        if (!checkRequired(user.issuedBy)) {
            alert('Поле "Кем выдан" явялется обязательным');
            return false;
        }

        if (!checkRequired(user.residenceAddress)) {
            alert('Адресс проживания является обязательным');
            return false;
        }

        if (user.monthlyIncome && user.monthlyIncome < 0) {
            alert('Доход не должен быть меньше нуля');
            return false;
        }
 
        return true;
    }

    const onUpdate = async (e: any) => {
        e.preventDefault();

        if (props.userId && isValidData()) {
            const response = await UsersService.updateUser({id: props.userId, value: user});
            if (response.status != 200) {
                const errorInfo = await response.json();
                alert(`Error while updating user: ${errorInfo.message}`);
            } else {
                alert('User has been updated');
            }
        }
    }

    const onCreate = async (e: any) => {
        e.preventDefault();

        if (isValidData()) {
            const response = await UsersService.addUser(user);
            if (response.status != 200) {
                const errorInfo = await response.json();
                let error = '';
                if (errorInfo.message) {
                    error = errorInfo.message;
                } else {
                    error = errorInfo.errors[0];
                }
                alert(`Error while adding user: ${error}`);
            } else {
                alert('User has been added');
            }
        }
    }
    
    const onDateInput = (e: any) => {
        e.preventDefault();

        console.log(e);
    }


    const fields: FieldData[] = [
        {
            label: 'Имя', 
            required: true,
            element: <input type="text" defaultValue={user.name} required onChange={(e) => onChange(e, nameOf<UserDTO>('name'))}/>
        }, 
        {
            label: 'Отчество',
            required: true,
            element: <input type="text" value={user.surname} required onChange={(e) => onChange(e, nameOf<UserDTO>('surname'))}/>
        },
        {
            label: 'Фамилия',
            required: true,
            element: <input type="text" value={user.lastname} required onChange={(e) => onChange(e, nameOf<UserDTO>('lastname'))}/>
        },
        {
            label: 'Дата рождения',
            required: true,
            element:  <input type="date" onKeyDown={onDateInput} value={DateUtils.dateFormat(user.birthDate)} required onChange={(e) => onChangeDate(e, nameOf<UserDTO>('birthDate'))}/>
        },
        {
            label: 'Пол',
            required: true,
            element:  <SexDropdown selectedId={user.sex ? 1 : 0} onChange={(e) => onChangeSex(e)}/> //<input type="checkbox" checked={user.sex} value={'Sex'} onChange={() => toggleCheckbox(nameOf<UserDTO>('sex'))}/>
        },
        {
            label: 'Серия паспорта',
            required: true,
            element: <input type="text" value={user.passportSeries} pattern='[A-Z]{2}' onChange={(e) => onChange(e, nameOf<UserDTO>('passportSeries'))}/>,
        },
        {
            label: 'Номер паспорта',
            required: true,
            element: <input type="text" value={user.passportNumber} onChange={(e) => onChange(e, nameOf<UserDTO>('passportNumber'))}/>
        },
        {
            label: 'Кем выдан',
            required: true,
            element: <input type="text" value={user.issuedBy} onChange={(e) => onChange(e, nameOf<UserDTO>('issuedBy'))}/>
        }, 
        {
            label: 'Дата выдачи',
            required: true,
            element: <input type="date" onKeyDown={onDateInput} value={DateUtils.dateFormat(user.issuedDate)} onChange={(e) => onChange(e, nameOf<UserDTO>('issuedDate'))}/>
        },
        {
            label: 'Ид. номер',
            required: true,
            element: <input type="text" value={user.passportId} onChange={(e) => onChange(e, nameOf<UserDTO>('passportId'))}/>
        },
        {
            label: 'Место рождения',
            required: true,
            element: <input type="text" value={user.birthPlace} required onChange={(e) => onChange(e, nameOf<UserDTO>('birthPlace'))}/>
        },
        {
            label: 'Город проживания',
            required: true,
            element: <CommonDropdown selectedId={user.residenceCity} loadItems={SelectableItemsService.getCities} onChange={(e) => onChange(e, nameOf<UserDTO>('residenceCity'))}/>
        },
        {
            label: 'Адресс проживания',
            required: true,
            element: <input type="text" value={user.residenceAddress} onChange={(e) => onChange(e, nameOf<UserDTO>('residenceAddress'))}/>
        },
        {
            label: 'Семейный статус',
            required: true,
            element: <MaritalStatusesDropdown selectedId={user.maritalStatus} onChange={(e) => onChange(e, nameOf<UserDTO>('maritalStatus'))}/>
        },
        {
            label: 'Гражданство',
            required: true,
            element: <CountriesDropdown selectedId={user.citizenship} onChange={(e) => onChange(e, nameOf<UserDTO>('citizenship'))}/>
        },
        {
            label: 'Инвалидность',
            required: true,
            element: <DisabilitiesDropdown selectedId={user.disability} onChange={(e) => onChange(e, nameOf<UserDTO>('disability'))}/>
        },
        {
            label: 'Пенсионер?',
            required: true,
            element: <input type="checkbox" value='Is retiree' checked={user.isRetiree} onChange={() => toggleCheckbox(nameOf<UserDTO>('isRetiree'))}/>
        },
        {
            label: 'Месячный доход',
            element: <input type="number" value={user.monthlyIncome} onChange={(e) => onChange(e, nameOf<UserDTO>('monthlyIncome'))}/>
        },
        {
            label: 'Военноябязанный',
            required: true,
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
                <table>
                    {fields.map(f => 
                        <tr>
                            <td>{f.label}</td>
                            <td className={f.required ? 'required' : ''}>{f.element}</td>
                        </tr>)}
                </table>
                {props.userId ? <input type='submit' value='Update' className='submit-button' onClick={onUpdate}/> : <input type="submit" className='submit-button' value='Create' onClick={onCreate}/>}
            </form>
        </>
    );
}