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
import {FaTruckArrowRight} from "react-icons/fa6";
import {Skeleton} from "@mui/material";

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

export const OrderListX: FunctionComponent<Props> = ({setOrder, setItems, setStage}) => {

    const [Orders, SetOrders] = useState<IOrder[]>();

    const handleNext = (order: IOrder) => {
        setOrder(order);
        setItems([...order.items])
        setStage(1)
    }

    useEffect(() => {
        axios.get("http://localhost:5168/api/Order/pending").then(({data}) => {
            SetOrders(data);
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
                                <TableCell onClick={() => handleNext(order)}>next</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>

    );
}

export const OrderList: FunctionComponent<Props> = ({setOrder, setItems, setStage}) => {

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
        }).catch(e => {
            SetOrders([]);
        });
    }, [])

    return (
        <div>
            <h2 className="text-5xl p-8 pr-96">
                Please select an order for delivery
            </h2>
            <table className="border border-black rounded-xl shadow-xl w-full">
                <tr className="border-b border-black text-xl">
                    <th className="p-2">From</th>
                    <th className="p-2">To</th>
                    <th className="p-2">Destination</th>
                    <th className="p-2">Items</th>
                    <th className="p-2"></th>
                </tr>
                {Orders?.map((order) =>
                    <tr className="text-lg border-b border-black">
                        <td className="p-4">{order.sender}</td>
                        <td className="p-4">{order.clientFirstName} {order.clientLastName}</td>
                        <td className="p-4">{order.destination}</td>
                        <td className="w-4/12"><ItemList items={order.items}/></td>
                        <td className="flex align-middle justify-center p-4 h-full cursor-pointer" onClick={() => handleNext(order)}>
                            <div className="flex flex-col align-middle justify-center">
                                <FaTruckArrowRight className="size-8"/>
                                <div>Next</div>
                            </div>
                        </td>
                    </tr>) ?? [1,2,3,4,5,6,7,8].map(()=>
                    <tr>
                        <td><Skeleton className="w-full h-full"/></td>
                        <td><Skeleton className="w-full h-full"/></td>
                        <td><Skeleton className="w-full h-full"/></td>
                        <td><Skeleton className="w-full h-full"/></td>
                        <td><Skeleton className="w-full h-full"/></td>
                    </tr>)}
            </table>
        </div>

    );
}