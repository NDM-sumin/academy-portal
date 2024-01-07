import React, { useState, useEffect } from "react";
import { Table, Select } from "antd";
import useStudentApi from "../../apis/student.api";
import useSemesterApi from "../../apis/semester.api";
import useSubjectApi from "../../apis/subject.api";
import useAuthApi from "../../apis/auth.api";
import dayjs from "dayjs";

const ScoreHistory = () => {
	const studentApi = useStudentApi();
	const semesterApi = useSemesterApi();
	const subjectApi = useSubjectApi();
	const authApi = useAuthApi();

	const [selectedSemester, setSelectedSemester] = useState("");
	const [selectedSubject, setSelectedSubject] = useState("");
	const [semesterData, setSemesterData] = useState([]);
	const [subjectData, setSubjectData] = useState([]);
	const [scoreData, setScoreData] = useState([]);
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

	const generateSubjectList = async (currentSemester) => {
		try {
			var subjects = [];
			const userId = await getUser();
			subjects = await subjectApi.GetSubjects(currentSemester, userId);

			setSelectedSubject((await subjects)[0].id);
			return { subjects: subjects, currentSubject: (await subjects)[0].id };
		} catch (error) {
			console.error("Error fetching semesters", error);
			return [];
		}
	};

	const fetchData = async (currentSubject) => {
		try {
			const userId = await getUser();
			const studentScore = await studentApi.getScores(userId, currentSubject);
			const scoreHistoryList = [];
			let totalWeightedScore = 0;

			studentScore.forEach((score, index) => {
				const weightedScore = score.scores[0].value * (score.weight / 100);
				totalWeightedScore += weightedScore;
				const scoreHistory = {
					id: index + 1,
					key: index + 1,
					gradeItem: score.name,
					weight: score.weight + "%",
					score: score.scores[0].value,
					comment: score.comment,
					weightedScore: weightedScore.toFixed(2),
				};

				scoreHistoryList.push(scoreHistory);
			});

			const totalRow = {
				key: "total",
				gradeItem: "Tổng điểm",
				weight: null,
				score: totalWeightedScore.toFixed(2),
				comment: null,
			};
			setScoreData(scoreHistoryList.concat(totalRow));
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
			const subjectList = await generateSubjectList(currentSemester);
			const subjects = subjectList.subjects;
			const currentSubject = subjectList.currentSubject;

			setSubjectData(subjects);
			fetchData(currentSubject);
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

	const handleSubjectChange = async (value) => {
		setSelectedSubject(value);
		fetchData(value);
	};

	const columns = [
		{ title: "STT", dataIndex: "id", key: "id", align: "center" },
		{
			title: "Tên thành phần môn",
			dataIndex: "gradeItem",
			key: "gradeItem",
			align: "center",
		},
		{
			title: "Trọng điểm",
			dataIndex: "weight",
			key: "weight",
			align: "center",
		},
		{ title: "Điểm", dataIndex: "score", key: "score", align: "center" },
		{
			title: "Nhận xét",
			dataIndex: "comment",
			key: "comment",
			align: "center",
			render: (text, record) => {
				if (record.key === "total") {
					let color;
					let fontWeight;
					let label;

					if (record.score >= 5) {
						color = "green";
						label = "(Qua môn)";
					} else {
						color = "red";
						label = "(Trượt môn)";
					}

					fontWeight = "bold";

					return (
						<span style={{ color, fontWeight }}>
							<strong>
								{text} {label}
							</strong>
						</span>
					);
				}

				return <span>{text}</span>;
			},
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

			<Select value={selectedSubject} onChange={handleSubjectChange}>
				{subjectData.map((subject) => (
					<Select.Option key={subject.id} value={subject.id}>
						{subject.subjectName}
					</Select.Option>
				))}
			</Select>

			<Table dataSource={scoreData} columns={columns} />
		</div>
	);
};

export default ScoreHistory;
