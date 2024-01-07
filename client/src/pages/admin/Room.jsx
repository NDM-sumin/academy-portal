import { useState } from "react";
import CRUDPage from "../../components/base/crud";
import { useForm } from "antd/es/form/Form";
import { Form, Input, message } from "antd";
import useRoomApi from "../../apis/room.api";

const Room = () => {
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
			title: "Mã phòng",
			dataIndex: "roomCode",
		},
		{
			title: "Số lượng người khả thi",
			dataIndex: "capacity",
		},
	];
	const roomApi = useRoomApi();
	const crudApi = {
		create: roomApi.create,
		update: roomApi.update,
		search: roomApi.get,
		delete: roomApi.del,
	};
	const searchBarItems = [];
	const formItems = [
		<Form.Item
			key={1}
			label="Mã phòng"
			name="roomCode"
			rules={[{ required: true, message: "Vui lòng nhập mã phòng" }]}
		>
			<Input />
		</Form.Item>,
		<Form.Item
			key={2}
			label="Số lượng người khả thi"
			name="capacity"
			rules={[{ required: true, message: "Vui lòng nhập số lượng" }]}
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
export default Room;
