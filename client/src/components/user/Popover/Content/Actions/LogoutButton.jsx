import { Button } from "antd";
import useAuthApi from "../../../../../apis/auth.api";
import { useNavigate } from "react-router-dom";
import { LogoutOutlined } from "@ant-design/icons";

const LogoutButton = () => {
    const authApi = useAuthApi();
    const navigate = useNavigate();
    const onClick = () => {
        authApi.logout().then(res => {
            navigate('/auth/login');
        })
    }

    return <Button onClick={onClick} danger icon={<LogoutOutlined />}>Đăng xuất</Button>
}
export default LogoutButton;