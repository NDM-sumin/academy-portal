import { UploadOutlined } from "@ant-design/icons";
import { Button, Upload, message, notification } from "antd";
import { useAppContext } from "../../../hooks/context/app-bounding-context";
import useClassApi from "../../../apis/class.api";

const UploadExcelScore = ({ selectedClass, onSuccess }) => {
  const appContext = useAppContext();
  const onClick = () => {};
  const classApi = useClassApi();
  const onChange = (info) => {
    if (info.file.status === "done") {
      onSuccess();
      notification.success({
        message: "Upload điểm thành công",
      });
    } else if (info.file.status === "error") {
      console.error("Upload error:", info.file.response);
    }
  };

  const customRequest = ({ file, onSuccess, onError }) => {
    if (!selectedClass.id) return;
    classApi
      .UploadScoreExcel(selectedClass.id, file)
      .then(() => onSuccess())
      .catch((error) => {
        onError(error);
      });
  };
  return (
    <Upload
      beforeUpload={() => true}
      showUploadList={false}
      customRequest={customRequest}
      onChange={onChange}
    >
      <Button
        icon={<UploadOutlined />}
        loading={appContext.loading}
        onClick={onClick}
      >
        Nhập điểm từ excel
      </Button>
    </Upload>
  );
};
export default UploadExcelScore;
