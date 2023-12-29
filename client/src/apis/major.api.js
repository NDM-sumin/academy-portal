import { useAppContext } from "../hooks/context/app-bounding-context";


const useMajorApi = () => {
    const globalContext = useAppContext();
    const axios = globalContext.axios;
    const baseUrl = 'odata/Major'
    const create = (major) => {
        return axios.post('api/Major', major);
    }
    const update = (major) => {
        return axios.put('api/Major', major);
    }
    const get = (query) => {
        return axios.get('api/Major', { params: { $count: true, ...query } });
    }
    const del = (id) => {
        return axios.delete(`api/Major/${id}`)
    }
    return {
        create,
        update,
        get,
        del
    }
}
export default useMajorApi