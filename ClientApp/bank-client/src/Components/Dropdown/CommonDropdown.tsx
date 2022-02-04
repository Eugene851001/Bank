import React, { useEffect, useState } from 'react';
import { SelectableItemDTO } from '../../Models/SelectableItemDTO';
import { SelectableItemsService } from '../../Services/SelectableItemsService';
import { DropdownView } from './DropdownView';
import { IDropdownProps } from './IDropdownProps';

export interface ICommonDropdownProps extends IDropdownProps  {
    loadItems: () => Promise<SelectableItemDTO[]>;
}

export const CommonDropdown = (props: ICommonDropdownProps) => {

    const [items, setItems] = useState<SelectableItemDTO[]>();

    useEffect(() => {
        async function loadData() {
            const response = await props.loadItems();

            setItems(response);
        }

        loadData();
    }, []);

    return items ? <DropdownView items={items} selectedItem={props.selectedId} onChange={props.onChange}/> : <p>Loading...</p>;
}