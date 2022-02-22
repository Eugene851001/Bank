import { useAppSelector } from ".";

export function useReceiptPrinted() {
    const printed = useAppSelector(state => state.receipt.printed);

    return printed;
}

export function useReceiptData() {
    const data = useAppSelector(state => state.receipt.data);
    
    return data;
}