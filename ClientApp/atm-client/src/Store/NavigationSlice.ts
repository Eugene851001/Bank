import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export enum PagesId {
    Logination,
    Menu,
    Balance,
    Withdraw,
    Payments
}

export type Page = {
    id: PagesId,
    phase: number,
}


interface INavigationState {
    currentPage: Page
}

const initialState: INavigationState = {
    currentPage: {
        id: PagesId.Logination,
        phase: 0
    }
}

export const NavigationSlice = createSlice({
    name: 'Navigation',
    initialState,
    reducers: {
        setCurrentPage: (state, action: PayloadAction<Page>) => {
            state.currentPage = action.payload;
        },
        resetNavigation: (state) => {
            state.currentPage = initialState.currentPage;
        }
    }
})

export const NavigationReducer = NavigationSlice.reducer;
 
export const { setCurrentPage, resetNavigation } = NavigationSlice.actions;