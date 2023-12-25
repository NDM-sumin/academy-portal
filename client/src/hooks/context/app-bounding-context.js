import { createContext, useContext } from "react";
import { AUTH_ROUTES } from "../../routes/auth.routes";


export const AppContext = createContext({
    loading: false,
    setLoading: (value) => { },
    routes: AUTH_ROUTES,
    setRoutes: (value) => { },
    axios: null
})

export const useAppContext = () => useContext(AppContext);