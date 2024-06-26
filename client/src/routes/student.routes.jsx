import RegisterSubject from "../pages/student/RegisterSubject/index";
import StudentTimeTable from "../pages/student/StudentTimetable";
import Attendance from "../pages/student/AttendanceHistory";
import ScoreHistory from "../pages/student/ScoreHistory";
import FeeHistory from "../pages/student/FeeHistory";
import ClassDetail from "../pages/student/ClassDetail";
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
				path: "studentTimetable",
				title: "Lịch học",
				element: <StudentTimeTable />,
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
			{
				inMenu: true,
				path: "feeHistory",
				title: "Lịch sử học phí",
				element: <FeeHistory />,
			},
			{
				inMenu: false,
				path: "ClassDetail",
				title: "Chi tiết lớp",
				element: <ClassDetail />,
			},
		],
	},
];
