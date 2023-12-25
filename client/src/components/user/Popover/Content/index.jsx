import { Space } from "antd";
import LogoutButton from "./Actions/LogoutButton";
import UpdateInfoButton from "./Actions/UpdateInfoButton";
import ChangePasswordButton from "./ChangePasswordButton";


const UserPopoverContent = ({ user }) => {


    return <Space direction="vertical">
        <UpdateInfoButton />
        <ChangePasswordButton />
        <LogoutButton />
    </Space>
}
export default UserPopoverContent;