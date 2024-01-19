import { UploadOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { useAppContext } from "../../../hooks/context/app-bounding-context";

const UploadExcelScore = () => {
  const appContext = useAppContext();
  const onClick = () => {};
  return (
    <Button
      icon={<UploadOutlined />}
      loading={appContext.loading}
      onClick={onClick}
    >
      Nhập điểm từ excel
    </Button>
  );
};
export default UploadExcelScore;
