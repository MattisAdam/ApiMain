import axios from 'axios';
import { useQuery } from 'react-query';


export interface Person{
    id: number,
    name: string 
}

export const fetchPerson = async (id: number) =>{
    console.log("fetch", id)
    console.log(`https://localhost:7014/api/person/${id}`)
    const response = await axios.get<Person>((`https://localhost:7014/api/person/${id}`));
    console.log("Waf", response.data)
    return response.data
}


export const GetPersonById = (id: number) => {
    console.log("coucou")
    const { data, isLoading, refetch, isRefetching } = useQuery(
        [(`person/${id}`), id],
        () => fetchPerson(id),
        { enabled: true, staleTime: Infinity }
    );
    console.log("test1", data?.id, data?.name)
    return { data, isLoading, refetch, isRefetching};
};