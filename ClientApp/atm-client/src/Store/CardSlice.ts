import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { CardService } from '../Services/CardService';

interface CardData {
    number: string;
    pin?: string;
    accountNumber?: string;
    currency?: string;
}

interface CardState {
    card: CardData;
    loginAttemp: number;
    loginSuccess: boolean;
    errorMessage?: string;
}

const initialState: CardState = {
    card: {number: '12345'},
    loginAttemp: 0,
    loginSuccess: false,
};

export const CardSlice = createSlice({
    name: 'card',
    initialState: initialState,
    reducers: {
        setCardData: (state, action: PayloadAction<CardData>) => {
            state.card = action.payload;
        },
        setCardNumber: (state, action: PayloadAction<string>) => {
            state.card.number = action.payload;
        },
        setCardPin: (state, action: PayloadAction<string | undefined>) => {
            state.card.pin = action.payload;
        },
        setAccountNumber: (state, action: PayloadAction<string | undefined>) => {
            state.card.accountNumber = action.payload;
        },
        setCurrency: (state, action: PayloadAction<string | undefined>) => {
            state.card.currency = action.payload;
        },
        setError: (state, action: PayloadAction<string>) => {
            state.errorMessage = action.payload;
            state.loginSuccess = false;
        },
        setSuccess: (state, action: PayloadAction<boolean>) => {
            state.loginSuccess = action.payload;
        },
        setLoginAttemp: (state, action: PayloadAction<number>) => {
            state.loginAttemp = action.payload;
        },  
        resetCard: (state) => {
            state.card = initialState.card;
            state.errorMessage = initialState.errorMessage;
            state.loginAttemp = initialState.loginAttemp;
            state.loginSuccess = initialState.loginSuccess;
        }
    }
})

export const { 
    setCardData, 
    setError, 
    setSuccess, 
    resetCard, 
    setLoginAttemp, 
    setCardNumber, 
    setCardPin,
    setAccountNumber,
    setCurrency,
 } = CardSlice.actions;

export const CardReducer = CardSlice.reducer;

