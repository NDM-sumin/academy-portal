import Major from "../pages/admin/Major";
import Room from "../pages/admin/Room";
import Subject from "../pages/admin/Subject";
import Teacher from "../pages/admin/Teacher";
import Student from "../pages/admin/Student";
import LayoutPage from "../pages/index";
import Semester from "../pages/admin/Semester";
import Class from "../pages/admin/Class";

export const ADMIN_ROUTES = [
	{
		path: "/",
		element: <LayoutPage />,
		rootMenu: true,
		children: [
			{
				inMenu: true,
				path: "major",
				title: "Quản lý chuyên ngành",
				element: <Major />,
			},
			{
				inMenu: true,
				path: "semester",
				title: "Quản lý học kì",
				element: <Semester />,
			},
			{
				inMenu: true,
				path: "room",
				title: "Quản lý phòng",
				element: <Room />
			},
			{
				inMenu: true,
				path: "subject",
				title: "Quản lý môn học",
				element: <Subject />,
			},
			{
				inMenu: true,
				path: "students",
				title: "Quản lý sinh viên",
				element: <Student />,
			},
			{
				inMenu: true,
				path: "teachers",
				title: "Quản lý giảng viên",
				element: <Teacher />,
				// children: [
				// 	{
				// 		inMenu: true,
				// 		path: "add",
				// 		title: "Thêm giảng viên",
				// 	},
				// ],
			},
			{
				inMenu: true,
				path: "classes",
				title: "Quản lý lớp học",
				element: <Class />,
				// children: [
				// 	{
				// 		inMenu: true,
				// 		path: "add",
				// 		title: "Thêm giảng viên",
				// 	},
				// ],
			},
		],
	},
];
