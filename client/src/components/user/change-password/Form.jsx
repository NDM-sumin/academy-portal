import { Form, Input } from "antd"


const ChangePasswordForm = ({ form }) => {


    const requiredRule = {
        required: true,
        message: 'Vui lòng nhập đầy đủ'
    }


    return <Form layout="vertical" form={form} >
        <Form.Item
            label='Mật khẩu hiện tại'
            name='oldPassword'
            rules={[requiredRule]}
        >
            <Input.Password placeholder="Mật khẩu hiện tại" />
        </Form.Item>
        <Form.Item
            name='password'
            label='Mật khẩu mới'
            rules={[requiredRule]}
        >
            <Input.Password placeholder="Mật khẩu mới" />
        </Form.Item>
        <Form.Item
            name='new-password'
            label='Xác nhận mật khẩu mới'
            rules={[
                requiredRule,
                {
                    validator: (rule, value) => {
                        return value === form.getFieldValue('password')
                            ? Promise.resolve()
                            : Promise.reject('Mật khẩu xác nhận không khớp với mật khẩu mới.');
                    }
                }
            ]}

        >
            <Input.Password placeholder="Xác nhận mật khẩu mới" />
        </Form.Item>
    </Form>
}
export default ChangePasswordForm