import { Menu } from "antd"
import { useEffect, useState } from "react"
import { useAppContext } from "../hooks/context/app-bounding-context";
import { useLocation, useNavigate, useNavigation } from "react-router-dom";

const getMenuTree = (routesTree, parentPath) => {
    return routesTree?.filter(route => route.inMenu === true).map(route => {
        return {
            key: route.path,
            label: route.title,
            icon: route.icon,
            children: getMenuTree(route.children, route.path)
        }
    })

}
const AppMenu = () => {
    const appContext = useAppContext();
    const [menuItems, setMenuItems] = useState([]);
    const navigate = useNavigate();
    const location = useLocation();


    useEffect(() => {
        const menuItem = getMenuTree(appContext?.routes?.find(route => route.rootMenu === true)?.children)
        setMenuItems(menuItem)
    }, [])

    return <Menu mode="inline"
        theme="light"
        items={menuItems}
        selectedKeys={location.pathname.split('/').reverse()}
        onSelect={({ it, key, keyPath, selectedKey, de }) => {
            navigate(keyPath.reverse().join('/'))
        }}
    >

    </Menu>


}
export default AppMenu