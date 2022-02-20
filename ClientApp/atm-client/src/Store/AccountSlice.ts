import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface IAccountState {
    balance?: number;
    withdrawSuccess: boolean;
    withdrawError?: string;
    withdrawSum?: number;
    paymentSuccess: boolean;
    transferError?: string;
    destinationAccount?: string;
    transferSum?: number;
}

const initialState: IAccountState = {
    withdrawSuccess: false,
    paymentSuccess: false,
}

const AccountSlice = createSlice({
    name: 'account',
    initialState,
    reducers: {
        setBalance: (state, action: PayloadAction<number>) => {
            state.balance = action.payload;
        },
        setWithdrawSucess: (state, action: PayloadAction<boolean>) => {
            state.withdrawSuccess = action.payload;
        },
        setWithdrawSum: (state, action: PayloadAction<number | undefined>) => {
            state.withdrawSum = action.payload;
        },
        setWithdrawError: (state, action: PayloadAction<string | undefined>)  => {
            state.withdrawSuccess = false;
            state.withdrawError = action.payload;
        },
        setPaymentSuccess: (state, action: PayloadAction<boolean>) => {
            state.paymentSuccess = action.payload;
        },
        setDestinationAcount: (state, action: PayloadAction<string>) => {
            state.destinationAccount = action.payload;
        },
        setTransferSum: (state, action: PayloadAction<number>) => {
            state.transferSum = +action.payload;
        },
        setTransferError: (state, action: PayloadAction<string | undefined>) => {
            state.paymentSuccess = false;
            state.transferError = action.payload;
        },
        resetAccount: (state) => {
            state.balance = initialState.balance;
            state.paymentSuccess = initialState.paymentSuccess;
            state.withdrawSuccess = initialState.withdrawSuccess;
        }
    }
});

export const { 
    setBalance, 
    setWithdrawSucess, 
    setWithdrawSum, 
    setPaymentSuccess, 
    setDestinationAcount, 
    setTransferSum, 
    resetAccount,
    setTransferError,
    setWithdrawError,
} = AccountSlice.actions;

export const AccountReducer = AccountSlice.reducer;
