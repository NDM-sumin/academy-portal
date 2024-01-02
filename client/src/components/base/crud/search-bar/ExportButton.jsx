import { ExportOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { useAppContext } from "../../../../hooks/context/app-bounding-context";
import { useCRUDContext } from "../../../../hooks/context/crud-context";

const ExportButton = () => {
	const context = useCRUDContext();
	const onClick = () => {
		context.modalState[1]({
			...context.modalState[0],
			open: true,
			onOk: context.crudApi.export,
		});
		context.form.instance.resetFields();
	};

	return (
		<Button icon={<ExportOutlined />} onClick={onClick}>
			Xuất File Excel
		</Button>
	);
};

export default ExportButton;
