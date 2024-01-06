import React, { useState, useEffect } from "react";
import { Table, Select } from "antd";
import useStudentApi from "../../apis/student.api";
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
	const authApi = useAuthApi();

	const currentYear = new Date().getFullYear();
	const [selectedYear, setSelectedYear] = useState(currentYear.toString());
	const [selectedWeek, setSelectedWeek] = useState("");
	const [timetableData, setTimetableData] = useState([]);

	const generateSemesterList = () => {};

	const generateSubjectList = () => {};

	const fetchData = async (currentWeek) => {
		try {
		} catch (error) {
			console.error("Error fetching timetable data", error);
		}
	};

	useEffect(() => {
		fetchData();
	}, [selectedYear]);

	const handleYearChange = (value) => {};

	const handleWeekChange = (value) => {
		fetchData(value);
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
				value
				onChange
				style={{ marginRight: 10, marginBottom: 10 }}
			></Select>

			<Select value onChange></Select>

			<Table dataSource={fakeAttendanceData} columns={columns} />
		</div>
	);
};

export default AttendanceHistory;
