import { useState } from "react";
import { useForm } from "antd/es/form/Form";
import { Form, Input, message, Button, Select } from "antd";
import useRoomApi from "../../apis/room.api";

const RegisterSubject = () => {
	const [form] = useForm();
	const [loading, setLoading] = useState(false);
	const roomApi = useRoomApi(); // Giả sử bạn có một API hook để gọi các API liên quan đến phòng học

	const handleSubmit = async (values) => {
		try {
			setLoading(true);
			// Gọi API đăng kí học phần ở đây
			await roomApi.registerSubject(values);
			message.success("Đăng kí học phần thành công");
			form.resetFields(); // Reset form sau khi đăng kí thành công
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
							{subject.name}
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
