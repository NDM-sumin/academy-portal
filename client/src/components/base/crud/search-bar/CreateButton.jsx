import { FileAddOutlined } from "@ant-design/icons"
import { Button } from "antd"
import { useCRUDContext } from "../../../../hooks/context/crud-context"
import { useAppContext } from "../../../../hooks/context/app-bounding-context";



const CreateButton = () => {
    const context = useCRUDContext();
    const appContext = useAppContext();
    const onClick = () => {
        context.modalState[1]({ ...context.modalState[0], open: true, onOk: context.crudApi.create })
        context.form.instance.resetFields();
    }
    return <Button
        icon={<FileAddOutlined />}
        onClick={onClick}
        loading={appContext.loading}
    >
        Thêm mới
    </Button>

}
export default CreateButton