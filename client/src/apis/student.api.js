import { useAppContext } from "../hooks/context/app-bounding-context";

const useStudentApi = () => {
	const globalContext = useAppContext();
	const axios = globalContext.axios;
	const baseUrl = "api/Student";
	const create = (student) => {
		return axios.post(baseUrl, student);
	};
	const update = (student) => {
		return axios.put(baseUrl, student);
	};
	const get = (query) => {
		return axios.get(baseUrl, {
			params: { $count: true, ...query, $expand: "Major" },
		});
	};
	const del = (id) => {
		return axios.delete(`${baseUrl}/${id}`);
	};

	const importData = (file) => {
		return axios.post(`${baseUrl}/Import`, file, {
			headers: {
				"Content-Type":
					"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
			},
		});
	};

	const getTimeTable = (studentId) => {
		return axios.get("api/Student/GetTimeTable?studentId=" + studentId);
	};

	const getSlots = () => {
		return axios.get("api/Slot/GetAll");
	};
	const getSemesters = (studentId) => {
		return axios.get(`${baseUrl}/${studentId}/Semesters`);
	};
	const getAttendances = (studentId, semesterId, subjectId) => {
		return axios.get(
			`${baseUrl}/GetAttendances/${studentId}/${semesterId}/${subjectId}`
		);
	};
	const getScores = (studentId, subjectId) => {
		return axios.get(`${baseUrl}/GetScores/${studentId}/${subjectId}`);
	};
	return {
		create,
		update,
		get,
		del,
		importData,
		getTimeTable,
		getSlots,
		getSemesters,
		getAttendances,
		getScores,
	};
};
export default useStudentApi;
