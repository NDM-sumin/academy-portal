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
		return axios.get("api/Subject", { params: { ...query } });
	};
	const del = (id) => {
		return axios.delete(`api/Subject/${id}`);
	};
	const getRegisterableSubjects = () => {
		return axios.get("api/Subject/GetRegisterableSubjects");
	};
	const GetSubjects = (semesterId, studentId) => {
		return axios.get(`api/Subject/GetSubjects/${semesterId}/${studentId}`);
	};
	const GetPayUrl = (subjectIds) => {
	
		return axios.post(`api/Subject/GetPayUrl`, JSON.stringify(subjectIds))


	}
	return {
		create,
		update,
		get,
		del,
		getRegisterableSubjects,
		GetSubjects,
		GetPayUrl
	};
};
export default useSubjectApi;
