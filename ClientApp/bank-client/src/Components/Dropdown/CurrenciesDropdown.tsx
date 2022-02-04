import React from 'react';
import { CommonDropdown } from './CommonDropdown';
import { IDropdownProps } from './IDropdownProps';
import { SelectableItemsService } from '../../Services/SelectableItemsService';

export const CurrenciesDropdown = (props: IDropdownProps) => { 
    return  <CommonDropdown {...props} loadItems={() => SelectableItemsService.getCurrencies()}/>
}