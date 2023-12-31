import { createContext, useContext } from "react";


export const UserContext = createContext({
    user: null,
    setUser: (value) => { },
    changePassModalState: {

    },
    

})

export const useUserContext = () => useContext(UserContext);