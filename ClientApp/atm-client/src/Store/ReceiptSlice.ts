import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface IReceiptData {
    operation: string;
    sum: number;
    date: Date;
}

interface IReceiptState {
    printed: boolean;
    data?: IReceiptData;
}

const initialState: IReceiptState = {
    printed: false,
}

const ReceiptSlice = createSlice({
    name: 'receipt',
    initialState,
    reducers: {
        setReceipt: (state, action: PayloadAction<IReceiptData>) => {
            state.data = action.payload;
        },
        printReceipt: (state) => {
            state.printed = true;
        },
        getPrinted: (state) => {
            state.printed = false;
        }
    }  
})

export const { setReceipt, printReceipt, getPrinted } = ReceiptSlice.actions;

export const ReceiptReducer =  ReceiptSlice.reducer;