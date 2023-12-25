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
                    Nhớ mật khẩu
                </Checkbox>
            </Form.Item>

        </Col>
        <Col span={12} style={{ textAlign: 'end' }}>
            <Button type='link' onClick={forgotPassword}>
                Quên mật khẩu
            </Button>
        </Col>
    </Row>)
    return (
        <Form layout="vertical" onFinish={onFinished} className="login-page-form">

            <Form.Item hasFeedback label='Tên người dùng' name="username" rules={[{ required: true, message: 'Vui lòng nhập tên người dùng' },]}>
                <Input prefix={<UserOutlined />} placeholder='Nhập tên người dùng' />
            </Form.Item>
            <Form.Item hasFeedback label='Mật khẩu' name="password" rules={[{ required: true, message: 'Vui lòng nhập mật khẩu' }]}>
                <Input.Password prefix={<LockOutlined />} type="password" placeholder='Nhập mật khẩu' />
            </Form.Item>
            {formToolBar}
            <Form.Item style={{textAlign:"center"}}>
                <Button htmlType="submit" type="primary" >
                    Đăng nhập
                </Button>
            </Form.Item>
        </Form >
    );
}
export default Login