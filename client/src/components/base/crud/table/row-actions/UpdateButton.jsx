import { EditOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { useCRUDContext } from "../../../../../hooks/context/crud-context";
import { useAppContext } from "../../../../../hooks/context/app-bounding-context";



const UpdateButton = ({ record }) => {
    const context = useCRUDContext();
    const onUpdateSubmit = (formValues) => {
        return context.crudApi.update({ ...record, ...formValues })

    }
    const appContext = useAppContext();
    return <Button
        icon={<EditOutlined />}
        loading={appContext.loading}
        onClick={() => {

            context.modalState[1]({ ...context.modalState[0], open: true, onOk: onUpdateSubmit })
            context.form.instance.setFieldsValue(record)
        }}
    >

    </Button>
}
export default UpdateButton;