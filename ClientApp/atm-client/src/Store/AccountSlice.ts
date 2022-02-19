import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface IAccountState {
    balance?: number;
    withdrawSuccess: boolean;
    withdrawSum?: number;
    paymentSuccess: boolean;
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
        setPaymentSuccess: (state, action: PayloadAction<boolean>) => {
            state.paymentSuccess = action.payload;
        },
        setDestinationAcount: (state, action: PayloadAction<string>) => {
            state.destinationAccount = action.payload;
        },
        setTransferSum: (state, action: PayloadAction<number>) => {
            state.transferSum = +action.payload;
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
    resetAccount 
} = AccountSlice.actions;

export const AccountReducer = AccountSlice.reducer;
