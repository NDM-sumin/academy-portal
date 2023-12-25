import { MailOutlined, UserOutlined } from "@ant-design/icons";
import { Button, Col, Form, Input, Row, notification } from "antd";
import { useNavigate } from "react-router-dom";
import './auth-style.css'
import { useAppContext } from "../../hooks/context/app-bounding-context";
import useAuthApi from "../../apis/auth.api";

const ForgotPassword = () => {
    const navigate = useNavigate();
    const appContext = useAppContext();
    const authApi = useAuthApi();
    const backToLogin = () => {
        navigate('/auth/login');
    }

    const actionButtons = (<Row>
        <Col span={12} >
            <Button loading={appContext.loading} htmlType="submit" type="primary" style={{ width: '100%' }}>
                Quên mật khẩu
            </Button>
        </Col>
        <Col span={12}>
            <Button type="link" style={{ width: '100%' }} onClick={backToLogin}>
                Quay lại đăng nhập
            </Button>
        </Col>
    </Row>)
    const emailRules = [
        {
            required: true,
            type: "email",
            message: 'Email không hợp lệ'
        }
    ]

    const onFinished = (value) => {
        authApi
            .logout()
            .then(() => {
                return authApi.forgotPassword(value);
            })
            .then(response => {
                notification.success({
                    message: "Khôi phục mật khẩu thành công",
                    description: 'Vui lòng kiểm tra mail để lấy mật khẩu mới'
                })
                navigate('/auth/login')
            })
    }

    return (<Form layout="vertical" onFinish={onFinished} className="login-page-form">

        <Form.Item
            hasFeedback
            label='Tên người dùng'
            name="username"
            rules={[{ required: true, message: 'Vui lòng nhập tên người dùng' }]}
        >
            <Input
                prefix={<UserOutlined />}
                placeholder="Nhập tên người dùng"
            />
        </Form.Item>
        <Form.Item
            hasFeedback
            label='Email'
            name="email"
            rules={emailRules}
        >
            <Input
                prefix={<MailOutlined />}
                placeholder="Nhập email"

            />
        </Form.Item>
        <Form.Item>
            {actionButtons}
        </Form.Item>
    </Form>)
}
export default ForgotPassword;