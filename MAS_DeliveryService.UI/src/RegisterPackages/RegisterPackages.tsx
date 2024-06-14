import {IOrder, OrderList} from "./OrderList/OrderList";
import {RegisterForm} from "./RegisterForm/RegisterForm";
import {useState} from "react";
import {IItem} from "./OrderList/ItemList/ItemList";
import {PackageSummary} from "./PackageSummary/PackageSummary";

export interface IPackage {
    serialNumber: string,
    items: IItem[],
    comment: string
}

export const RegisterPackages = () => {

    const [Order, SetOrder] = useState<IOrder>();
    const [Stage, SetStage] = useState<number>(0);
    const [Packages, SetPackages] = useState<IPackage[]>([]);

    const AddPackage = (Package: IPackage) => {
        const packages = [...Packages];
        packages.push(Package);
        SetPackages(packages);
        
        Package.items.forEach(i => {
            const index = Order!.items.indexOf(i);
            Order!.items.splice(index, 1);
        })
        console.log(Order!.items);
        console.log(packages);
    }
    
    return(
        <div>
            <h1 className="text-6xl p-8">
                Register packages
            </h1>

            {
                Stage===0 && <OrderList setOrder={SetOrder} setStage={SetStage}/>
            }
            {
                Stage===1 && <RegisterForm order={Order!} addPackage={AddPackage} setStage={SetStage}/>
            }
            {
                Stage===2 && <PackageSummary packages={Packages}/>
            }

        </div>
    )
}