import {FunctionComponent, useEffect, useRef, useState} from "react";
import {IOrder} from "../OrderList/OrderList";
import * as React from "react";
import {BsArrowRightCircle} from "react-icons/bs";
import {IItem} from "../OrderList/ItemList/ItemList";
import {IPackage} from "../RegisterPackages";
import {ItemSelection} from "../RegisterForm/ItemSelection/ItemSelection";
import {WeightWarning} from "../RegisterForm/WeightWarning/WeightWarning";
import {WarningDialog} from "./WarningDialog/WarningDialog";

interface Props {
    order: IOrder,
    editedPackage: IPackage,
    addPackage: any,
    setStage: any,
    allItems: IItem[],
    packages: IPackage[]
}

export const EditForm: FunctionComponent<Props> = ({order, addPackage, setStage, editedPackage, allItems, packages}) => {

    const [SelectedItems, SetSelectedItems] = useState<IItem[]>(editedPackage.items)
    const [Weight, SetWeight] = useState(0.0)
    const [SerialNumber, SetSerialNumber] = useState(editedPackage.serialNumber)
    const [Comment, SetComment] = useState<string>(editedPackage.comment)
    const warningDialog = useRef<HTMLDialogElement>(null);
    const [Deleted, SetDeleted] = useState<IPackage[]>([])

    useEffect(() => {
        const weight = SelectedItems.map(i => i.weight).reduce((sum, weight) => sum + weight, 0);
        SetWeight(weight);
    }, [SelectedItems]);

    const handleNext = () => {
        editedPackage.items.forEach((i) => {
            const index = SelectedItems.indexOf(i)
            if (index === -1) {
                order.items.push(i);
            }
        })
        editedPackage.items = SelectedItems;
        editedPackage.comment = Comment;

        packages.forEach((p)=> {
            if(p === editedPackage) return;
            SelectedItems.forEach((i) => {
                const index = p.items.indexOf(i)
                if (index !== -1){
                    p.items.splice(index, 1);
                }
            })
            if(p.items.length === 0){
                Deleted.push(p);
            }
        })

        Deleted.forEach((d) => {
            const index = packages.indexOf(d);
            if (index !== -1){
                packages.splice(packages.indexOf(d), 1);
            }
        })

        if(Deleted.length === 0){
            if (order.items.length > 0) {
                setStage(1)
            } else {
                setStage(2);
            }
        }
        else {
            SetDeleted([...Deleted]);
            if (warningDialog.current) warningDialog.current.showModal();
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
                        <ItemSelection items={allItems} selectedItems={SelectedItems}
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
                        {Comment}
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
            <WarningDialog dialog={warningDialog} setStage={setStage} deleted={Deleted.map(d => d.serialNumber)} order={order}/>
        </div>
    )
}