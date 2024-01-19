import React, { useState, useEffect } from "react";
import { Table, Select, DatePicker, Button, message, Space, Form } from "antd";
import useClassApi from "../../apis/class.api";
import useAuthApi from "../../apis/auth.api";
import dayjs from "dayjs";
import { useAppContext } from "../../hooks/context/app-bounding-context";
const Attendance = () => {
  const ClassApi = useClassApi();
  const authApi = useAuthApi();
  const [selectedClass, setSelectedClass] = useState("");
  const [classData, setClassData] = useState([]);
  const [selectedDate, setSelectedDate] = useState(null);
  const [dateData, setDateData] = useState([]);
  const [attendanceData, setAttendanceData] = useState([]);
  const columns = [
    { title: "STT", dataIndex: "id", key: "id", align: "center" },
    {
      title: "Tên sinh viên",
      dataIndex: "studentName",
      key: "studentName",
      align: "center",
    },
    {
      title: "Điểm danh",
      dataIndex: "attendance",
      key: "attendance",
      align: "center",
      render: (text, record, index) => (
        <Select
          key={index}
          value={text}
          onChange={(value) => handleAttendanceChange(record.key, value)}
        >
          <Select.Option value="present">Có mặt</Select.Option>
          <Select.Option value="absent">Vắng mặt</Select.Option>
        </Select>
      ),
    },
  ];
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
  const generateClassList = async () => {
    try {
      var classes = [];
      const userId = await getUser();
      classes = await ClassApi.GetClasses(userId);
      if (classes.length == 0) return;
      setSelectedClass((await classes)[0].id);
      return { classes: classes, currentClass: (await classes)[0].id };
    } catch (error) {
      console.error("Error fetching ", error);
      return [];
    }
  };
  const generateDateList = async (currentClass) => {
    try {
      var dates = [];
      dates = await ClassApi.GetDates(currentClass);

      const formattedDates = dates.map((item) => {
        return dayjs(item).format("DD/MM/YYYY");
      });

      setSelectedDate((await formattedDates)[0]);
      return { dates: formattedDates, currentDate: (await formattedDates)[0] };
    } catch (error) {
      console.error("Error fetching semesters", error);
      return [];
    }
  };
  useEffect(() => {
    const fetch = async () => {
      try {
        const classList = await generateClassList();
        const classes = classList.classes;
        const currentClass = classList.currentClass;
        setClassData(classes);
        const dateList = await generateDateList(currentClass);
        const dates = dateList.dates;
        const currentDate = dateList.currentDate;

        setDateData(dates);
        fetchData(currentClass, currentDate);
      } catch (error) {
        console.error("Error fetching class list", error);
      }
    };

    fetch();
  }, [userId]);

  const handleClassChange = async (value) => {
    setSelectedClass(value);
    const dateList = await generateDateList(value);
    const dates = dateList.dates;
    const currentDate = dateList.currentDate;

    setDateData(dates);
    fetchData(value, currentDate);
  };

  const handleDateChange = (date) => {
    setSelectedDate(date);
    fetchData(selectedClass, date);
  };

  const fetchData = async (currentClass, currentDate) => {
    try {
      const attendance = await ClassApi.GetAttendances(
        currentClass,
        currentDate
      );

      const attendanceRecords = attendance.map((item, index) => ({
        key: item.attendance.id,
        id: index + 1,
        studentName: item.student.fullName,
        attendance:
          item.attendance && item.attendance.isAttendance === true
            ? "present"
            : "absent",
      }));
      setAttendanceData(attendanceRecords);
    } catch (error) {
      console.error("Error fetching attendance data", error);
    }
  };

  const handleAttendanceChange = (AttendanceId, value) => {
    const changeData = attendanceData.map((item) => {
      if (item.key === AttendanceId) {
        item.attendance = value;
      }
      return item;
    });

    setAttendanceData(changeData);
  };

  const handleSaveAttendance = async () => {
    try {
      await ClassApi.SaveAttendance(attendanceData);

      message.success("Đã lưu thông tin điểm danh thành công.");
    } catch (error) {
      console.error("Error saving attendance data", error);
      message.error("Đã xảy ra lỗi khi lưu thông tin điểm danh.");
    }
  };

  console.log(attendanceData);

  const context = useAppContext();
  return (
    <div>
      <Form layout="inline">
        <Form.Item label="lớp học">
          <Select
            style={{ marginBottom: 10 }}
            value={selectedClass}
            onChange={handleClassChange}
            loading={context.loading}
          >
            {classData.map((item, index) => (
              <Select.Option key={index} value={item.id}>
                {item.classCode}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
        <Form.Item label="Thời gian">
          <Select
            style={{ marginBottom: 10 }}
            value={selectedDate}
            onChange={handleDateChange}
            loading={context.loading}
          >
            {dateData.map((item, index) => (
              <Select.Option key={index} value={item}>
                {item}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
        <Form.Item>
          <Button
            type="primary"
            onClick={handleSaveAttendance}
            loading={context.loading}
          >
            Lưu thay đổi
          </Button>
        </Form.Item>
      </Form>
      <Table
        dataSource={attendanceData}
        columns={columns}
        rowKey={(record) => record.key}
        pagination={true}
        loading={context.loading}
      />
    </div>
  );
};

export default Attendance;
