import { createContext, useContext } from "react";


export const AppContext = createContext({
    loading: false,
    setLoading: (value) => { },
    user: {},
    setUser: (user) => { },
    axios: null
})

export const useAppContext = () => useContext(AppContext);