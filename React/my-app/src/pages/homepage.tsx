
import {Button} from '@mui/material'
import { useNavigate } from "react-router-dom";
const Homepage = () =>{
    
const navigate = useNavigate();
 const handleClickList = () => {
      navigate("Person/list");
    };
    return(
        <>
            <Button
                onClick={handleClickList}
                variant="contained"
                sx={{color: 'black'}}
            >
                List
            </Button>
            
        </>    
    )


}

export default Homepage