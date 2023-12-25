import LayoutPage from "../pages/index";


export const ADMIN_ROUTES = [
    {
        path: '/',
        element: <LayoutPage />,
        rootMenu: true,
        children: [
            {
                inMenu: true,
                path: 'major',
                title: "Quản lý chuyên ngành"
            },
            {
                inMenu: true,
                path: 'semester',
                title: "Quản lý học kì"
            },
            {
                inMenu: true,
                path: 'subject',
                title: "Quản lý môn học"
            },
            {
                inMenu: true,
                path: 'students',
                title: 'Quản lý sinh viên'
            },
            {
                inMenu: true,
                path: 'teachers',
                title: "Quản lý giảng viên",
                children: [
                    {
                        inMenu: true,
                        path: 'add',
                        title: "Thêm giảng viên",
                    }
                ]
            }
        ]
    }
]