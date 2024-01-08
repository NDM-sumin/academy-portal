import { useEffect, useState } from "react";
import { useForm } from "antd/es/form/Form";
import { Form, Input, message, Button, Select } from "antd";
import useStudentApi from "../../apis/student.api";
import useSubjectApi from "../../apis/subject.api";

const RegisterSubject = () => {
	const [form] = useForm();

	const subjectApi = useSubjectApi();
	const studentApi = useStudentApi();
	const [loading, setLoading] = useState(false);
	const [subjects, setSubjects] = useState([]);

	useEffect(() => {
		subjectApi.getRegisterableSubjects().then((response) => {
			console.log(response);
			setSubjects(response);
		});
	}, []);
	const handleSubmit = async (values) => {
		try {
			setLoading(true);
			console.log(values);
			await studentApi.registerSubject(values);
			message.success("Đăng kí học phần thành công");
			form.resetFields();
		} catch (error) {
			console.error("Đăng kí học phần thất bại", error);
			message.error("Đăng kí học phần thất bại");
		} finally {
			setLoading(false);
		}
	};

	return (
		<Form
			form={form}
			onFinish={handleSubmit}
			labelCol={{ span: 8 }}
			wrapperCol={{ span: 16 }}
		>
			<Form.Item
				label="Chọn môn học"
				name="subjectId"
				rules={[{ required: true, message: "Vui lòng chọn môn học" }]}
			>
				<Select placeholder="Chọn môn học">
					{subjects.map((subject) => (
						<Option key={subject.id} value={subject.id}>
							{subject.subjectName} ({subject.subjectCode})
						</Option>
					))}
				</Select>
			</Form.Item>

			<Form.Item wrapperCol={{ offset: 8, span: 16 }}>
				<Button type="primary" htmlType="submit" loading={loading}>
					Đăng ký
				</Button>
			</Form.Item>
		</Form>
	);
};
export default RegisterSubject;
