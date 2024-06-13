import { Route, Routes} from "react-router-dom";
import {RegisterPackages} from "../RegisterPackages/RegisterPackages";

export const Router = () => {
    return(
            <Routes>
                <Route path="/register-packages" element={<RegisterPackages/>}/>
                <Route path="*" element={null}/>
            </Routes>
    )
}