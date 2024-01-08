import React, { useState, useEffect } from "react";
import { Table, Select } from "antd";
import useStudentApi from "../../apis/student.api";
import useSemesterApi from "../../apis/semester.api";
import useSubjectApi from "../../apis/subject.api";
import useAuthApi from "../../apis/auth.api";
import dayjs from "dayjs";

const AttendanceHistory = () => {
	const studentApi = useStudentApi();
	const semesterApi = useSemesterApi();
	const subjectApi = useSubjectApi();
	const authApi = useAuthApi();

	const [selectedSemester, setSelectedSemester] = useState("");
	const [selectedSubject, setSelectedSubject] = useState("");
	const [semesterData, setSemesterData] = useState([]);
	const [subjectData, setSubjectData] = useState([]);
	const [AttendanceData, setAttendanceData] = useState([]);
	const [userId, setUserId] = useState(null);

	const getUser = async () => {
		try {
			const user = await authApi.getCurrentUser();
			setUserId(user.id);
			return user.id;
		} catch (error) {
			console.error("Error getting user", error);
			return null;
		}
	};

	const generateSemesterList = async () => {
		try {
			const userId = await getUser();
			const semesters = await studentApi.getSemesters(userId);
			setSelectedSemester(semesters.current.id);

			return {
				semesters: semesters.semesters,
				currentSemester: semesters.current.id,
			};
		} catch (error) {
			console.error("Error fetching semesters", error);
			return [];
		}
	};

	const generateSubjectList = async (currentSemester) => {
		try {
			var subjects = [];
			const userId = await getUser();
			subjects = await subjectApi.GetSubjects(currentSemester, userId);
			setSelectedSubject((await subjects)[0].id);
			return { subjects: subjects, currentSubject: (await subjects)[0].id };
		} catch (error) {
			console.error("Error fetching semesters", error);
			return [];
		}
	};

	const fetchData = async (currentSemester, currentsubject) => {
		try {
			const userId = await getUser();
			const attendances = await studentApi.getAttendances(
				userId,
				currentSemester,
				currentsubject
			);

			const attendanceHistoryList = [];
			attendances.attendances.forEach((element, index) => {
				const attendanceStatus =
					element.isAttendance === null
						? "chưa điểm danh"
						: element.isAttendance
						? "có mặt"
						: "vắng";
				const attendanceHistory = {
					id: index + 1,
					key: index + 1,
					date: dayjs(element.date).format("DD/MM/YYYY"),
					room: element.room.roomCode,
					slot: element.slotTimeTableAtWeek.slot.slotName,
					teacher: attendances.teacher.fullName,
					class: attendances.class.classCode,
					attendanceStatus: attendanceStatus,
				};

				attendanceHistoryList.push(attendanceHistory);
			});

			setAttendanceData(attendanceHistoryList);
		} catch (error) {
			console.error("Error fetching timetable data", error);
		}
	};

	useEffect(() => {
		const fetchAndSetSemesters = async () => {
			const semesterList = await generateSemesterList();
			const semesters = semesterList.semesters;
			const currentSemester = semesterList.currentSemester;

			setSemesterData(semesters);
			const subjectList = await generateSubjectList(currentSemester);
			const subjects = subjectList.subjects;
			const currentsubject = subjectList.currentSubject;

			setSubjectData(subjects);
			fetchData(currentSemester, currentsubject);
		};
		fetchAndSetSemesters();
	}, [userId]);

	const handleSemesterChange = async (value) => {
		setSelectedSemester(value);
		const subjectList = await generateSubjectList(value);
		const subjects = subjectList.subjects;
		const currentsubject = subjectList.currentSubject;
		fetchData(value, currentsubject);
		setSubjectData(subjects);
	};

	const handleSubjectChange = async (value) => {
		setSelectedSubject(value);
		fetchData(selectedSemester, value);
	};

	const columns = [
		{ title: "STT", dataIndex: "id", key: "id", align: "center" },
		{ title: "NGÀY", dataIndex: "date", key: "date", align: "center" },
		{ title: "SLOT", dataIndex: "slot", key: "slot", align: "center" },
		{
			title: "PHÒNG",
			dataIndex: "room",
			key: "room",
			align: "center",
		},
		{
			title: "GIẢNG VIÊN",
			dataIndex: "teacher",
			key: "teacher",
			align: "center",
		},
		{ title: "LỚP", dataIndex: "class", key: "class", align: "center" },
		{
			title: "TÌNH TRẠNG ĐIỂM DANH",
			dataIndex: "attendanceStatus",
			key: "attendanceStatus",
			align: "center",
			render: (text, record) => {
				let color;
				if (record.attendanceStatus === "chưa điểm danh") {
					color = "black";
				} else if (record.attendanceStatus === "có mặt") {
					color = "green";
				} else if (record.attendanceStatus === "vắng") {
					color = "red";
				}

				return <span style={{ color }}>{text}</span>;
			},
		},
	];

	return (
		<div>
			<Select
				value={selectedSemester}
				onChange={handleSemesterChange}
				style={{ marginRight: 10, marginBottom: 10 }}
			>
				{semesterData.map((semester) => (
					<Select.Option key={semester.id} value={semester.id}>
						{semester.semesterName}
					</Select.Option>
				))}
			</Select>

			<Select value={selectedSubject} onChange={handleSubjectChange}>
				{subjectData.map((subject) => (
					<Select.Option key={subject.id} value={subject.id}>
						{subject.subjectName}
					</Select.Option>
				))}
			</Select>

			<Table dataSource={AttendanceData} columns={columns} />
		</div>
	);
};

export default AttendanceHistory;
