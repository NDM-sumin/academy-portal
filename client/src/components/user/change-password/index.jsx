import { useForm } from "antd/es/form/Form";
import ChangePasswordForm from "./Form";
import Modal from "antd/es/modal/Modal";
import useAuthApi from "../../../apis/auth.api";
import { useAppContext } from "../../../hooks/context/app-bounding-context";
import { notification } from "antd";

const ChangePasswordModal = ({ openState: [isOpen, setOpen] }) => {
    const [form] = useForm();
    const authApi = useAuthApi();
    const appContext = useAppContext();
    const onOk = () => {
        form
            .validateFields()
            .then(values => {
                return authApi
                    .changePassword(values)
                    .then(res => {
                        notification.success({
                            message: "Thành công",
                            description: "Đổi mật khẩu thành công"
                        });
                        return Promise.resolve(res)
                    })
            })
            .then(res => {
                onCancel();
            })
    }

    const onCancel = () => {
        form.resetFields();
        setOpen();
    }
    return <Modal open={isOpen}
        okText='Đổi mật khẩu'
        cancelText='Thoát'
        onCancel={onCancel}
        onOk={onOk}
        okButtonProps={{
            loading: appContext.loading
        }}
    >
        <ChangePasswordForm form={form} />
    </Modal>

}
export default ChangePasswordModal;