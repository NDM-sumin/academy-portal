/* eslint-disable no-unused-vars */
import axios from 'axios';
import { notification } from 'antd';
import { useNavigate } from 'react-router-dom';
import { AUTH_SCHEME, USER_TOKEN_KEY } from '../utils/constants';

const useAxios = (setLoading) => {
    const navigate = useNavigate();
    const errorHandler = (error) => {
        if (!error) return;
        //Xử lý khi token hết hạn -> logout

        //Xử lý khi response trả về là arraybuffer
        let description = error?.response?.data?.message
        if (error.request?.responseType === 'arraybuffer') {
            description = JSON.parse(new TextDecoder().decode(error?.response?.data));
        }
        notification.error({
            message: 'Có lỗi xảy ra',
            description: description,
            placement: 'topRight',
        });
        if (error.request?.status === 401) {
            localStorage.removeItem(USER_TOKEN_KEY);
            navigate('/auth/login');
            return;
        }
    };
    const _axios = axios.create({
        baseURL: import.meta.env.VITE_API_URL,
        xsrfHeaderName: 'RequestVerificationToken',
        withCredentials: true,
    });
    _axios.interceptors.request.use((config) => {
        console.log(config);
        const token = JSON.parse(localStorage.getItem(USER_TOKEN_KEY) ?? JSON.stringify({}))?.token;
        config.headers.Authorization = `${AUTH_SCHEME} ${token}`;
        if (!config.headers[`Content-Type`])
            config.headers['Content-Type'] = 'application/json'
        setLoading(true);
        return config;
    });
    _axios.interceptors.response.use(
        (response) => {
            setLoading(false);
            return Promise.resolve(response.data);
        },
        (error) => {

            setLoading(false);
            if ((error?.config?.isShowError ?? true) === true)
                errorHandler(error);
            return Promise.reject(error);
        },
    );
    return _axios;
};

export default useAxios;
