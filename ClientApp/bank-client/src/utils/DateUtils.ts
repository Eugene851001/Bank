export const DateUtils = class {

    public static dateFormat(value: Date) {
        if (!value.getMonth) {
            return ;
        }
        
        return value.toISOString?.().substring(0, 10);
    }

    public static disableInput(e: any) {
        e.preventDefault();
    }
}