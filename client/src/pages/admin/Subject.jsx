import { useEffect, useState } from "react";
import CRUDPage from "../../components/base/crud";
import { useForm } from "antd/es/form/Form";
import { Form, Input, Select, message } from "antd";
import useSubjectApi from "../../apis/subject.api";
import useMajorApi from "../../apis/major.api";
import useSemesterApi from "../../apis/semester.api";

const Subject = () => {
	const [data, setData] = useState({ totalItems: 0, items: [] });
	const [query, setQuery] = useState({
    skip: 0,
    top: 10,
  });
	const [modalProps, setModalProps] = useState({
		open: false,
	});
	const majorApi = useMajorApi();
	const [majors, setMajors] = useState([])
	const [semesters, setSemesters] = useState([])
	useEffect(() => {
		majorApi.get().then(response => setMajors(response.items))
		semesterApi.get().then(response => setSemesters(response.items))
	}, []);
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
	const semesterApi = useSemesterApi();
	const subjectApi = useSubjectApi();
	const get = (query) => {
		return subjectApi.get(query).then(response => {
			return {
				...response,
				items: response.items.map((item) => ({
					...item,
					majorIds: item.majorSubjects.map((ms) => ms.majorId),
					semesterId: item.majorSubjects[0]?.semesterId
				}))
			}
		})
	}
	const crudApi = {
		create: subjectApi.create,
		update: subjectApi.update,
		search: get,
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
		<Form.Item
			key={3}
			label="Chuyên ngành"
			name="majorIds"
			rules={[{ required: true, message: "Vui lòng chọn các chuyên ngành học môn học này" }]}
		>
			<Select
				options={majors.map((item) => ({ value: item.id, label: item.majorName }))}
				mode='multiple'
			/>
		</Form.Item>,
		<Form.Item
			key={4}
			label="Học kì"
			name="semesterId"
			rules={[{ required: true, message: "Vui lòng chọn học kì của môn học" }]}
		>
			<Select
				options={semesters.map((item) => ({ value: item.id, label: item.semesterName }))}
				
			/>
		</Form.Item>
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
