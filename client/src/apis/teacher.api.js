import { useAppContext } from "../hooks/context/app-bounding-context";

const useTeacherApi = () => {
	const globalContext = useAppContext();
	const axios = globalContext.axios;
	const baseUrl = "odata/Teacher";
	const create = (teacher) => {
		return axios.post("api/Teacher", teacher);
	};
	const update = (teacher) => {
		return axios.put("api/Teacher", teacher);
	};
	const get = (query) => {
		return axios.get("api/Teacher", { params: { ...query } });
	};
	const del = (id) => {
		return axios.delete(`api/Teacher/${id}`);
	};
	const getTimeTable = (teacherId) => {
		return axios.get(`api/Teacher/GetTimeTable?teacherId=${teacherId}`);
	};
	return {
		create,
		update,
		get,
		del,
		getTimeTable,
	};
};
export default useTeacherApi;
