import { configureStore, Store } from "@reduxjs/toolkit";
import { CardReducer } from "./CardSlice";

const store = configureStore({
    reducer: {
        card: CardReducer
    }
});

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;