import { PlayCircleOutlined } from "@ant-design/icons";
import { Button, Popconfirm, notification } from "antd";
import useSemesterApi from "../../../apis/semester.api";
import { useAppContext } from "../../../hooks/context/app-bounding-context";

const ArrangeClassScheduleButton = () => {
	const semesterApi = useSemesterApi();
	const appContext = useAppContext();
	return (
		<Popconfirm
			title="Bạn có chắc chắn muốn bắt đầu học kì mới?"
			description="Chương trình sẽ thiết lập học kì kế tiếp học kì hiện tại cho toàn bộ sinh viên"
			onConfirm={() => {
				semesterApi.startNewSemester().then(() => {
					notification.success({ message: "Thành công" });
				});
			}}
		>
			<Button icon={<PlayCircleOutlined />} loading={appContext.loading}>
				Bắt đầu học kì mới
			</Button>
		</Popconfirm>
	);
};
export default ArrangeClassScheduleButton;
