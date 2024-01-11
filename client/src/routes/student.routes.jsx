import RegisterSubject from "../pages/student/RegisterSubject";
import TimeTable from "../pages/student/Timetable";
import Attendance from "../pages/student/AttendanceHistory";
import ScoreHistory from "../pages/student/ScoreHistory";

import LayoutPage from "../pages/index";

export const STUDENT_ROUTES = [
	{
		path: "/",
		element: <LayoutPage />,
		rootMenu: true,
		children: [
			{
				inMenu: true,
				path: "register-subject",
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
			{
				inMenu: true,
				path: "scoreHistory",
				title: "Lịch sử điểm",
				element: <ScoreHistory />,
			},
		],
	},
];
