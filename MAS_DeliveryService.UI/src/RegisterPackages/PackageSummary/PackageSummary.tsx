import * as React from "react";
import {IPackage} from "../RegisterPackages";
import {FunctionComponent} from "react";
import {PackagePanel} from "./PackagePanel/PackagePanel";
import {BsArrowRightCircle} from "react-icons/bs";
import {TiTickOutline} from "react-icons/ti";

interface Props {
    packages: IPackage[]
}

export const PackageSummary: FunctionComponent<Props> = ({packages}) => {

    const handleFinish = () => {

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
        </div>
    )
}