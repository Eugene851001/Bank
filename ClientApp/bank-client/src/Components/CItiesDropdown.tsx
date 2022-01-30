import React from 'react';
import { CommonDropdown } from './CommonDropdown';
import { IDropdownProps } from './IDropdownProps';
import { SelectableItemsService } from '../Services/SelectableItemsService';

export const CitiesDropdown = (props: IDropdownProps) => {
    return  <CommonDropdown {...props} loadItems={() => SelectableItemsService.getCities()}/>
}