import { useAppContext } from "../hooks/context/app-bounding-context";
import { USER_TOKEN_KEY } from "../utils/constants";

const useStudentApi = () => {
	const globalContext = useAppContext();
	const axios = globalContext.axios;
	const baseUrl = "odata/Student";
	const create = (student) => {
		return axios.post("api/Student", student);
	};
	const update = (student) => {
		return axios.put("api/Student", student);
	};
	const get = (query) => {
		return axios.get("api/Student", {
			params: { $count: true, ...query, $expand: "Major" },
		});
	};
	const del = (id) => {
		return axios.delete(`api/Student/${id}`);
	};

	const importData = (file) => {
		return axios.post("api/Student/Import", file, {
			headers: {
				"Content-Type":
					"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
			},
		});
	};

	const getTimeTable = (studentId) => {
		studentId = "9F130625-F329-4417-8B55-B1777022CE57";
		return axios.get("api/Student/GetTimeTable?studentId=" + studentId);
	};
	return {
		create,
		update,
		get,
		del,
		importData,
		getTimeTable,
	};
};
export default useStudentApi;
