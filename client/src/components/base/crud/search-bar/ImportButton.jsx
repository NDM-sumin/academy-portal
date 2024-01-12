import { ImportOutlined } from "@ant-design/icons";
import { Button, Upload, message } from "antd";
import { useCRUDContext } from "../../../../hooks/context/crud-context";
import { useAppContext } from "../../../../hooks/context/app-bounding-context";

const ImportButton = () => {
	const context = useCRUDContext();
	const appContext = useAppContext();
	const beforeUpload = (file) => {
		return true;
	};

	const onChange = (info) => {
		if (info.file.status === "done") {
			message.success(`${info.file.name} file uploaded successfully`);
			context.reloadState[1](true);
		} else if (info.file.status === "error") {
			message.error(`${info.file.name} file upload failed.`);
			console.error("Upload error:", info.file.response);
		}
	};

	const customRequest = ({ file, onSuccess, onError }) => {
		context.crudApi
			.importData(file)
			.then(() => onSuccess())
			.catch((error) => {
				message.error("File upload failed. Please try again.");
				onError(error);
			});
	};

	return (
		<Upload
			customRequest={customRequest}
			showUploadList={false}
			beforeUpload={beforeUpload}
			onChange={onChange}
		>
			<Button loading={appContext.loading} icon={<ImportOutlined />}>Nhập File Excel</Button>
		</Upload>
	);
};

export default ImportButton;
