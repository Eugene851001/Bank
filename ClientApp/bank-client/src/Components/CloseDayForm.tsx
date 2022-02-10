import React, { useEffect, useState } from 'react';
import { BankService } from '../Services/BankService';
import { SystemService } from '../Services/SystemService';
import { DateUtils } from '../utils/DateUtils';
import './CloseDayForm.css';

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

    const helpCloseDays = async (closeBankDay: () => Promise<Response>) => {
        const response = await closeBankDay();
    
        if (response.status == 200) {
            alert('Operation has been performed');
            props.onClose?.();
            await loadCurrentDate();
        } else {
            alert('Something went wrong');
        }
    }

    const onSubmit = async (e: any) => {
        e.preventDefault();

        await helpCloseDays(BankService.closeDay);
    }

    const onCloseMonth = async (e: any) => {
        e.preventDefault();

        await helpCloseDays(BankService.closeMonth);
    }

    return (
        <form className="close-controls">
            <input type="date" value={DateUtils.dateFormat(new Date(currentDate))} onChange={e => onChange(e)}/>
            <div className='close-buttons'>
                <input type="submit" onClick={onSubmit} value="Закрыть день"/>
                <input type="submit" onClick={onCloseMonth} value="Закрыть месяц"/>
            </div>
        </form>);
}