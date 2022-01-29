import React from 'react';
import { SelectableItemDTO } from '../Models/SelectableItemDTO';

export interface IDropdownProps {
    onChange?: (e: any) => void;
    items: SelectableItemDTO[];
    selectedItem: number;
}

export const Dropdown = (props: IDropdownProps) => {

    return <select onChange={props.onChange}>
        {props.items.map(item => <option value={item.id} selected={item.id == props.selectedItem}>{item.name}</option>)}
    </select>;
}