import React, { useState, useEffect } from "react";
import {
  Table,
  Select,
  Input,
  Button,
  Space,
  notification,
  Form,
  InputNumber,
} from "antd";
import useStudentApi from "../../apis/student.api";
import useClassApi from "../../apis/class.api";
import useAuthApi from "../../apis/auth.api";
import { useAppContext } from "../../hooks/context/app-bounding-context";

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
  const [editedData, setEditedData] = useState({});

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
      if (classes.length == 0) {
        return;
      }
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

  const columns = [
    { title: "STT", dataIndex: "index", key: "index", align: "center" },
    {
      title: "Tên sinh viên",
      dataIndex: "studentName",
      key: "studentName",
      align: "center",
    },
    ...subjectComponentsData.map((item) => ({
      title: `${item.name}`,
      dataIndex: `${item.name}`,
      key: `${item.name}`,
      align: "center",
      editable: editing,
      render: (text, record) => {
        const renderInput = () => (
          <InputNumber
            min={0}
            max={10}
            value={text}
            onChange={(value) =>
              handleInputChange(record.key, item.name, value)
            }
          />
        );

        return editing ? renderInput() : <span>{text}</span>;
      },
    })),
  ];

  const fetchData = async (currentClass) => {
    try {
      const studentScore = await ClassApi.GetStudents(currentClass);
      const components = await ClassApi.GetSubjectComponents(currentClass);
      console.log(studentScore);
      const scoreHistoryList = [];
      studentScore.forEach((student, index) => {
        const scoreHistory = {
          index: index + 1,
          key: student.studentId,
          id: currentClass,
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
  const fetchAndSetClasses = async () => {
    const classList = await generateClassList();
    const classes = classList.classes;
    const currentClass = classList.currentClass;
    await generateSubjectComponent(currentClass);
    const components = await ClassApi.GetSubjectComponents(currentClass);
    setSubjectComponentsData(components);
    setClassData(classes);

    fetchData(currentClass);
  };
  useEffect(() => {
    fetchAndSetClasses();
  }, [userId, editing]);

  const handleClassChange = async (value) => {
    setSelectedClass(value);
    const components = await ClassApi.GetSubjectComponents(value);
    setSubjectComponentsData(components);

    fetchData(value);
  };
  const handleInputChange = (studentId, columnname, value) => {
    console.log(value);
    const changeData = scoreData.map((item) => {
      if (item.key === studentId) {
        Object.keys(item).map((propName) => {
          if (propName === columnname) {
            item[propName] = value;
          }
        });
      }
      return item;
    });
    console.log(changeData);
    setScoreData(changeData);
  };

  const handleEditClick = () => {
    setEditing(true);
  };

  const handleSave = async () => {
    setEditing(false);
    await ClassApi.SaveScores(scoreData);
    notification.success({
      message: "Lưu điểm thành công",
    });
    fetchAndSetClasses()
  };

  const handleCancel = () => {
    setEditing(false);
    setEditedData({});
  };
  const context = useAppContext();
  return (
    <div>
      {" "}
      <Form layout="inline">
        <Form.Item label="Lớp học">
          <Select
            value={selectedClass}
            style={{ marginLeft: 8, marginBottom: 10 }}
            onChange={handleClassChange}
            loading={context.loading}
          >
            {classData.map((item) => (
              <Select.Option key={item.id} value={item.id}>
                {item.classCode}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>

        {!editing && (
          <Button
            type="primary"
            onClick={handleEditClick}
            style={{ marginLeft: 8, marginBottom: 10 }}
            loading={context.loading}
          >
            Chỉnh sửa điểm
          </Button>
        )}

        {editing && (
          <>
            <Form.Item>
              <Button
                type="primary"
                onClick={handleSave}
                loading={context.loading}
              >
                Lưu
              </Button>
            </Form.Item>
            <Form.Item>
              <Button onClick={handleCancel} loading={context.loading}>
                Hủy
              </Button>
            </Form.Item>
          </>
        )}
      </Form>
      <Table
        dataSource={scoreData}
        columns={columns}
        rowKey={(record) => record.key}
        pagination={true}
        loading={context.loading}
      />
    </div>
  );
};

export default ScoreHistory;
