import { useState } from "react";
import CRUDPage from "../../components/base/crud";
import { useForm } from "antd/es/form/Form";
import { Form, Input, message } from "antd";
import useSubjectApi from "../../apis/subject.api";

const Subject = () => {
	const [data, setData] = useState({ totalItems: 0, items: [] });
	const [query, setQuery] = useState({
		$skip: 0,
		$top: 50,
	});
	const [modalProps, setModalProps] = useState({
		open: false,
	});
	const [reload, setReload] = useState(true);
	const columns = [
		{
			title: "Mã môn",
			dataIndex: "subjectCode",
		},
		{
			title: "Tên môn",
			dataIndex: "subjectName",
		},
	];
	const subjectApi = useSubjectApi();
	const crudApi = {
		create: subjectApi.create,
		update: subjectApi.update,
		search: subjectApi.get,
		delete: subjectApi.del,
	};
	const searchBarItems = [];
	const formItems = [
		<Form.Item
			key={1}
			label="Mã môn"
			name="subjectCode"
			rules={[{ required: true, message: "Vui lòng nhập mã môn" }]}
		>
			<Input />
		</Form.Item>,
		<Form.Item
			key={2}
			label="Tên môn"
			name="subjectName"
			rules={[{ required: true, message: "Vui lòng nhập tên môn" }]}
		>
			<Input />
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

export default Subject;
