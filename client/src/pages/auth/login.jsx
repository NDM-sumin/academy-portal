import { LockOutlined, UserOutlined } from "@ant-design/icons";
import { Button, Checkbox, Col, Form, Input, Row } from "antd";
import { useNavigate } from "react-router-dom";
import './auth-style.css'


const Login = () => {
    const navigate = useNavigate();
    const onFinished = (values) => {

    }
    const forgotPassword = () => {
        navigate('/auth/forgot-password')
    }
    const formToolBar = (<Row>
        <Col span={12} style={{ textAlign: 'start' }}>
            <Form.Item name="remember" valuePropName="checked">
                <Checkbox>
                    Remember me
                </Checkbox>
            </Form.Item>

        </Col>
        <Col span={12} style={{ textAlign: 'end' }}>
            <Button type='link' onClick={forgotPassword}>
                Forgot password
            </Button>
        </Col>
    </Row>)
    return (
        <Form layout="vertical" onFinish={onFinished} className="login-page-form">

            <Form.Item hasFeedback label='Username' name="username" rules={[{ required: true, message: 'Please enter username' },]}>
                <Input prefix={<UserOutlined />} placeholder='Enter your username' />
            </Form.Item>
            <Form.Item hasFeedback label='Password' name="password" rules={[{ required: true, message: 'Please enter password' }]}>
                <Input.Password prefix={<LockOutlined />} type="password" placeholder='Enter your password' />
            </Form.Item>
            {formToolBar}
            <Form.Item style={{textAlign:"center"}}>
                <Button htmlType="submit" type="primary" >
                    Login
                </Button>
            </Form.Item>
        </Form >
    );
}
export default Login