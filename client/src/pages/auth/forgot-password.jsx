import { MailOutlined, UserOutlined } from "@ant-design/icons";
import { Button, Col, Form, Input, Row } from "antd";
import { useNavigate } from "react-router-dom";
import './auth-style.css'

const ForgotPassword = () => {
    const navigate = useNavigate();
    const backToLogin = () => {
        navigate('/auth/login');
    }

    const actionButtons = (<Row>
        <Col span={12} >
            <Button htmlType="submit" type="primary" style={{ width: '100%' }}>
                Forgot Password
            </Button>
        </Col>
        <Col span={12}>
            <Button type="link" style={{ width: '100%' }} onClick={backToLogin}>
                Back to login
            </Button>
        </Col>
    </Row>)
    const emailRules = [
        {
            required: true,
            type: "email",
            message: 'Email is not valid'
        }
    ]

    const onFinished = (value) => {

    }

    return (<Form layout="vertical" onFinish={onFinished} className="login-page-form">

        <Form.Item
            hasFeedback
            label='Username'
            name="username"
            rules={[{ required: true, message: 'Please enter username' }]}
        >
            <Input
                prefix={<UserOutlined />}
                placeholder="Enter your username"
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
                placeholder="Enter your email"

            />
        </Form.Item>
        <Form.Item>
            {actionButtons}
        </Form.Item>
    </Form>)
}
export default ForgotPassword;