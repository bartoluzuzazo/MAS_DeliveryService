import {FunctionComponent} from "react";
import * as React from "react";
import {IPackage} from "../../RegisterPackages";
import {ItemList} from "../../OrderList/ItemList/ItemList";
import {AiOutlineEdit} from "react-icons/ai";

interface Props {
    Package: IPackage,
    handleEdit: any
}

export const PackagePanel: FunctionComponent<Props> = ({Package, handleEdit}) => {
    return (
        <div>
            <div className="flex flex-row">
                <h3 className="text-4xl pl-8 pt-10">
                    {Package.serialNumber}
                </h3>
                <div className="pl-8 pt-10 flex flex-col-reverse pb-1 =">
                    <AiOutlineEdit className="size-8 cursor-pointer" onClick={() => handleEdit(Package)}/>
                </div>
            </div>
            <div className="pl-8 pt-4 flex flex-row justify-between">
                <div>
                    <div>
                        Total weight:
                    </div>
                    <div>
                        Comment:
                    </div>
                </div>
                <div>
                    <div>
                        {Package.items.map(i => i.weight).reduce((sum, weight) => sum + weight, 0)}kg
                    </div>
                    <div>
                        {Package.comment.length === 0 ? <div className="text-gray-400">none</div> :
                            <div>{Package.comment}</div>}
                    </div>
                </div>
            </div>
            <div className="pl-8 pt-4">
                <div className="border border-black">
                    <ItemList items={Package.items}/>
                </div>
            </div>
        </div>
    )
}