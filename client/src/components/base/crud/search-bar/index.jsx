import { ReloadOutlined } from "@ant-design/icons";
import { Button, Divider, Space } from "antd";
import ReloadButton from "./ReloadButton";
import CreateButton from "./CreateButton";


const CRUDSearchBar = () => {


    return <Space>
        <ReloadButton />
        <CreateButton />
    </Space>
}
export default CRUDSearchBar;