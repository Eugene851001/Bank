import { SelectableItemDTO } from "../Models/SelectableItemDTO";

export class SelectableItemsService {

    public static getCities(): Promise<SelectableItemDTO[]> {
        return SelectableItemsService.getSelectableItems('cities');
    }

    public static getCountries(): Promise<SelectableItemDTO[]> {
        return SelectableItemsService.getSelectableItems('countries');
    }

    public static getMaritalStatuses(): Promise<SelectableItemDTO[]> {
        return SelectableItemsService.getSelectableItems('MaritalStatuses');
    }

    public static getDisabilities(): Promise<SelectableItemDTO[]> {
        return SelectableItemsService.getSelectableItems('disabilities');
    }

    public static getCurrencies(): Promise<SelectableItemDTO[]> {
        return SelectableItemsService.getSelectableItems('currencies');
    }

    private static getSelectableItems(controller: string) {
        return fetch(`/api/${controller}`).then(response => response.json());
    }
}