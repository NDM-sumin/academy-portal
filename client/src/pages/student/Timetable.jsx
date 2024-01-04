import React, { useState, useEffect } from "react";
import { Table, Select } from "antd";
import {
	startOfYear,
	addWeeks,
	format,
	startOfWeek as startOfWeek2,
	endOfWeek as endOfWeek2,
	isThisWeek,
} from "date-fns";
import "./Timetable.css";
import useStudentApi from "../../apis/student.api";

const Timetable = () => {
	const studentApi = useStudentApi();
	const currentYear = new Date().getFullYear();
	const [selectedYear, setSelectedYear] = useState(currentYear.toString());
	const [selectedWeek, setSelectedWeek] = useState("");
	const [timetableData, setTimetableData] = useState([]);

	const generateYearList = () => {
		const years = [];
		for (let i = currentYear - 2; i <= currentYear + 2; i++) {
			years.push(i.toString());
		}
		return years;
	};

	const generateWeekList = () => {
		const currentDate = new Date();
		let currentWeek = null;

		const weeks = [];
		for (let i = 0; i < 52; i++) {
			console.log(selectedYear);
			const startOfWeek = startOfWeek2(
				addWeeks(new Date(selectedYear, 0, 1), i)
			);
			const endOfWeek = endOfWeek2(addWeeks(new Date(selectedYear, 0, 1), i));

			const weekLabel = `${format(startOfWeek, "dd/MM")} To ${format(
				endOfWeek,
				"dd/MM"
			)}`;

			weeks.push(weekLabel);

			if (isThisWeek(currentDate, { startOfWeek, weekStartsOn: 1 })) {
				currentWeek = weekLabel;
			}
		}

		return currentWeek ? weeks : weeks.slice(0, 1);
	};

	const fetchData = async () => {
		try {
			const response = await studentApi.getTimeTable();

			if (Array.isArray(response)) {
				const result = [
					{ StartTime: "7h", EndTime: "8h30", SlotName: "Slot_1" },
					{ StartTime: "8h40", EndTime: "10h10", SlotName: "Slot_2" },
					{ StartTime: "10h20", EndTime: "11h50", SlotName: "Slot_3" },
					{ StartTime: "12h30", EndTime: "14h", SlotName: "Slot_4" },
					{ StartTime: "14h10", EndTime: "15h40", SlotName: "Slot_5" },
					{ StartTime: "15h50", EndTime: "17h20", SlotName: "Slot_6" },
				];
				const atWeekArray = response.map((item) => item.atWeek);
				const subject = response.map((item) => item.subject);
				const timeTableArray = response.map((item) => item.timetable);

				const formattedData = result.map((slot) => {
					const timetableEntry = [];

					atWeekArray.forEach((item) => {
						console.log(item);
						const slotTime = item.map((item) => item.slot);

						if (slotTime) {
							const isSlotName = (element) => {
								console.log(slotTime);
								console.log("element: " + element.SlotName);
								console.log("slotTime: " + slotTime[0].slotName);
								return element.slotName === slotTime.slotName;
							};
							const resultIndex = result.findIndex(isSlotName);

							timetableEntry.push({
								index: resultIndex,
								data: {
									subject: item.subject,
									room: item.room,
									isAbsent: item.isAttendance === false,
								},
							});
						}
					});

					return {
						SlotName: slot,
						monday:
							timetableEntry && timeTableArray.weekDay === "Mon"
								? subject.subjectName
								: "-",
						tuesday:
							timetableEntry && timeTableArray.weekDay === "Tue"
								? subject.subjectName
								: "-",

						wednesday:
							timetableEntry && timeTableArray.weekDay === "Wed"
								? subject.subjectName
								: "-",

						thursday:
							timetableEntry && timeTableArray.weekDay === "Thu"
								? subject.subjectName
								: "-",
						friday:
							timetableEntry && timeTableArray.weekDay === "Fri"
								? subject.subjectName
								: "-",
						saturday:
							timetableEntry && timeTableArray.weekDay === "Sat"
								? subject.subjectName
								: "-",
						sunday:
							timetableEntry && timeTableArray.weekDay === "Sun"
								? subject.subjectName
								: "-",
					};
				});
				setTimetableData(formattedData);
			} else {
				console.error("Invalid response format. Expected an array.");
			}
		} catch (error) {
			console.error("Error fetching timetable data", error);
		}
	};

	useEffect(() => {
		fetchData();
		setSelectedWeek(generateWeekList()[0]);
	}, [selectedYear]);

	const handleYearChange = (value) => {
		setSelectedYear(value);
		setSelectedWeek(generateWeekList()[0]);
	};

	const handleWeekChange = (value) => {
		setSelectedWeek(value);
	};

	const columns = [
		{
			title: "Slot",
			dataIndex: "SlotName",
			key: "SlotName",
			align: "center",
			render: (text) => (
				<div>
					{text.SlotName}
					<br />
					{text.StartTime}-{text.EndTime}
				</div>
			),
		},
		{
			title: "MON",
			dataIndex: "monday",
			key: "monday",
			align: "center",
			render: (text, record, index) => {
				console.log(text);
				// Hiển thị văn bản đặc biệt ở ô đầu
				if (index === 0) {
					return <div>{text}</div>;
				}

				// Hiển thị văn bản đặc biệt ở ô cuối
				if (index === timetableData.length - 1) {
					return <div>{text}</div>;
				}

				// Các ô trung gian không có văn bản đặc biệt
				return <div>{text}</div>;
			},
		},
		{
			title: "TUE",
			dataIndex: "tuesday",
			key: "tuesday",
			align: "center",
		},
		{
			title: "WED",
			dataIndex: "wednesday",
			key: "wednesday",
			align: "center",
		},
		{
			title: "THU",
			dataIndex: "thursday",
			key: "thursday",
			align: "center",
		},
		{
			title: "FRI",
			dataIndex: "friday",
			key: "friday",
			align: "center",
		},
		{
			title: "SAT",
			dataIndex: "saturday",
			key: "saturday",
			align: "center",
		},
		{
			title: "SUN",
			dataIndex: "sunday",
			key: "sunday",
			align: "center",
		},
	];

	return (
		<div>
			<Select
				value={selectedYear}
				onChange={handleYearChange}
				style={{ marginRight: 10 }}
			>
				{generateYearList().map((year) => (
					<Select.Option key={year} value={year}>
						{year}
					</Select.Option>
				))}
			</Select>

			<Select value={selectedWeek} onChange={handleWeekChange}>
				{generateWeekList().map((week) => (
					<Select.Option key={week} value={week}>
						{week}
					</Select.Option>
				))}
			</Select>

			<Table
				dataSource={timetableData}
				columns={columns}
				bordered
				pagination={false}
				rowKey={(record) => record.SlotName}
				className="timetable-table"
				onHeaderRow={() => {
					return {
						className: "timetable-header",
					};
				}}
				onRow={() => {
					return {
						className: "timetable-row",
					};
				}}
			/>
		</div>
	);
};

export default Timetable;
