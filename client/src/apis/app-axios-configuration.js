/* eslint-disable no-unused-vars */
import axios from 'axios';
import { App } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useAppContext } from '../hooks/context/app-bounding-context';

const useAxios = () => {
    const app = App.useApp();
    const navigate = useNavigate();
    const appBoundingContext = useAppContext();

    const errorHandler = (error) => {
        if (!error) return;
        //Xử lý khi token hết hạn -> logout
        if (error.request?.status === 401) {
            navigate('/login');
            return;
        }
        //Xử lý khi response trả về là arraybuffer
        let description = error?.response?.data?.message
        if (error.request?.responseType === 'arraybuffer') {
            description = JSON.parse(new TextDecoder().decode(error?.response?.data));
        }
        app.notification.error({
            message: 'An error has occured',
            description: description,
            placement: 'topRight',
        });
    };
    const _axios = axios.create({
        baseURL: import.meta.env.VITE_API_GATEWAY,
        xsrfHeaderName: 'RequestVerificationToken',
        withCredentials: true,
    });
    _axios.interceptors.request.use((config) => {
        appBoundingContext.setLoading(true);
        return config;
    });
    _axios.interceptors.response.use(
        (response) => {
            appBoundingContext.setLoading(false);
            return Promise.resolve(response.data);
        },
        (error) => {
            appBoundingContext.setLoading(false);
            errorHandler(error);
            return Promise.reject(error);
        },
    );
    return _axios;
};

export default useAxios;
