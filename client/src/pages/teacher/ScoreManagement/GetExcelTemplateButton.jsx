import { DownloadOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { useAppContext } from "../../../hooks/context/app-bounding-context";

const GetExcelTemplateButton = () => {
  const appContext = useAppContext();
  const onClick = () => {};
  return (
    <Button
      icon={<DownloadOutlined />}
      loading={appContext.loading}
      onClick={onClick}
    >
      Tải mẫu exel nhập điểm
    </Button>
  );
};
export default GetExcelTemplateButton;
