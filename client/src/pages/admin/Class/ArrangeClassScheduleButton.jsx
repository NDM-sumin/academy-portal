import { PlayCircleOutlined } from "@ant-design/icons";
import { Button, Popconfirm, notification } from "antd";
import useClassApi from "../../../apis/class.api";
import { useAppContext } from "../../../hooks/context/app-bounding-context";

const ArrangeClassScheduleButton = () => {
	const classApi = useClassApi();
	const appContext = useAppContext();
	return (
		<Popconfirm
			title="Bạn có chắc chắn muốn bắt đầu xếp lịch không?"
			description="Chương trình sẽ thiết lập lịch học ở học kì hiện tại cho toàn bộ sinh viên"
			onConfirm={() => {
				classApi.ClassForNewSemester().then(() => {
					notification.success({ message: "Thành công" });
				});
			}}
		>
			<Button icon={<PlayCircleOutlined />} loading={appContext.loading}>
				Bắt đầu xếp lịch học
			</Button>
		</Popconfirm>
	);
};
export default ArrangeClassScheduleButton;
