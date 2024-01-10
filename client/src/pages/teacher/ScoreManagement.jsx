import React, { useState, useEffect } from "react";
import { Table, Select, Input, Button } from "antd";
import useStudentApi from "../../apis/student.api";
import useClassApi from "../../apis/class.api";
import useAuthApi from "../../apis/auth.api";

const ScoreHistory = () => {
	const studentApi = useStudentApi();
	const ClassApi = useClassApi();
	const authApi = useAuthApi();

	const [selectedClass, setSelectedClass] = useState("");
	const [classData, setClassData] = useState([]);
	const [scoreData, setScoreData] = useState([]);
	const [userId, setUserId] = useState(null);
	const [subjectComponentsData, setSubjectComponentsData] = useState([]);
	const [editing, setEditing] = useState(false);
	const [columns, setColumns] = useState([]);
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

	const generateClassList = async () => {
		try {
			var classes = [];
			const userId = await getUser();
			classes = await ClassApi.GetClasses(userId);
			setSelectedClass((await classes)[0].id);
			return { classes: classes, currentClass: (await classes)[0].id };
		} catch (error) {
			console.error("Error fetching ", error);
			return [];
		}
	};

	const generateSubjectComponent = async (currentClass) => {
		const components = await ClassApi.GetSubjectComponents(currentClass);
		setSubjectComponentsData(components);
		return components;
	};

	const fetchData = async (currentClass) => {
		try {
			const studentScore = await ClassApi.GetStudents(currentClass);
			const components = await ClassApi.GetSubjectComponents(currentClass);

			const scoreHistoryList = [];
			studentScore.forEach((student) => {
				const scoreHistory = {
					key: `${student.studentName}_${currentClass}`,
					id: student.id,
					studentName: student.studentName,
				};

				student.subjectComponents.forEach((subjectComponent) => {
					const score =
						subjectComponent.scores.length !== 0
							? subjectComponent.scores[0].value !== null
								? subjectComponent.scores[0].value
								: ""
							: "";

					const studentScore = subjectComponent.scores.find(
						(s) => s.studentId === student.id
					);

					if (studentScore) {
						score.value = studentScore.value;
					}

					scoreHistory[subjectComponent.name] = score;
				});

				scoreHistoryList.push(scoreHistory);
			});
			setScoreData(scoreHistoryList);
		} catch (error) {
			console.error("Error fetching score data", error);
		}
	};

	useEffect(() => {
		const fetchAndSetClasses = async () => {
			const classList = await generateClassList();
			const classes = classList.classes;
			const currentClass = classList.currentClass;
			await generateSubjectComponent(currentClass);
			const components = await ClassApi.GetSubjectComponents(currentClass);
			setSubjectComponentsData(components);
			setClassData(classes);
			const dynamicColumns = [
				{ title: "STT", dataIndex: "id", key: "id", align: "center" },
				{
					title: "Tên sinh viên",
					dataIndex: "studentName",
					key: "studentName",
					align: "center",
				},
				components.map((item) => ({
					title: `${item.name}`,
					dataIndex: `${item.name}`,
					key: `${item.name}`,
					align: "center",
					editable: editing,
					render: (text, record) => {
						const handleInputChange = (value) => {
							setEditedData({
								...editedData,
								[record.key]: {
									...editedData[record.key],
									[item.name]: value,
								},
							});
						};

						const renderInput = () => (
							<Input
								value={text}
								onChange={(e) => handleInputChange(e.target.value)}
							/>
						);

						return editing ? renderInput() : <span>{text}</span>;
					},
				})),
			];

			setColumns(dynamicColumns);
			fetchData(currentClass);
		};
		fetchAndSetClasses();
	}, [userId, editing]);

	const handleClassChange = async (value) => {
		setSelectedClass(value);
		const components = await ClassApi.GetSubjectComponents(value);

		setSubjectComponentsData(components);
		const dynamicColumns = [
			{ title: "STT", dataIndex: "id", key: "id", align: "center" },
			{
				title: "Tên sinh viên",
				dataIndex: "studentName",
				key: "studentName",
				align: "center",
			},
			components.map((item) => ({
				title: `${item.name}`,
				dataIndex: `${item.name}`,
				key: `${item.name}`,
				align: "center",
				editable: editing,
				render: (text, record) => {
					const handleInputChange = (value) => {
						setEditedData({
							...editedData,
							[record.key]: {
								...editedData[record.key],
								[item.name]: value,
							},
						});
					};

					const renderInput = () => (
						<Input
							value={text}
							onChange={(e) => handleInputChange(e.target.value)}
						/>
					);

					return editing ? renderInput() : <span>{text}</span>;
				},
			})),
		];
		console.log(dynamicColumns);
		setColumns(dynamicColumns);
		fetchData(value);
	};

	const handleEditClick = () => {
		setEditing(true);
	};

	const handleSave = () => {
		setEditing(false);
	};

	const handleCancel = () => {
		setEditing(false);
		setEditedData({});
	};

	return (
		<div>
			<Select value={selectedClass} onChange={handleClassChange}>
				{classData.map((item) => (
					<Select.Option key={item.id} value={item.id}>
						{item.classCode}
					</Select.Option>
				))}
			</Select>

			{!editing && (
				<Button
					type="primary"
					onClick={handleEditClick}
					style={{ marginLeft: 8 }}
				>
					Edit
				</Button>
			)}

			{editing && (
				<>
					<Button type="primary" size="small" onClick={handleSave}>
						Save
					</Button>
					<Button size="small" onClick={handleCancel}>
						Cancel
					</Button>
				</>
			)}

			<Table
				dataSource={scoreData}
				columns={columns}
				rowKey={(record) => record.key}
				pagination={false}
			/>
		</div>
	);
};

export default ScoreHistory;
