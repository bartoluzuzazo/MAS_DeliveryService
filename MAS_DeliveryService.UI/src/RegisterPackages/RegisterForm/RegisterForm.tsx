import {FunctionComponent, useEffect, useState} from "react";
import {IOrder} from "../OrderList/OrderList";
import * as React from "react";
import {ItemSelection} from "./ItemSelection/ItemSelection";
import {BsArrowRightCircle} from "react-icons/bs";
import {IItem} from "../OrderList/ItemList/ItemList";
import {IPackage} from "../RegisterPackages";
import {WeightWarning} from "./WeightWarning/WeightWarning";

interface Props {
    order: IOrder,
    addPackage: any
    setStage: any
}

export const RegisterForm: FunctionComponent<Props> = ({order, addPackage, setStage}) => {

    const [SelectedItems, SetSelectedItems] = useState<IItem[]>([])
    const [Weight, SetWeight] = useState(0.0)
    const [SerialNumber, SetSerialNumber] = useState("")
    const [Comment, SetComment] = useState<string>("")

    useEffect(() => {
        handleNewSerialNumber();
    }, [])

    useEffect(() => {
        const weight = SelectedItems.map(i => i.weight).reduce((sum, weight) => sum + weight, 0);
        SetWeight(weight);
    }, [SelectedItems]);

    const handleNewSerialNumber = () => {
        SetSerialNumber("PL" + Date.now() + order.sender.charAt(0).toUpperCase()
            + order.clientFirstName.charAt(0).toUpperCase() + order.clientLastName.charAt(0).toUpperCase());
    }

    const handleNext = () => {
        const Package: IPackage = {
            serialNumber: SerialNumber,
            items: SelectedItems,
            comment: Comment
        }
        addPackage(Package);
        if (order.items.length > 0) {
            SetSelectedItems([]);
            handleNewSerialNumber();
        } else {
            setStage(2);
        }
    }

    return (
        <div className="flex flex-row">
            <div>
                <h2 className="text-5xl pl-8 pt-4">
                    Please fill in the details
                </h2>
                <h3 className="text-4xl pl-8 pt-10">
                    Items available:
                </h3>
                <div className="pl-8 pt-4">
                    <div className="border border-black">
                        <ItemSelection items={order.items} selectedItems={SelectedItems}
                                       setSelectedItems={SetSelectedItems}/>
                    </div>
                </div>
                <h3 className="text-4xl pl-8 pt-10">
                    Comment:
                </h3>
                <div className="pl-8 pt-4">
                    <div className="border border-black rounded-lg shadow-lg">
                    <textarea rows={1} cols={60} placeholder="Optional" className="resize-none outline-none p-4"
                              onChange={(e) => SetComment(e.target.value)}>
                    </textarea>
                    </div>
                </div>
                <h3 className="text-4xl pl-8 pt-10">
                    Summary
                </h3>
                <div className="pl-8 pt-4 flex flex-row justify-between">
                    <div>
                        <div>
                            Serial number:
                        </div>
                        <div>
                            From:
                        </div>
                        <div>
                            To:
                        </div>
                        <div>
                            Address:
                        </div>
                        <div>
                            Total weight:
                        </div>
                    </div>
                    <div>
                        <div>
                            {SerialNumber}
                        </div>
                        <div>
                            {order.sender}
                        </div>
                        <div>
                            {order.clientFirstName} {order.clientLastName}
                        </div>
                        <div>
                            {order.destination}
                        </div>
                        <div>
                            {Weight}kg
                        </div>
                    </div>
                </div>
            </div>
            <div className="flex flex-col justify-between pl-16">
                {
                    !(Weight < 35.0) &&
                    <div className="pt-44">
                        <WeightWarning/>
                    </div>
                }
                {
                    (Weight < 35.0) &&
                    <div></div>
                }
                {
                    (Weight > 0.0 && Weight < 35.0) &&
                    <div
                        className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl bg-amber-400 max-w-40"
                        onClick={handleNext}>
                        <div className="p-1"><BsArrowRightCircle/></div>
                        <div className="pl-8 pr-8">Next</div>
                    </div>
                }
                {
                    !(Weight > 0.0 && Weight < 35.0) &&
                    <div
                        className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl bg-gray-400 max-w-40">
                        <div className="p-1"><BsArrowRightCircle/></div>
                        <div className="pl-8 pr-8">Next</div>
                    </div>
                }
            </div>
        </div>
    )
}