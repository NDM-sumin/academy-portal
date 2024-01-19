import { DownloadOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { useAppContext } from "../../../hooks/context/app-bounding-context";
import useClassApi from "../../../apis/class.api";

const GetExcelTemplateButton = ({selectedClass}) => {
  const appContext = useAppContext();

  const classApi = useClassApi();
  const onClick = () => {
    console.log(selectedClass.id);
    classApi.GetExcelScoreTemplate(selectedClass.id).then((response) => {
      var url = URL.createObjectURL(response);
      var aTag = document.createElement("a");
      aTag.href = url;
      aTag.download = `${selectedClass.classCode}_score.xlsx`;
      aTag.click();
    });
  };
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
