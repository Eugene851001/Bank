import { Dispatch } from "react"
import { useAppDispatch } from "../../Hooks"
import { AppThunk, RootState } from "../Store"
import { ThunkAction } from "@reduxjs/toolkit"
import { AnyAction } from "@reduxjs/toolkit"
import { CardService } from "../../Services/CardService"
import { setAccountNumber, setCurrency, setError, setLoginAttemp, setSuccess } from "../CardSlice"
import { Page, PagesId, setCurrentPage } from "../NavigationSlice"
import { LoginResponse } from "../../Models/LoginResponse"

export function login(nextPage: Page): AppThunk  {

    return async (dispatch, getState) => {
        const state = getState().card;
        const { number, pin } = state.card;

        if (state.loginAttemp == 3) {
            dispatch(setError('Your have no more attemps for login, please restart'))
            return;
        }
        
        async function makeLoginRequest(number: string, pin: string) {
            const response = await CardService.login({ number, pin });
            if (response.status == 200) {
                const cardInfo: LoginResponse = await response.json();
                dispatch(setAccountNumber(cardInfo.accountNumber));
                dispatch(setCurrency(cardInfo.currency));
                dispatch(setSuccess(true));
                dispatch(setLoginAttemp(0));
                dispatch(setCurrentPage(nextPage));
            } else {
                dispatch(setError('Incorrect card number or pin'));
                dispatch(setLoginAttemp(state.loginAttemp + 1));
            }
        }

        if (pin) {
           makeLoginRequest(number, pin);
        } else {
            dispatch(setError('Please, enter the pin'));
        }
    }
}

