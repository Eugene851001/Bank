import { AnyAction, configureStore, Store, ThunkAction } from "@reduxjs/toolkit";
import { AccountReducer } from "./AccountSlice";
import { CardReducer } from "./CardSlice";
import { NavigationReducer } from "./NavigationSlice";
import { ReceiptReducer } from "./ReceiptSlice";

export const store = configureStore({
    reducer: {
        card: CardReducer,
        navigation: NavigationReducer,
        account: AccountReducer,
        receipt: ReceiptReducer,
    }
});

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;

export type AppThunk<ReturnType = void> = ThunkAction<ReturnType, RootState, unknown, AnyAction>; 