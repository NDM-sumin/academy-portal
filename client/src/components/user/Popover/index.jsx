import { UserOutlined } from "@ant-design/icons";
import { Avatar, Popover } from "antd";
import useAuthApi from "../../../apis/auth.api";
import { useEffect, useState } from "react";
import './index.css'
import UserPopoverContent from "./Content";
import { UserContext } from "../../../hooks/context/user-context";
import ChangePasswordModal from "../change-password";
const UserPopover = () => {

    const [user, setUser] = useState(null);
    const [changePassModalOpen, setChangePassModalOpen] = useState(false);
    const authApi = useAuthApi();
    useEffect(() => {
        authApi.getCurrentUser().then(setUser);
        return () => {
            setUser(null);
        }
    }, [])

    const contextValue = {
        user: user,
        setUser: setUser,
        changePassModalState: {
            open: changePassModalOpen,
            setOpen: setChangePassModalOpen
        }
    }

    return <UserContext.Provider value={contextValue}>
        <Popover
            title={user?.fullName}
            className="user-popover"
            trigger={'click'}
            content={<UserPopoverContent user={user} />}
        >
            <Avatar shape="square" icon={<UserOutlined />} />
        </Popover>
        <ChangePasswordModal openState={[changePassModalOpen, setChangePassModalOpen]} />
    </UserContext.Provider>
}
export default UserPopover;