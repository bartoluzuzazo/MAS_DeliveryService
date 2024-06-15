import * as React from "react";
import {IPackage} from "../RegisterPackages";
import {FunctionComponent, useRef} from "react";
import {PackagePanel} from "./PackagePanel/PackagePanel";
import {TiTickOutline} from "react-icons/ti";
import axios from "axios";
import {CompleteDialog} from "./CompleteDialog/CompleteDialog";

interface Props {
    packages: IPackage[],
    orderId: string,
    setStage: any
}

export const PackageSummary: FunctionComponent<Props> = ({packages, orderId, setStage}) => {

    const dialog = useRef<HTMLDialogElement>(null);
    const handleDialog = () => {
        if(dialog.current) dialog.current.showModal();
    }

    const handleFinish = () => {
        const PackagesDTO = {
            Packages: packages.map(p => {
                return {
                    SerialNumber : p.serialNumber,
                    Comment : p.comment,
                    ItemIds : p.items.map(i => i.id)
                }
            }),
            OrderId: orderId
        }

        axios.post("http://localhost:5168/api/Package", PackagesDTO).then(()=>{
            // setStage(3)
            handleDialog();
        }).catch((e)=>console.log(e));
    }

    return (
        <div className="flex flex-row">
        <div>
                <h2 className="text-5xl pl-8 pt-4">
                    Summary
                </h2>
                {packages.map(p => <PackagePanel Package={p}/>)}
            </div>
            <div className="flex flex-col-reverse pl-16">
                <div
                    className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl bg-amber-400"
                    onClick={handleFinish}>
                    <div className="p-1"><TiTickOutline/></div>
                    <div className="pl-8 pr-8">Finish</div>
                </div>
            </div>
            <CompleteDialog dialog={dialog} setStage={setStage}/>
        </div>
    )
}