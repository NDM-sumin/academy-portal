import React, { useState, useEffect } from "react";
import { Table, Select } from "antd";
import {
	startOfYear,
	addWeeks,
	format,
	startOfWeek as startOfWeek2,
	endOfWeek as endOfWeek2,
	isThisWeek,
	startOfWeek,
	addDays,
} from "date-fns";
import "./Timetable.css";

import useStudentApi from "../../apis/student.api";
import useAuthApi from "../../apis/auth.api";

const Timetable = () => {
	const studentApi = useStudentApi();
	const authApi = useAuthApi();

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
			const startOfWeek = startOfWeek2(
				addWeeks(new Date(selectedYear, 0, 1), i)
			);
			const endOfWeek = endOfWeek2(addWeeks(new Date(selectedYear, 0, 1), i));

			const weekLabel = `${format(startOfWeek, "dd/MM")} To ${format(
				endOfWeek,
				"dd/MM"
			)}`;

			weeks.push(weekLabel);

			if (isThisWeek(startOfWeek, { weekStartsOn: 1 })) {
				currentWeek = weekLabel;
			}
		}

		return currentWeek ? weeks : weeks.slice(0, 1);
	};

	const fetchData = async (currentWeek) => {
		try {
			const user = await authApi.getCurrentUser();

			const [slots, timetableData] = await Promise.all([
				studentApi.getSlots(),
				studentApi.getTimeTable(user.id),
			]);

			const formattedData = slots.map((slot) => {
				const slotData = {
					SlotName: `Slot_${slot.slotName} (${slot.startTime} - ${slot.endTime})`,
				};
				timetableData.forEach((item) => {
					if (item.atWeek && Array.isArray(item.atWeek)) {
						item.atWeek.forEach((slotTimeTable) => {
							console.log(item);
							if (
								`Slot_${slotTimeTable.slot.slotName} (${slotTimeTable.slot.startTime} - ${slotTimeTable.slot.endTime})` ===
									slotData.SlotName &&
								isWithinCurrentSemester(
									item.startDate,
									item.endDate,
									currentWeek
								)
							) {
								const dayOfWeek = slotTimeTable.timetable.weekDay.toLowerCase();
								slotData[dayOfWeek] = {
									subjectName: item.subject.subjectName,
									roomCode: item.room.roomCode,
								};
							}
						});
					}
				});

				return slotData;
			});
			console.log(formattedData);
			setTimetableData(formattedData);
		} catch (error) {
			console.error("Error fetching timetable data", error);
		}
	};

	const isWithinCurrentSemester = (startDate, endDate, currentWeek) => {
		const [start, end] = currentWeek.split(" To ");
		const [startDay, startMonth] = start.split("/");
		const [endDay, endMonth] = end.split("/");
		var _startDate;
		if (startMonth > endMonth) {
			_startDate = new Date(selectedYear - 1, startMonth - 1, startDay);
		} else {
			_startDate = new Date(selectedYear, startMonth - 1, startDay);
		}
		const _endDate = new Date(selectedYear, endMonth - 1, endDay);

		if (_startDate >= new Date(startDate) && _endDate <= new Date(endDate)) {
			return true;
		} else {
			return false;
		}
	};

	useEffect(() => {
		const weeks = generateWeekList();

		const currentDate = new Date();
		var currentWeek;
		for (let i = 0; i < weeks.length; i++) {
			const [start, end] = weeks[i].split(" To ");
			const [startDay, startMonth] = start.split("/");
			const [endDay, endMonth] = end.split("/");
			var startDate;
			if (weeks[0]) {
				startDate = new Date(selectedYear - 1, startMonth - 1, startDay);
			} else {
				startDate = new Date(selectedYear, startMonth - 1, startDay);
			}
			const endDate = new Date(selectedYear, endMonth - 1, endDay);

			if (currentDate >= startDate && currentDate <= endDate) {
				setSelectedWeek(weeks[i]);
				currentWeek = weeks[i];
				break;
			}
		}

		fetchData(currentWeek);
	}, [selectedYear]);

	const handleYearChange = (value) => {
		setSelectedYear(value);
		setSelectedWeek(generateWeekList()[0]);
	};

	const handleWeekChange = (value) => {
		setSelectedWeek(value);
		fetchData(value);
	};

	const columns = [
		{
			title: "Slot",
			dataIndex: "SlotName",
			key: "SlotName",
			align: "center",
			render: (text) => <div>{text}</div>,
		},
		{
			title: "MON",
			dataIndex: "mon",
			key: "mon",
			align: "center",
			render: (text) => {
				if (text) {
					return (
						<div>
							<a>{text.subjectName}</a>
							<br />
							tại phòng {text.roomCode}
						</div>
					);
				}
				return null;
			},
		},
		{
			title: "TUE",
			dataIndex: "tue",
			key: "tue",
			align: "center",
			render: (text) => {
				if (text) {
					return (
						<div>
							<a>{text.subjectName}</a>
							<br />
							tại phòng {text.roomCode}
						</div>
					);
				}
				return null;
			},
		},
		{
			title: "WED",
			dataIndex: "wed",
			key: "wed",
			align: "center",
			render: (text) => {
				if (text) {
					return (
						<div>
							<a>{text.subjectName}</a>
							<br />
							tại phòng {text.roomCode}
						</div>
					);
				}
				return null;
			},
		},
		{
			title: "THU",
			dataIndex: "thu",
			key: "thu",
			align: "center",
			render: (text) => {
				if (text) {
					return (
						<div>
							<a>{text.subjectName}</a>
							<br />
							tại phòng {text.roomCode}
						</div>
					);
				}
				return null;
			},
		},
		{
			title: "FRI",
			dataIndex: "fri",
			key: "fri",
			align: "center",
			render: (text) => {
				if (text) {
					return (
						<div>
							<a>{text.subjectName}</a>
							<br />
							tại phòng {text.roomCode}
						</div>
					);
				}
				return null;
			},
		},
		{
			title: "SAT",
			dataIndex: "sat",
			key: "sat",
			align: "center",
			render: (text) => {
				if (text) {
					return (
						<div>
							<a>{text.subjectName}</a>
							<br />
							tại phòng {text.roomCode}
						</div>
					);
				}
				return null;
			},
		},
		{
			title: "SUN",
			dataIndex: "sun",
			key: "sun",
			align: "center",
			render: (text) => {
				if (text) {
					return (
						<div>
							<a>{text.subjectName}</a>
							<br />
							tại phòng {text.roomCode}
						</div>
					);
				}
				return null;
			},
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
