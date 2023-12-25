import { Header } from "antd/es/layout/layout"
import AppLogo from "./Logo"
import { theme } from "antd";
import UserPopover from "./user/Popover";



const AppHeader = () => {
    const {
        token: { colorBgContainer },
    } = theme.useToken();


    return <Header style={{ background: colorBgContainer, position:'relative' }}>
        <AppLogo />
        <UserPopover />
    </Header>
}
export default AppHeader