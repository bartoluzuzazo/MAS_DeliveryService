import * as React from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import {FunctionComponent} from "react";

export interface IItem {
    id: string,
    name: string,
    weight: number
}

interface props {
    items: IItem[]
}

export const ItemListX: FunctionComponent<props> = ({items}) => {
    return (
        <List
            sx={{
                width: '100%',
                bgcolor: 'background.paper',
                position: 'relative',
                overflow: 'auto',
                maxHeight: 100,
                '& ul': {padding: 0},
            }}
            subheader={<li/>}
        >
            <ul>
                {items.map((item) => (
                    <ListItem key={item.id} className="border border-black">
                        <ListItemText primary={item.name}/>
                        <ListItemText primary={item.weight}/>
                    </ListItem>
                ))}
            </ul>
        </List>
    );
}

export const ItemList: FunctionComponent<props> = ({items}) => {
    return (
        <div className="min-w-40">
            <ul className="h-24 w-full overflow-y-scroll border border-black">
                {items.map((i) =>
                    <li className="text-lg flex flex-row justify-between border-b border-black">
                        <div className="p-1">{i.name}</div>
                        <div className="p-1">{i.weight}kg</div>
                    </li>)}
            </ul>
        </div>
    );
}