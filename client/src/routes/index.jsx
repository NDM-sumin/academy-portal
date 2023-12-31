import { useNavigate, useRoutes } from "react-router-dom"
import { useAppContext } from "../hooks/context/app-bounding-context"
import useAuthApi from "../apis/auth.api";
import { ROLE } from "../utils/constants";
import { ADMIN_ROUTES } from "./admin.routes";
import { TEACHER_ROUTES } from "./teacher.routes";
import { STUDENT_ROLES } from "./student.roles";
import { memo, useEffect } from "react";
import { AUTH_ROUTES } from "./auth.routes";
const AppRoutes = () => {

    const authApi = useAuthApi();
    const navigate = useNavigate();
    const appContext = useAppContext();
    useEffect(() => {
        authApi.getCurrentUser({ isShowError: false }).then(response => {
            let userRoutes = [];
            switch (response.role) {
                case (ROLE.ADMIN): {
                    userRoutes = ADMIN_ROUTES;
                    break;
                }
                case (ROLE.TEACHER): {
                    userRoutes = TEACHER_ROUTES;
                    break;
                }
                case (ROLE.STUDENT): {
                    userRoutes = STUDENT_ROLES;
                    break;
                }
            }
            appContext.setRoutes([...AUTH_ROUTES, ...userRoutes])
        }).catch((error) => {
            appContext.setRoutes(AUTH_ROUTES);
            navigate('/auth/login');
        })
    }, [JSON.stringify(appContext.routes)])
    return useRoutes(appContext.routes);

}
export default memo(AppRoutes)