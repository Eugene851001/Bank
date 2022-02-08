import React, { useEffect, useState } from 'react';
import { useCurrentDate } from '../Contexts/CurrentDateContext';
import { DeposistsService } from '../Services/DeposistsService';
import { SystemService } from '../Services/SystemService';
import { DateUtils } from '../utils/DateUtils';

export interface CloseDayFormProps {
    onClose?: () => void;
}

export const CloseDayFrom = (props: CloseDayFormProps) => {
    const [currentDate, setCurrentDate] = useState(new Date());

    async function loadCurrentDate() {
        const response = await SystemService.getCurrentTime();

        setCurrentDate(response.currentDate);
    }

    useEffect(() => {
        loadCurrentDate();
    }, []);

    const onChange = (e: any) => {
        e.preventDefault();
    }

    const onSubmit = async (e: any) => {
        e.preventDefault();

        const response = await DeposistsService.closeDay({currentDate: currentDate});
    
        if (response.status == 200) {
            alert('Operation has been performed');
            props.onClose?.();
            await loadCurrentDate();
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