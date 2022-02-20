import React from 'react';
import { ReturnButton } from './ReturnButton';

export interface ErrorMessageProps {
    message: string;
}

export const ErrorMessage: React.FC<ErrorMessageProps> = ({ message }) => {
    return <>
        <p>Operation can not be performed: {message}</p>
        <ReturnButton />
    </>
}