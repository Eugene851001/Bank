export const DateUtils = class {

    public static dateFormat(value: Date) {
        value = new Date(value);
        if (!value.getMonth) {
            return ;
        }
        
        value.setHours(12);
        return value.toISOString?.().substring(0, 10);
    }

    public static disableInput(e: any) {
        e.preventDefault();
    }
}