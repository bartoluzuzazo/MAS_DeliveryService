import {FunctionComponent} from "react";
import {IOrder} from "../OrderList/OrderList";
import * as React from "react";

interface Props{
    order: IOrder
}

export const RegisterForm : FunctionComponent<Props> = ({order}) => {

    return(
        <div>
            <h2 className="text-5xl p-8">
                Please fill in the details
            </h2>

        </div>
    )
}