import { BrowserRouter, Route, Routes } from "react-router-dom"
import Homepage from "../pages/homepage"


export const RoutesConfig = () =>{
    return(
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="" element={<Homepage/>}/>
                </Routes>
            </BrowserRouter>
        </>
    )
}