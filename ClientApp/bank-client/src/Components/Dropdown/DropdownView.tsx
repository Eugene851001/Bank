import React from 'react';
import { SelectableItemDTO } from '../../Models/SelectableItemDTO';

export interface IDropdownViewProps {
    onChange?: (e: any) => void;
    items: SelectableItemDTO[];
    selectedItem: number;
}

export const DropdownView = (props: IDropdownViewProps) => {

    return <select onChange={props.onChange}>
        {props.items.map(item => <option value={item.id} selected={item.id == props.selectedItem}>{item.name}</option>)}
    </select>;
}