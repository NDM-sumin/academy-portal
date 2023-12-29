import { DeleteOutlined } from "@ant-design/icons";
import { Button, Popconfirm, Popover, notification } from "antd";
import { useAppContext } from "../../../../../hooks/context/app-bounding-context";
import { useCRUDContext } from "../../../../../hooks/context/crud-context";



const DeleteButton = ({ record }) => {
    const context = useCRUDContext();
    const appContext = useAppContext();
    const onConfirm = () => {
        context.crudApi.delete(record.id).then(response => {
            notification.success({ message: 'Xóa thành công' })
            context.reloadState[1](true);
        })
    }
    return <Popconfirm
        title="Xóa"
        description="Bạn có chắc chắn muốn xóa"
        onConfirm={onConfirm}
    >
        <Button danger icon={<DeleteOutlined />} loading={appContext.loading}></Button>
    </Popconfirm>
}
export default DeleteButton;