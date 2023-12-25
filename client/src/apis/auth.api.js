import { useAppContext } from "../hooks/context/app-bounding-context"
import { USER_TOKEN_KEY } from "../utils/constants";


const useAuthApi = () => {
    const globalContext = useAppContext();
    const axios = globalContext.axios;
    const login = ({ username, password }) => {
        return axios.post('api/Account/Login', { username: username, password: password }).then(response => {
            localStorage.setItem(USER_TOKEN_KEY, JSON.stringify(response));
            return Promise.resolve(response);
        })
    }
    const logout = () => {
        localStorage.removeItem(USER_TOKEN_KEY);
        return Promise.resolve();
    }
    const forgotPassword = ({ username, email }) => {
        return axios
            .put('api/Account/ForgotPassword', { username: username, email: email })
    }
    const changePassword = ({ oldPassword, password }) => {
        return axios.put('api/Account/ChangePassword', { password: password, oldPassword: oldPassword })
    }
    const getCurrentUser = (config) => {
        return axios.get('api/Account/CurrentUser', { isShowError: config?.isShowError });
    }
    return {
        login,
        logout,
        forgotPassword,
        changePassword,
        getCurrentUser
    }


}
export default useAuthApi