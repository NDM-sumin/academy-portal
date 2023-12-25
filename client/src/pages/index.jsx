import { Layout, theme } from "antd";
import { Content } from "antd/es/layout/layout";
import { Outlet } from "react-router-dom";
import AppHeader from "../components/Header";
import Sider from "antd/es/layout/Sider";
import AppMenu from "../components/Menu";
import AppFooter from "../components/Footer";
import { useState } from "react";


const LayoutPage = () => {
    const {
        token: { colorBgContainer },
    } = theme.useToken();

    const [collapsed, setCollapsed] = useState(false);
    return <Layout>
        <AppHeader />
        <Layout style={{ paddingTop: '10px' }}>
            <Sider theme="light" collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
                <AppMenu />
            </Sider>
            <Layout style={{ margin: '0 10px' }}>
                <Content style={{ backgroundColor: colorBgContainer, marginBottom: '10px' }}>
                    <Outlet></Outlet>

                </Content>
                <AppFooter />
            </Layout>


        </Layout>

    </Layout>
}
export default LayoutPage;