import {FunctionComponent, RefObject} from "react";
import * as React from "react";

interface Props {
    dialog: RefObject<HTMLDialogElement>,
    setStage: any
}

export const CompleteDialog: FunctionComponent<Props> = ({dialog, setStage}) => {

    const handleLaterButton = () => {
        if(dialog.current){
            dialog.current?.close();
            setStage(3);
        }
    }

    return (
        <dialog ref={dialog} className="border border-black rounded-xl shadow-xl p-8 backdrop:bg-black/50">
            <div>
                <h2 className="text-5xl p-8">
                    Package registration complete
                </h2>
                <h3 className="text-4xl p-8 pt-0">
                    Would you like to assign couriers for delivery now?
                </h3>
                <div className="flex flex-col justify-center align-middle">
                    <div className="p-4 flex justify-center">
                        <div
                            className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl bg-gray-400">
                            <div className="pl-8 pr-8">
                                Yes, please
                            </div>
                        </div>
                    </div>
                    <div className="p-4 flex justify-center">
                        <div
                            className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl bg-amber-400"
                            onClick={handleLaterButton}>
                            <div className="pl-8 pr-8">
                                Maybe later
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </dialog>
    )
}