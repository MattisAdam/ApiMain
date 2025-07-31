import { BrowserRouter, Route, Routes } from "react-router-dom"
import Homepage from "../pages/homepage"
import PersonTable from "../component/PersonTable"


export const RoutesConfig = () =>{
    return(
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="" element={<Homepage/>}/>
                    <Route path="Person/list" element={<PersonTable/>}></Route>
                </Routes>
            </BrowserRouter>
        </>
    )
}