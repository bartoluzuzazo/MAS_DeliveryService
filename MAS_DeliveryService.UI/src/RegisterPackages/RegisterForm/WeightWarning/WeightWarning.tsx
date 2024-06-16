import {AiOutlineWarning} from "react-icons/ai";
import {FunctionComponent} from "react";

interface Props{
    maxW: number
}

export const WeightWarning : FunctionComponent<Props> = ({maxW}) => {
    return (
        <div>
            <div className="flex flex-row p-1">
                <AiOutlineWarning className="fill-red-600 size-6"/>
                <div className="pl-3">Warning</div>
            </div>
            <div>
                <div>Total weight exceeds the maximum</div>
                <div>weight limit ({maxW}kg). To proceed,</div>
                <div>please remove too heavy items.</div>
            </div>
        </div>
    )
}