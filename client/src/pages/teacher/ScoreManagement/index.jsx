import { useState, useEffect } from "react";
import { Table, Select, Button, notification, Form, InputNumber } from "antd";
import useClassApi from "../../../apis/class.api";
import useAuthApi from "../../../apis/auth.api";
import { useAppContext } from "../../../hooks/context/app-bounding-context";
import GetExcelTemplateButton from "./GetExcelTemplateButton";
import UploadExcelScore from "./UploadExcelScore";

const ScoreHistory = () => {
  const ClassApi = useClassApi();
  const authApi = useAuthApi();

  const [selectedClass, setSelectedClass] = useState(null);
  const [classData, setClassData] = useState([]);
  const [scoreData, setScoreData] = useState([]);
  const [userId, setUserId] = useState(null);
  const [subjectComponentsData, setSubjectComponentsData] = useState([]);
  const [editing, setEditing] = useState(false);

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
      setSelectedClass((await classes)[0]);
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
      dataIndex: `${item.code}`,
      key: `${item.code}`,
      align: "center",
      editable: editing,
      render: (text, record) => {
        return editing ? (
          <InputNumber
            min={0}
            max={10}
            value={text}
            onChange={(value) =>
              handleInputChange(record.key, item.code, value)
            }
          />
        ) : (
          <span>{text}</span>
        );
      },
    })),
  ];

  const fetchData = async (currentClass) => {
    try {
      const studentScore = await ClassApi.GetStudents(currentClass);
      const scoreHistoryList = studentScore.map((student, index) => {
        const scoreHistory = {
          index: index + 1,
          key: student.studentId,
          id: currentClass,
          studentName: student.studentName,
        };
        student.subjectComponents.map((subjectComponent) => {
          const score = subjectComponent.scores[0].value ?? "";
          scoreHistory[subjectComponent.code] = score;
        });
        return scoreHistory;
      });
      setScoreData(scoreHistoryList);
    } catch (error) {
      console.error("Error fetching score data", error);
    }
  };
  const fetchAndSetClasses = async () => {
    const classList = await generateClassList();
    await generateSubjectComponent(classList.currentClass);
    const components = await ClassApi.GetSubjectComponents(
      classList.currentClass
    );
    setSubjectComponentsData(components);
    setClassData(classList.classes);
    fetchData(classList.currentClass);
  };
  useEffect(() => {
    fetchAndSetClasses();
  }, [userId, editing]);

  const handleClassChange = async (selectedClassId) => {
    setSelectedClass(classData.find((item) => item.id == selectedClassId));
    const components = await ClassApi.GetSubjectComponents(selectedClassId);
    setSubjectComponentsData(components);
    fetchData(selectedClassId);
  };
  const handleInputChange = (studentId, scoreComponentCode, scoreValue) => {
    const changeData = scoreData.map((item) => {
      if (
        item.key === studentId &&
        Object.keys(item).includes(scoreComponentCode)
      ) {
        item[scoreComponentCode] = scoreValue;
      }

      return item;
    });
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
    fetchAndSetClasses();
  };

  const handleCancel = () => {
    setEditing(false);
  };
  const context = useAppContext();
  return (
    <div>
      {" "}
      <Form layout="inline">
        <Form.Item label="Lớp học">
          <Select
            value={selectedClass?.id}
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
        <Form.Item>
          <GetExcelTemplateButton selectedClass={selectedClass} />
        </Form.Item>
        <Form.Item>
          <UploadExcelScore
            selectedClass={selectedClass}
            onSuccess={fetchAndSetClasses}
          />
        </Form.Item>

        {!editing && (
          <Button
            type="primary"
            onClick={handleEditClick}
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
