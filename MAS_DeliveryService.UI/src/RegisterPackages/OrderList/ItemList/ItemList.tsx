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

interface props{
    items: IItem[]
}

export const ItemList : FunctionComponent<props> = ({items}) => {
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
                    <ListItem key={`item-$${item}`}>
                        <ListItemText primary={item.name}/>
                        <ListItemText primary={item.weight}/>
                    </ListItem>
                ))}
            </ul>
        </List>
    );
}