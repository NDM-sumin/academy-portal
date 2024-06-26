import ForgotPassword from "../pages/auth/forgot-password";
import Login from "../pages/auth/login";
import AuthLayout from "../pages/auth/index";

export const AUTH_ROUTES = [
    {
        path: '/auth',
        element: <AuthLayout />,
        children: [
            {
                path: 'login',
                element: <Login />
            },
            {
                path: 'forgot-password',
                element: <ForgotPassword />
            }
        ]
    }
]