import { Route, Routes, useRoutes } from "react-router-dom"
import { useAppContext } from "../hooks/context/app-bounding-context"
import { AUTH_ROUTES } from "./auth.routes";

const getRouteComponent = (parentRoutes, parentPath) => {
    return parentRoutes.map((parentRoute, index) => {
        const path = `${parentPath}${parentRoute.path}`
        return <Route
            path={path}
            Component={parentRoute.element}
            key={index}
        >
            {
                parentRoute.children ? getRouteComponent(parentRoute.children, parentRoute.path) : <></>
            }
        </Route >
        
    })
}

const AppRoutes = () => {

    const appContext = useAppContext();
    const user = appContext.user;
    return useRoutes(AUTH_ROUTES);

}
export default AppRoutes