import { useAppContext } from "../hooks/context/app-bounding-context";

const useSubjectApi = () => {
	const globalContext = useAppContext();
	const axios = globalContext.axios;
	const baseUrl = "odata/Subject";
	const create = (subject) => {
		return axios.post("api/Subject", subject);
	};
	const update = (subject) => {
		return axios.put("api/Subject", subject);
	};
	const get = (query) => {
		return axios.get("api/Subject", { params: { $count: true, ...query } });
	};
	const del = (id) => {
		return axios.delete(`api/Subject/${id}`);
	};
	return {
		create,
		update,
		get,
		del,
	};
};
export default useSubjectApi;
