import React from 'react';
import { CommonDropdown } from './CommonDropdown';
import { IDropdownProps } from './IDropdownProps';
import { SelectableItemsService } from '../../Services/SelectableItemsService';
import { DropdownView } from './DropdownView';
import { SelectableItemDTO } from '../../Models/SelectableItemDTO';

export const SexDropdown = (props: IDropdownProps) => {
    const items: SelectableItemDTO[] = [{id: 0, name: 'Ж'}, {id: 1, name: 'М'}];
    return  <DropdownView items={items} selectedItem={props.selectedId} onChange={props.onChange}/>
}