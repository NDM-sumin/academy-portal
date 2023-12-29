import { ReloadOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { useAppContext } from "../../../../hooks/context/app-bounding-context";
import { useCRUDContext } from "../../../../hooks/context/crud-context";



const ReloadButton = () => {
    const appContext = useAppContext();
    const context = useCRUDContext();

    return <Button
        icon={<ReloadOutlined />}
        loading={appContext.loading}
        onClick={() => {
            context.reloadState[1](true);
        }}
    >
        Tải lại
    </Button>
}
export default ReloadButton;