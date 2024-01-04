import React from "react";
import { Table } from "antd";

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
	// Add more fake data as needed
];

const columns = [
	{ title: "NO.", dataIndex: "id", key: "id" },
	{ title: "DATE", dataIndex: "date", key: "date" },
	{ title: "SLOT", dataIndex: "slot", key: "slot" },
	{ title: "ROOM", dataIndex: "room", key: "room" },
	{ title: "LECTURER", dataIndex: "lecturer", key: "lecturer" },
	{ title: "GROUP NAME", dataIndex: "groupName", key: "groupName" },
	{
		title: "ATTENDANCE STATUS",
		dataIndex: "attendanceStatus",
		key: "attendanceStatus",
	},
];

const AttendanceHistory = () => {
	return (
		<div>
			<Table dataSource={fakeAttendanceData} columns={columns} />
		</div>
	);
};

export default AttendanceHistory;
