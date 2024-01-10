import { useAppContext } from "../hooks/context/app-bounding-context";

const useClassApi = () => {
	const globalContext = useAppContext();
	const axios = globalContext.axios;
	const baseUrl = "odata/Class";
	const create = (Class) => {
		return axios.post("api/Class", Class);
	};
	const update = (Class) => {
		return axios.put("api/Class", Class);
	};
	const get = (query) => {
		return axios.get("api/Class", { params: { ...query } });
	};
	const del = (id) => {
		return axios.delete(`api/Class/${id}`);
	};
	const GetClasses = (teacherId) => {
		return axios.get(`api/Class/GetClasses/${teacherId}`);
	};
	const GetStudents = (classId) => {
		return axios.get(`api/Class/GetStudents/${classId}`);
	};
	const GetSubjectComponents = (classId) => {
		return axios.get(`api/Class/GetSubjectComponents/${classId}`);
	};
	const GetAttendances = (classId, dateTime) => {
		return axios.get(`api/Class/GetAttendances/${classId}`, {
			params: {
				dateTime: dateTime,
			},
		});
	};
	const GetDates = (classId) => {
		return axios.get(`api/Class/GetDates/${classId}`);
	};
	return {
		create,
		update,
		get,
		del,
		GetClasses,
		GetStudents,
		GetSubjectComponents,
		GetAttendances,
		GetDates,
	};
};
export default useClassApi;
