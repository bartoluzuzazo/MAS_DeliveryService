import {FunctionComponent} from "react";
import {useNavigate} from "react-router-dom";

interface Props{
    icon: any,
    text: string,
    link: string
}

export const NavButton : FunctionComponent<Props> = ({icon, link, text}) => {

    const Navigator = useNavigate();

    const HandleNavigate = () => {
        Navigator(link);
    }

    return(
        <div className="border border-black rounded-lg shadow-lg p-3 flex flex-row justify-between cursor-pointer select-none text-2xl" onClick={HandleNavigate}>
            <div className="p-1">{icon}</div>
            <div>{text}</div>
        </div>
    )
}