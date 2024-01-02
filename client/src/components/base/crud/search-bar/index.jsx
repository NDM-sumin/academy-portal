import { ReloadOutlined } from "@ant-design/icons";
import { Button, Divider, Space } from "antd";
import ReloadButton from "./ReloadButton";
import CreateButton from "./CreateButton";
import ExportButton from "./ExportButton";
import ImportButton from "./ImportButton";

const CRUDSearchBar = () => {
	return (
		<Space>
			<ReloadButton />
			<CreateButton />
			<ExportButton />
			<ImportButton />
		</Space>
	);
};
export default CRUDSearchBar;
