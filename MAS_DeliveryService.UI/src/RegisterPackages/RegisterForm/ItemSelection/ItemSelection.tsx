import * as React from 'react';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import {FunctionComponent, useEffect, useState} from "react";
import {Checkbox, ListItemButton} from "@mui/material";
import {IItem} from "../../OrderList/ItemList/ItemList";

interface props {
    items: IItem[],
    selectedItems : IItem[],
    setSelectedItems: any
}

export const ItemSelection: FunctionComponent<props> = ({items, selectedItems, setSelectedItems}) => {

    const handleCheck = (item: IItem) => {
        const CurrentList = [...selectedItems];
        const ItemIndex = CurrentList.indexOf(item);
        if(ItemIndex !== -1){
            CurrentList.splice(ItemIndex, 1);
        }
        else CurrentList.push(item);
        setSelectedItems(CurrentList);
    }

    return (
        <List
            sx={{
                width: '100%',
                bgcolor: 'background.paper',
                position: 'relative',
                overflow: 'auto',
                maxHeight: 150,
                '& ul': {padding: 0},
            }}
            subheader={<li/>}
        >
            <ul>
                {items.map((item) => (
                    <ListItem key={item.id} secondaryAction={
                        <Checkbox
                            edge="end"
                            onChange={()=> handleCheck(item)}
                            checked={selectedItems.indexOf(item) !== -1}
                            tabIndex={-1}
                            inputProps={{'aria-labelledby': item.id}}
                        />
                    } className="border border-black">
                        <ListItemButton>
                            <ListItemText primary={item.name}/>
                            <ListItemText primary={item.weight}/>
                        </ListItemButton>
                    </ListItem>
                ))}
            </ul>
        </List>
    );
}