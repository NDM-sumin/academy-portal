import { useAppContext } from "../hooks/context/app-bounding-context";

const useSemesterApi = () => {
	const globalContext = useAppContext();
	const axios = globalContext.axios;
	const baseUrl = "api/Semester";
	const create = (semester) => {
		return axios.post(baseUrl, semester);
	};
	const update = (semester) => {
		return axios.put(baseUrl, semester);
	};
	const get = (query) => {
		return axios.get(baseUrl, { params: { $count: true, ...query } });
	};
	const del = (id) => {
		return axios.delete(`${baseUrl}/${id}`);
	};

	const getSemesters = (studentId) => {
		return axios.get(`api/Student/${studentId}/Semesters`);
	};
	return {
		create,
		update,
		get,
		del,
		getSemesters,
	};
};
export default useSemesterApi;
