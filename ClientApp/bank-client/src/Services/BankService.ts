

export const BankService = class {
    public static closeDay() {
        return fetch('/api/bank/closeDay', {method: 'POST'});
    }

    public static closeMonth() {
        return fetch('/api/bank/closeMonth', {method: 'POST'});
    }
}