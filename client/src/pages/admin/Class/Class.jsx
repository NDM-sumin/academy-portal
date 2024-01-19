import { useState } from "react";
import CRUDPage from "../../../components/base/crud";
import { useForm } from "antd/es/form/Form";
import { Form, Input, message } from "antd";
import useClassApi from "../../../apis/class.api";
import ArrangeClassScheduleButton from "./ArrangeClassScheduleButton";
const Class = () => {
	const [data, setData] = useState({ totalItems: 0, items: [] });
	const [query, setQuery] = useState({
    skip: 0,
    top: 10,
  });
	const [modalProps, setModalProps] = useState({
		open: false,
	});
	const [reload, setReload] = useState(true);
	const additionButtons = [<ArrangeClassScheduleButton key={"dfsdfsdfs"} />];
	const columns = [
		{
			title: "Mã phòng",
			dataIndex: "classCode",
		},
	];
	const classApi = useClassApi();
	const crudApi = {
		create: classApi.create,
		update: classApi.update,
		search: classApi.get,
		delete: classApi.del,
	};
	const searchBarItems = [];
	const formItems = [
		<Form.Item
			key={1}
			label="Mã phòng"
			name="classCode"
			rules={[{ required: true, message: "Vui lòng nhập mã lớp" }]}
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
	return (
		<CRUDPage contextValue={contextValue} additionButtons={additionButtons} />
	);
};
export default Class;
