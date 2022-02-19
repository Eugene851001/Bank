import { GetBalanceResponse } from "../../Models/GetBalanceResponse";
import { AppThunk } from "../Store";
import { CardService } from "../../Services/CardService"
import { setBalance, setPaymentSuccess, setWithdrawSucess } from "../AccountSlice";
import { PagesId, setCurrentPage } from "../NavigationSlice";
import { setCardPin } from "../CardSlice";
import { useCardData } from "../../Hooks/useCard";

export function getBalance(): AppThunk {
    return async (dispatch, getState) => {
        const state = getState();

        const response: GetBalanceResponse = await CardService.getBalance(state.card.card.number);

        dispatch(setBalance(response.balance));
    }
}

export function withdrawMoney(): AppThunk {
    return async(dispatch, getState) => {
        
        const { card, account } = getState();

        const response = await CardService.withdrawMoney({ number: card.card.number, sum: account.withdrawSum || 0 });
        
        if (response.status == 200) {
            dispatch(setCurrentPage({id: PagesId.Withdraw, phase: 1}));
            dispatch(setWithdrawSucess(true));
        } else {
            dispatch(setWithdrawSucess(false));
        }
    }
}

export function transferMoney(): AppThunk {
    return async(dispatch, getState) => {

        const { number } = getState().card.card;

        const { transferSum: sum, destinationAccount } = getState().account;

        const response = await CardService.transferMoney({
            cardNumber: number, 
            destinationAccount: destinationAccount || '', 
            sum: sum || 0 });

        if (response.status == 200) {
            dispatch(setCurrentPage({id: PagesId.Payments, phase: 2}));
            dispatch(setPaymentSuccess(true));
        } else {
            dispatch(setPaymentSuccess(false));
        }   
    }
}