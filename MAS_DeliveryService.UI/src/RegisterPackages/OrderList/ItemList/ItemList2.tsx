import * as React from 'react';
import {FunctionComponent} from "react";

export interface IItem {
    id: string,
    name: string,
    weight: number
}

interface props{
    items: IItem[]
}

export const ItemList2 : FunctionComponent<props> = ({items}) => {
    return (
        <div>
            <ul className="">

            </ul>
        </div>
    );
}