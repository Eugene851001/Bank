import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { CardService } from '../Services/CardService';

interface CardData {
    number: string;
    pin?: string;
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
        login: (state) => {
            const { number, pin } = state.card;

            if (state.loginAttemp == 3) {
                state.errorMessage = 'Your have no more attemps for login, please restart';
            }
            
            async function makeLoginRequest(number: string, pin: string) {
                const reponse = await CardService.login({ number, pin });
                if (reponse.status == 200) {
                    state.loginSuccess = true;
                } else {
                    state.errorMessage = 'Incorrect card number or pin';
                    state.loginAttemp++;
                }
            }

            if (pin) {
               makeLoginRequest(number, pin);
            } else {
                state.errorMessage = 'Please, enter the pin'
            }
        },
        restart: (state) => {
            state.loginAttemp = 0;
        }
    }
})

export const { setCardData, login, restart } = CardSlice.actions;

export const CardReducer = CardSlice.reducer;

