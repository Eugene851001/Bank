import { useSelector } from "react-redux";
import { useAppDispatch, useAppSelector } from "./index";

export const useCardData = () => {
    const cardData = useAppSelector(state => state.card.card);

    return cardData;
};

export const useLoginStatus = () => {
    const success = useAppSelector(state => state.card.loginSuccess);
    const errorMessage = useAppSelector(state => state.card.errorMessage);
    const attemp = useAppSelector(state => state.card.loginAttemp);

    return {
        success,
        errorMessage,
        attemp,
    }
};