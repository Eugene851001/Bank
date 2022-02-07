import React, { useState } from 'react';
import { useCurrentDate } from '../Contexts/CurrentDateContext';
import { DeposistsService } from '../Services/DeposistsService';
import { DateUtils } from '../utils/DateUtils';

export interface CloseDayFormProps {
    onClose?: () => void;
}

export const CloseDayFrom = (props: CloseDayFormProps) => {
    const {currentDate, setCurrentDate} = useCurrentDate();

    const onChange = (e: any) => {
        e.preventDefault();

        setCurrentDate(e.target.value);
    }

    const onSubmit = async (e: any) => {
        e.preventDefault();

        const response = await DeposistsService.closeDay({currentDate: currentDate});
    
        if (response.status == 200) {
            alert('Operation has been performed');
            props.onClose?.();
            const newDate = new Date();
            newDate.setDate(currentDate.getDate() + 1);
            setCurrentDate(newDate);
        } else {
            alert('Something went wrong');
        }
    }

    return (
        <form>
            <input type="date" value={DateUtils.dateFormat(new Date(currentDate))} onChange={e => onChange(e)}/>
            <input type="submit" onClick={onSubmit}></input>
        </form>);
}