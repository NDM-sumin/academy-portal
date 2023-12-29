import { Modal, notification } from "antd"
import { useCRUDContext } from "../../../../hooks/context/crud-context"
import CRUDForm from "./form";
import { useAppContext } from "../../../../hooks/context/app-bounding-context";


const CRUDModal = () => {

    const context = useCRUDContext();
    const appContext = useAppContext();
    const onOk = () => {
        context.form.instance.validateFields().then(formValues => {
            context.modalState[0].onOk(formValues).then(response => {
                notification.success({ message: 'Lưu thành công' });
                context.reloadState[1](true);
                context.modalState[1]({ ...context.modalState[0], open: false })
            })

        })


    }
    return <Modal
        {...context.modalState[0]}
        cancelText="Thoát"
        okText="Lưu"
        okButtonProps={{ loading: appContext.loading }}
        onOk={onOk}
        onCancel={() => {
            context.modalState[1]({ ...context.modalState[0], open: false })
        }}
        destroyOnClose={true}
    >
        <CRUDForm />
    </Modal>
}
export default CRUDModal