import { useState, useEffect } from "react";
import CRUDPage from "../../components/base/crud";
import { useForm } from "antd/es/form/Form";
import { Form, Input, Radio, Select, message, DatePicker } from "antd";
import useMajorApi from "../../apis/major.api";
import useStudentApi from "../../apis/student.api";
import dayjs from "dayjs";
import ImportButton from "../../components/base/crud/search-bar/ImportButton";

const Student = () => {
	const [data, setData] = useState({ totalItems: 0, items: [] });
	const [studentData, setStudentData] = useState({ totalItems: 0, items: [] });

	const [query, setQuery] = useState({
		skip: 0,
		top: 10,
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
		{
			title: "chuyên ngành",
			dataIndex: ["major", "majorName"],
		},
	];
	const studentApi = useStudentApi();
	const majorApi = useMajorApi();
	const get = (query) => {
		return studentApi.get(query).then((response) => {
			return Promise.resolve({
				totalItems: response.totalItems,
				items: response.items.map((item) => ({
					...item,
					dob: dayjs(item.dob),
				})),
			});
		});
	};

	const crudApi = {
		create: studentApi.create,
		update: studentApi.update,
		search: get,
		delete: studentApi.del,
		importData: studentApi.importData,
	};

	useEffect(() => {
		majorApi.get().then((result) => {
			setStudentData(result);
		});
	}, []);
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
			name="username"
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
			label="Ngày sinh"
			name="dob"
			rules={[{ required: true, message: "Vui lòng nhập ngày sinh" }]}
		>
			<DatePicker format="DD/MM/YYYY" />
		</Form.Item>,

		<Form.Item
			key={5}
			label="Số điện thoại"
			name="phone"
			rules={[{ required: true, message: "Vui lòng nhập số điện thoại" }]}
		>
			<Input />
		</Form.Item>,
		<Form.Item
			key={6}
			label="Giới tính"
			name="gender"
			rules={[{ required: true, message: "Vui lòng chọn giới tính" }]}
		>
			<Radio.Group>
				<Radio value={true}>Nam</Radio>
				<Radio value={false}>Nữ</Radio>
			</Radio.Group>
		</Form.Item>,
		<Form.Item
			key={7}
			label="Chuyên ngành"
			name="majorId"
			rules={[{ required: true, message: "Vui lòng chọn chuyên ngành" }]}
		>
			<Select>
				{studentData.items.map((item) => (
					<Select.Option key={item.id} value={item.id}>
						{item.majorName}
					</Select.Option>
				))}
			</Select>
		</Form.Item>,
	];
	const additionButtons = [<ImportButton />];
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

	return (
		<CRUDPage contextValue={contextValue} additionButtons={additionButtons} />
	);
};

export default Student;
