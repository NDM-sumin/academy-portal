import React, { useState, useEffect } from "react";
import { Table, Card } from "antd";
import useClassApi from "../../apis/class.api";
import dayjs from "dayjs";

import { useLocation } from "react-router-dom";

const ClassDetail = () => {
	const classApi = useClassApi();
	const { search } = useLocation();
	const params = new URLSearchParams(search);
	const classId = params.get("classId");
	const [studentData, setStudentData] = useState([]);
	const [classData, setClassData] = useState([]);

	const fetchData = async () => {
		try {
			const response = await classApi.GetClassInformation(classId);
			setClassData(response);
			console.log(response);
			setStudentData(response.students);
		} catch (error) {
			console.error("Error fetching score data", error);
		}
	};

	useEffect(() => {
		fetchData();
	}, []);

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
			dataIndex: "major",
			render: (text) => text.majorName,
		},
	];

	return (
		<div>
			<Card title={classData.classCode}>
				<p>Tên môn: {classData.subjectName}</p>
				<p>Tên giáo viên: {classData.teacherName}</p>
			</Card>
			<Table
				style={{ marginTop: "20px" }}
				dataSource={studentData}
				columns={columns}
			/>
		</div>
	);
};

export default ClassDetail;
