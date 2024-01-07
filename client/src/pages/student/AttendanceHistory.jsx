import React, { useState, useEffect } from "react";
import { Table, Select } from "antd";
import useStudentApi from "../../apis/student.api";
import useSemesterApi from "../../apis/semester.api";
import useSubjectApi from "../../apis/subject.api";
import useAuthApi from "../../apis/auth.api";

const AttendanceHistory = () => {
	const fakeAttendanceData = [
		{
			id: 1,
			date: "2023-09-05",
			slot: "4_(12:50-14:20)",
			room: "R01",
			lecturer: "HuongKT",
			groupName: "PC1806.P1",
			attendanceStatus: "Present",
		},
	];
	const studentApi = useStudentApi();
	const semesterApi = useSemesterApi();
	const subjectApi = useSubjectApi();
	const authApi = useAuthApi();

	const [selectedSemester, setSelectedSemester] = useState("");
	const [selectedSubject, setSelectedSubject] = useState("");
	const [semesterData, setSemesterData] = useState([]);
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
			console.log(semesters);
			return semesters;
		} catch (error) {
			console.error("Error fetching semesters", error);
			return [];
		}
	};

	const fetchData = async (currentWeek) => {
		try {
			// Implement fetching data as needed
		} catch (error) {
			console.error("Error fetching timetable data", error);
		}
	};

	useEffect(() => {
		const fetchAndSetSemesters = async () => {
			const semesters = await generateSemesterList();
			setSemesterData(semesters);
		};

		fetchAndSetSemesters();
	}, [userId]);

	const handleSemesterChange = (value) => {
		setSelectedSemester(value);
	};

	const handleSubjectChange = (value) => {
		setSelectedSubject(value);
	};

	const columns = [
		{ title: "NO.", dataIndex: "id", key: "id" },
		{ title: "DATE", dataIndex: "date", key: "date" },
		{ title: "SLOT", dataIndex: "slot", key: "slot" },
		{ title: "ROOM", dataIndex: "room", key: "room" },
		{ title: "LECTURER", dataIndex: "lecturer", key: "lecturer" },
		{ title: "CLASS", dataIndex: "class", key: "class" },
		{
			title: "ATTENDANCE STATUS",
			dataIndex: "attendanceStatus",
			key: "attendanceStatus",
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
					<Select.Option
						key={semester.semesterId}
						value={semester.semesterName}
					>
						{semester.semesterName}
					</Select.Option>
				))}
			</Select>

			<Select value={selectedSubject} onChange={handleSubjectChange}>
				{/* Implement rendering of subject options */}
			</Select>

			<Table dataSource={fakeAttendanceData} columns={columns} />
		</div>
	);
};

export default AttendanceHistory;
