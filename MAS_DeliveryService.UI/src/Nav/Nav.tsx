import {NavButton} from "./NavButton/NavButton";
import {AiOutlineHome} from "react-icons/ai";
import {FiPackage} from "react-icons/fi";
import {LiaClipboardListSolid} from "react-icons/lia";
import {BsPersonVcard} from "react-icons/bs";
import {FaBars} from "react-icons/fa";

export const Nav = () => {
    return (
        <div className="border border-black rounded-xl shadow-xl p-2 bg-amber-400 h-full min-h-96 static" style={{minHeight: "27rem"}}>
            <div className="p-4">
                <FaBars/>
            </div>
            <div className="p-2">
                <NavButton icon={<AiOutlineHome/>} text={"Dashboard"} link={""}/>
            </div>
            <div className="p-2">
                <NavButton icon={<FiPackage/>} text={"Register packages"} link={"/register-packages"}/>
            </div>
            <div className="p-2">
                <NavButton icon={<LiaClipboardListSolid/>} text={"See orders"} link={"/see-orders"}/>
            </div>
            <div className="p-2">
                <NavButton icon={<BsPersonVcard/>} text={"Manage personnel"} link={"/manage-personnel"}/>
            </div>
        </div>
    )
}