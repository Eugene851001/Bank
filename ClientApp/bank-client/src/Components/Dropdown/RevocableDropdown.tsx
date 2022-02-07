import React from 'react';
import { IDropdownProps } from './IDropdownProps';
import { DropdownView } from './DropdownView';
import { SelectableItemDTO } from '../../Models/SelectableItemDTO';

export const RevocableDropdown = (props: IDropdownProps) => {
    const items: SelectableItemDTO[] = [{id: 0, name: 'Безотзывной'}, {id: 1, name: 'Отзывной'}];
    return  <DropdownView items={items} selectedItem={props.selectedId} onChange={props.onChange}/>
}