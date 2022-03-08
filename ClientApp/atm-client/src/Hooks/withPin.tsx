import React, { useEffect } from 'react';
import { useAppDispatch } from '.';
import { PinField } from '../Components/PinField';
import { setCardPin } from '../Store/CardSlice';
import { Page } from '../Store/NavigationSlice';
import { useCardData, useLoginStatus } from './useCard';

export interface WithPinProps {
    nextPage: Page;
}

export const withPin = (Component: React.ComponentType): React.FC<WithPinProps> => ({ nextPage }) => {

    const { pin } = useCardData();
    const { success } = useLoginStatus();
    
    return (pin && success) ? <Component /> : <PinField nextPage={nextPage} />;
}