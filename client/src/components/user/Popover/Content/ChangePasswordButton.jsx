import { KeyOutlined } from "@ant-design/icons"
import { Button } from "antd"
import { useUserContext } from "../../../../hooks/context/user-context"


const ChangePasswordButton = () => {
    const userContext = useUserContext();

    const onClick = () => {
        userContext.changePassModalState.setOpen(true);
    }

    return <Button onClick={onClick} icon={<KeyOutlined />}>Đổi mật khẩu</Button>
}
export default ChangePasswordButton