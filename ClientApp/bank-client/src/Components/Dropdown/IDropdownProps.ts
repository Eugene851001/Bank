import { SelectableItemDTO } from "../../Models/SelectableItemDTO";

export interface IDropdownProps {
    selectedId: number;
    onChange?: (e: any) => void;
}