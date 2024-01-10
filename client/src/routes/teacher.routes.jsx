import TimeTable from "../pages/teacher/Timetable";
import ScoreManagement from "../pages/teacher/ScoreManagement";

import LayoutPage from "../pages/index";

export const TEACHER_ROUTES = [
	{
		path: "/",
		element: <LayoutPage />,
		rootMenu: true,
		children: [
			{
				inMenu: true,
				path: "timetable",
				title: "Lịch dạy",
				element: <TimeTable />,
			},
			{
				inMenu: true,
				path: "scoreManagement",
				title: "Quản lí điểm",
				element: <ScoreManagement />,
			},
		],
	},
];
