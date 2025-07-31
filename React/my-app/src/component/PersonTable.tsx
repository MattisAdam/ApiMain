import {Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper,IconButton, Button, Menu, MenuItem, Tooltip, Box, Typography} from '@mui/material';
import {GetPersonById} from "../httpRequest/personRequest"
const PersonTable=()=>{

const Person = GetPersonById(1);

    return(
        <TableContainer>
                <Table>
                    <TableHead>
                       <TableRow>
                        <TableCell>Id</TableCell>
                        <TableCell>Name</TableCell>
                        </TableRow> 
                    </TableHead>
                    <TableBody>
                        <TableRow>
                            <TableCell>{Person.data?.id}</TableCell>
                            <TableCell>{Person.data?.name}</TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </TableContainer>
    )
}

export default PersonTable;