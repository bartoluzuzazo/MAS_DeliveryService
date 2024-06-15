import * as React from "react";
import {useNavigate} from "react-router-dom";

export const Complete = () => {

    const Navigator = useNavigate();

    return(
        <div>
            <h2 className="text-5xl pl-8 pt-4">
                Package registration complete
            </h2>
            <div className="flex flex-col">
                <div className="p-8 flex">
                    <div className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl bg-gray-400">
                        <div className="pl-8 pr-8">See created packages here</div>
                    </div>
                </div>
                <div className="p-8 pt-0 flex">
                    <div className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl bg-amber-400"
                         onClick={() => Navigator(0)}>
                        <div className="pl-8 pr-8">Register packages for another order</div>
                    </div>
                </div>
            </div>
        </div>
    )
}