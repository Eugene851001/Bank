export const DateUtils = class {

    public static dateFormat(value: Date) {
        value = new Date(value);
        if (!value.getMonth) {
            return ;
        }
        
        return value.toISOString?.().substring(0, 10);
    }

    public static disableInput(e: any) {
        e.preventDefault();
    }
}