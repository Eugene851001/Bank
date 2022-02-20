import React, {useEffect} from "react";
import { useAppDispatch } from "../Hooks";
import { useNavigation } from "../Hooks/useNavigation";
import { withPin } from "../Hooks/withPin";
import { PagesId, setCurrentPage } from "../Store/NavigationSlice";
import { Balance } from "./Balance";
import { Logination } from "./Logination";
import { Menu } from "./Menu";
import { Payment } from "./Payment";
import { ReceiptContainer } from "./ReceiptContainer";
import { Withdraw } from "./Withdraw";
import './MainContainer.css';
import { useLoginStatus } from "../Hooks/useCard";

export const MainContainer = () => {

    const { currentPage } = useNavigation();
    const { errorMessage } = useLoginStatus();

    const dispatch = useAppDispatch();

    
    useEffect(() => {
        if (errorMessage) {
            alert(errorMessage);
        }
    }, [errorMessage]);

    const onMenuClick = (e: any) => {
        e.preventDefault();

        dispatch(setCurrentPage({id: PagesId.Menu, phase: 0}));
    }

    const WithPinBalance = withPin(() => <Balance />);
    const WithPinPayment = withPin(() => <Payment />);
    const WithPinWithdraw = withPin(() => <Withdraw />);

    return (<div className="main">
        <h1>ATM</h1>
        <div className="display">
            {currentPage.id != PagesId.Logination && 
                currentPage.id != PagesId.Menu && <button onClick={onMenuClick}>Menu</button>}
            {currentPage.id == PagesId.Logination && <Logination />}
            {currentPage.id == PagesId.Menu && <Menu />}
            {currentPage.id == PagesId.Balance && <WithPinBalance nextPage={{id: PagesId.Balance, phase: 0}}/>}
            {currentPage.id == PagesId.Payments && <WithPinPayment nextPage={{id: PagesId.Payments, phase: 0}}/>}
            {currentPage.id == PagesId.Withdraw && <WithPinWithdraw nextPage={{id: PagesId.Withdraw, phase: 0}} />}
        </div>
        <div className='receiptContainer'>
            <ReceiptContainer />
        </div>
    </div>);
}