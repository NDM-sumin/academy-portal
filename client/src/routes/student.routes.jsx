import RegisterSubject from "../pages/student/registerSubject";
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
		],
	},
];
