import { useState } from "react";
import CRUDPage from "../../components/base/crud";
import { useForm } from "antd/es/form/Form";
import { Form, Input, Radio, message, DatePicker } from "antd";
import useTeacherApi from "../../apis/teacher.api";
import dayjs from "dayjs";

const Teacher = () => {
	const [data, setData] = useState({ totalItems: 0, items: [] });
	const [query, setQuery] = useState({
		skip: 0,
		top: 50,
	});
	const [modalProps, setModalProps] = useState({
		open: false,
	});
	const [reload, setReload] = useState(true);
	const columns = [
		{
			title: "Tên đầy đủ",
			dataIndex: "fullName",
		},
		{
			title: "Tên tài khoản",
			dataIndex: "username",
		},
		{
			title: "Email",
			dataIndex: "email",
		},
		{
			title: "ngày sinh",
			dataIndex: "dob",
			render: (dob, _, __) => dayjs(dob).format("DD/MM/YYYY"),
		},
		{
			title: "Số điện thoại",
			dataIndex: "phone",
		},
		{
			title: "Giới tính",
			dataIndex: "gender",
			render: (gender) => (gender ? "Nam" : "Nữ"),
		},
	];
	const get = (query) => {
		return teacherApi.get(query).then((response) => {
			return Promise.resolve({
				totalItems: response.totalItems,
				items: response.items.map((item) => ({
					...item,
					dob: dayjs(item.dob),
				})),
			});
		});
	};
	const teacherApi = useTeacherApi();
	const crudApi = {
		create: teacherApi.create,
		update: teacherApi.update,
		search: get,
		delete: teacherApi.del,
	};
	const searchBarItems = [];
	const formItems = [
		<Form.Item
			key={1}
			label="Tên đầy đủ"
			name="fullName"
			rules={[{ required: true, message: "Vui lòng nhập tên đầy đủ" }]}
		>
			<Input />
		</Form.Item>,
		<Form.Item
			key={2}
			label="Tên tài khoản"
			name="userName"
			rules={[{ required: true, message: "Vui lòng nhập tên tài khoản" }]}
		>
			<Input />
		</Form.Item>,
		<Form.Item
			key={3}
			label="Email"
			name="email"
			rules={[{ required: true, message: "Vui lòng nhập email" }]}
		>
			<Input type="email" />
		</Form.Item>,
		<Form.Item
			key={4}
			label="Mật khẩu"
			name="password"
			rules={[{ required: true, message: "Vui lòng nhập mật khẩu" }]}
		>
			<Input.Password />
		</Form.Item>,
		<Form.Item
			key={5}
			label="Ngày sinh"
			name="dob"
			rules={[{ required: true, message: "Vui lòng nhập ngày sinh" }]}
		>
			<DatePicker format="DD/MM/YYYY" />
		</Form.Item>,

		<Form.Item
			key={6}
			label="Số điện thoại"
			name="phone"
			rules={[{ required: true, message: "Vui lòng nhập số điện thoại" }]}
		>
			<Input />
		</Form.Item>,
		<Form.Item
			key={7}
			label="Giới tính"
			name="gender"
			rules={[{ required: true, message: "Vui lòng chọn giới tính" }]}
		>
			<Radio.Group>
				<Radio value={true}>Nam</Radio>
				<Radio value={false}>Nữ</Radio>
			</Radio.Group>
		</Form.Item>,
	];

	const form = {
		instance: useForm()[0],
		items: formItems,
	};

	const contextValue = {
		columns: columns,
		crudApi: crudApi,
		dataState: [data, setData],
		queryState: [query, setQuery],
		searchBarItems: searchBarItems,
		modalState: [modalProps, setModalProps],
		reloadState: [reload, setReload],
		form: form,
	};

	return <CRUDPage contextValue={contextValue} />;
};

export default Teacher;
