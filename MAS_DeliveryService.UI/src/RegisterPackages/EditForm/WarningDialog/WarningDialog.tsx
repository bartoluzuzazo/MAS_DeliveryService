import {FunctionComponent, RefObject, useEffect} from "react";
import * as React from "react";
import {IOrder} from "../../OrderList/OrderList";

interface Props {
    dialog: RefObject<HTMLDialogElement>,
    setStage: any,
    deleted: string[],
    order: IOrder
}

export const WarningDialog: FunctionComponent<Props> = ({dialog, setStage, deleted, order}) => {

    const handleContinueButton = () => {
        if(dialog.current){
            dialog.current?.close();
            if (order.items.length > 0) {
                setStage(1)
            } else {
                setStage(2);
            }
        }
    }

    return (
        <dialog ref={dialog} className="border border-black rounded-xl shadow-xl p-8 backdrop:bg-black/50">
            <div>
                <h2 className="text-5xl p-8">
                    Package removed
                </h2>
                <h3 className="text-4xl p-8 pt-0 max-w-96">
                    Packages: {deleted.map(d => <div>{d}</div>)} have been removed due to all their items having been assigned elsewhere.
                </h3>
                <div className="flex flex-col justify-center align-middle">
                    <div className="p-4 flex justify-center">
                        <div
                            className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl bg-amber-400"
                            onClick={handleContinueButton}>
                            <div className="pl-8 pr-8">
                                Continue
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </dialog>
    )
}