import { useAppContext } from "../hooks/context/app-bounding-context";

const useClassApi = () => {
	const globalContext = useAppContext();
	const axios = globalContext.axios;
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

	const SaveAttendance = (attendanceData) => {
		const attendanceDatas = attendanceData.map((item) => ({
			attendanceId: item.key,
			isAttendance: item.attendance === "present" ? true : false,
		}));
		const attendanceDatasJSON = JSON.stringify(attendanceDatas);

		return axios.post(
			`api/Class/SaveAttendance?attendances=${attendanceDatasJSON}`
		);
	};
	const SaveScores = (scoreData) => {
		const scoreDatas = scoreData.map((item) => {
			const additionalFields = [];
			Object.keys(item).forEach((prop) => {
				if (
					prop !== "id" &&
					prop !== "key" &&
					prop !== "index" &&
					prop !== "studentName"
				) {
					additionalFields.push({ name: prop, value: item[prop] });
				}
			});
			return {
				classId: item.id,
				studentId: item.key,
				scores: additionalFields,
			};
		});

		const scoreDatasJSON = JSON.stringify(scoreDatas);
		return axios.post(`api/Class/SaveScores`, scoreDatasJSON);
	};

	const GetClassInformation = (classId) => {
		return axios.get(`api/Class/GetClassInformation/${classId}`);
	};

	const ClassForNewSemester = () => {
		return axios.post(`api/Class/ClassForNewSemester`);
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
		SaveAttendance,
		SaveScores,
		GetClassInformation,
		ClassForNewSemester,
	};
};
export default useClassApi;
