import { createSlice, PayloadAction } from "@reduxjs/toolkit"

interface PersonState{
    id: number | null
}
const initialState: PersonState = {
id: null
}

const personReducer = createSlice({
    name: "person",
    initialState,
    reducers: {
        setPersonId: (state, action: PayloadAction<number>) => {
            state.id = action.payload;
        },
    },
});

export const {setPersonId} = personReducer.actions;
export default personReducer.reducer;