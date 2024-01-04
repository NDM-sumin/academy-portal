import RegisterSubject from "../pages/student/registerSubject";
import TimeTable from "../pages/student/Timetable";
import Attendance from "../pages/student/AttendanceHistory";
import LayoutPage from "../pages/index";

export const STUDENT_ROUTES = [
	{
		path: "/",
		element: <LayoutPage />,
		rootMenu: true,
		children: [
			{
				inMenu: true,
				path: "registerSubject",
				title: "Đăng kí học phần",
				element: <RegisterSubject />,
			},
			{
				inMenu: true,
				path: "timetable",
				title: "Lịch học",
				element: <TimeTable />,
			},
			{
				inMenu: true,
				path: "attendanceHistory",
				title: "Lịch sử điểm danh",
				element: <Attendance />,
			},
		],
	},
];
