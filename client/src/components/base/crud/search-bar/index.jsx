import { ReloadOutlined } from "@ant-design/icons";
import { Button, Divider, Space } from "antd";
import ReloadButton from "./ReloadButton";
import CreateButton from "./CreateButton";

const CRUDSearchBar = ({ additionButton }) => {
	return (
		<Space>
			<ReloadButton />
			<CreateButton />
			
			{
				...(additionButton ?? [])
			}
		</Space>
	);
};
export default CRUDSearchBar;
