import { theme } from "antd";
import { Footer } from "antd/es/layout/layout";


const AppFooter = () => {

    const {
        token: { colorBgContainer },
    } = theme.useToken();

    return <Footer
        style={{ textAlign: 'center', backgroundColor: colorBgContainer }}
    >
        <span>EPU Academy Portal ©2023</span>
    </Footer>
}
export default AppFooter;