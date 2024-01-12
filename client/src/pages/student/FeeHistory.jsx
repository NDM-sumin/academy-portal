import React, { useState, useEffect } from "react";
import { Table, Select } from "antd";
import useStudentApi from "../../apis/student.api";
import useSemesterApi from "../../apis/semester.api";
import useAuthApi from "../../apis/auth.api";
import dayjs from "dayjs";

const FeeHistory = () => {
	const studentApi = useStudentApi();
	const semesterApi = useSemesterApi();
	const authApi = useAuthApi();

	const [selectedSemester, setSelectedSemester] = useState("");
	const [semesterData, setSemesterData] = useState([]);
	const [feeData, setFeeData] = useState([]);
	const [userId, setUserId] = useState(null);

	const getUser = async () => {
		try {
			const user = await authApi.getCurrentUser();
			setUserId(user.id);
			return user.id;
		} catch (error) {
			console.error("Error getting user", error);
			return null;
		}
	};

	const generateSemesterList = async () => {
		try {
			const userId = await getUser();
			const semesters = await studentApi.getSemesters(userId);
			setSelectedSemester(semesters.current.id);

			return {
				semesters: semesters.semesters,
				currentSemester: semesters.current.id,
			};
		} catch (error) {
			console.error("Error fetching semesters", error);
			return [];
		}
	};

	const fetchData = async (currentSemester) => {
		try {
			const userId = await getUser();
			const studentFee = await studentApi.GetFeeHistory(
				userId,
				currentSemester
			);
			console.log(studentFee);
			setFeeData(studentFee);
		} catch (error) {
			console.error("Error fetching score data", error);
		}
	};

	useEffect(() => {
		const fetchAndSetSemesters = async () => {
			const semesterList = await generateSemesterList();
			const semesters = semesterList.semesters;
			const currentSemester = semesterList.currentSemester;

			setSemesterData(semesters);

			fetchData(currentSemester);
		};
		fetchAndSetSemesters();
	}, [userId]);

	const handleSemesterChange = async (value) => {
		setSelectedSemester(value);
		const subjectList = await generateSubjectList(value);
		const subjects = subjectList.subjects;
		const currentSubject = subjectList.currentSubject;
		fetchData(currentSubject);
		setSubjectData(subjects);
	};

	const columns = [
		{
			title: "STT",
			dataIndex: "id",
			key: "id",
			align: "center",
			render: (text, index) => {
				<div>
					<span>{index + 1}</span>
				</div>;
			},
		},
		{
			title: "Tên môn",
			dataIndex: "subject",
			key: "gradeItem",
			align: "center",
		},
		{
			title: "khoản tiền",
			dataIndex: "amount",
			key: "amount",
			align: "center",
		},
		{
			title: "nội dung",
			dataIndex: "content",
			key: "content",
			align: "center",
		},
		{
			title: "hạn trả",
			dataIndex: "dueDate",
			key: "dueDate",
			align: "center",
		},
		{
			title: "ngày trả",
			dataIndex: "payDate",
			key: "payDate",
			align: "center",
		},
	];

	return (
		<div>
			<Select
				value={selectedSemester}
				onChange={handleSemesterChange}
				style={{ marginRight: 10, marginBottom: 10 }}
			>
				{semesterData.map((semester) => (
					<Select.Option key={semester.id} value={semester.id}>
						{semester.semesterName}
					</Select.Option>
				))}
			</Select>

			<Table dataSource={feeData} columns={columns} />
		</div>
	);
};

export default FeeHistory;
