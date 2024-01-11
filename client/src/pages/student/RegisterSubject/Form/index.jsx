import { Button, Form, notification } from "antd"
import useStudentApi from "../../../../apis/student.api";
import { useAppContext } from "../../../../hooks/context/app-bounding-context";
import RegisterSubjectFormSelect from "./Select";


const RegisterSubjectForm = ({form}) => {
    const handleSubmit = async (values) => {
		try {
			await studentApi.registerSubject(values);
			notification.success({message:"Đăng kí học phần thành công"});
			form.resetFields();
		} catch (error) {
			console.error("Đăng kí học phần thất bại", error);
			notification.error({message: "Đăng kí học phần thất bại"});
        }
	};
    const studentApi = useStudentApi();

	
    return <Form
    form={form}
    layout="vertical"
    onFinish={handleSubmit}
    style={{width:'100%'}}
>
    <Form.Item
    style={{width:'100%'}}
        label="Chọn môn học"
        name="subjectId"
        rules={[{ required: true, message: "Vui lòng chọn môn học" }]}
    >
       <RegisterSubjectFormSelect />
    </Form.Item>

    {/* <Form.Item>
        <Button type="primary" htmlType="submit" loading={globalContext.loading}>
            Đăng ký
        </Button>
    </Form.Item> */}
</Form>
}
export default RegisterSubjectForm