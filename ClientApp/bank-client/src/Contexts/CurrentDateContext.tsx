import React, { useState } from "react";

export interface ICurrentDateState {
    currentDate: Date;
    setCurrentDate: (value: Date) => void;
}

const CurrentDateContext = React.createContext<ICurrentDateState | undefined>(undefined);

export interface CurrentDateProviderProps {
    initialDate?: Date;
}

export const CurrentDateProvider = (props: React.PropsWithChildren<CurrentDateProviderProps>) => {

    const [currentDate, setCurrentDate] = useState(props.initialDate || new Date());

    return <CurrentDateContext.Provider value={{
        currentDate, 
        setCurrentDate: (value) => setCurrentDate(value)
    }}>{props.children}</CurrentDateContext.Provider>
}

export const useCurrentDate = () => {
    const context = React.useContext(CurrentDateContext);

    if (!context) {
        throw new Error('useCurrentDate should be used inside CurrentDateContext');
    }

    return context;
}

