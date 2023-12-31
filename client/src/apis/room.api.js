import { useAppContext } from "../hooks/context/app-bounding-context";

const useRoomApi = () => {
	const globalContext = useAppContext();
	const axios = globalContext.axios;
	const baseUrl = "odata/Room";
	const create = (room) => {
		return axios.post("api/Room", room);
	};
	const update = (room) => {
		return axios.put("api/Room", room);
	};
	const get = (query) => {
		return axios.get("api/Room", { params: { $count: true, ...query } });
	};
	const del = (id) => {
		return axios.delete(`api/Room/${id}`);
	};
	return {
		create,
		update,
		get,
		del,
	};
};
export default useRoomApi;
