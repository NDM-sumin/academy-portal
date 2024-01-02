import { useAppContext } from "../hooks/context/app-bounding-context";

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
	return {
		create,
		update,
		get,
		del,
		importData,
	};
};
export default useStudentApi;
