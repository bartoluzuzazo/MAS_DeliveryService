import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import {IItem, ItemList} from "./ItemList/ItemList";
import {FunctionComponent, useEffect, useState} from "react";
import axios from "axios";

export interface IOrder {
    id: string,
    sender: string,
    destination: string,
    items: IItem[],
    clientFirstName: string,
    clientLastName: string
}

interface Props {
    setOrder: any,
    setItems: any,
    setStage: any
}

export const OrderList : FunctionComponent<Props> = ({setOrder, setItems, setStage}) => {

    const [Orders, SetOrders] = useState<IOrder[]>();

    const handleNext = (order: IOrder) => {
        setOrder(order);
        setItems([...order.items])
        setStage(1)
    }

    useEffect(() => {
        axios.get("http://localhost:5168/api/Order/pending").then(({data}) => {
            SetOrders(data);
            console.log(data);
        });
    }, [])

    return (
        <div>
            <h2 className="text-5xl p-8">
                Please select an order for delivery
            </h2>
            <TableContainer component={Paper}>
                <Table sx={{minWidth: 650}} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>From</TableCell>
                            <TableCell align="right">To</TableCell>
                            <TableCell align="right">Destination</TableCell>
                            <TableCell align="right">Items</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {Orders?.map((order) => (
                            <TableRow
                                key={order.id}
                                sx={{'&:last-child td, &:last-child th': {border: 0}}}
                            >
                                <TableCell component="th" scope="row">
                                    {order.destination}
                                </TableCell>
                                <TableCell>{order.clientFirstName} {order.clientLastName}</TableCell>
                                <TableCell>{order.destination}</TableCell>
                                <TableCell>
                                    <ItemList items={order.items}/>
                                </TableCell>
                                <TableCell onClick={()=>handleNext(order)}>next</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>

    );
}