import React, { useState } from "react";
import moment from "moment";
import { Modal, Button } from "antd";

const daysOfWeek = [
	"Monday",
	"Tuesday",
	"Wednesday",
	"Thursday",
	"Friday",
	"Saturday",
	"Sunday",
];

const timeSlots = [
	{ start: "08:00", end: "10:00" },
	{ start: "10:00", end: "12:00" },
	{ start: "13:00", end: "15:00" },
	{ start: "15:00", end: "17:00" },
];

function StudentTimetable() {
	const [visible, setVisible] = useState(false);

	const showModal = () => {
		setVisible(true);
	};

	const handleCancel = () => {
		setVisible(false);
	};

	return (
		<div className="timetable">
			{timeSlots.map((slot) => (
				<div key={slot.start} className="time-slot">
					<div
						className="time"
						onClick={showModal}
					>{`${slot.start} - ${slot.end}`}</div>
					{daysOfWeek.map((day) => (
						<div key={`${day}-${slot.start}`} className="cell">
							{/* Thêm nội dung tương ứng với thời gian và ngày */}
						</div>
					))}
				</div>
			))}

			{/* Modal */}
			<Modal
				title="Time Slot Details"
				visible={visible}
				onCancel={handleCancel}
				footer={[
					<Button key="back" onClick={handleCancel}>
						Close
					</Button>,
				]}
			>
				{/* Thêm các trường và thông tin chi tiết về time slot trong modal */}
				<p>
					Time: {moment().format("HH:mm")} -{" "}
					{moment().add(2, "hours").format("HH:mm")}
				</p>
				<p>Day: Monday</p>
				{/* Thêm các trường khác cần hiển thị */}
			</Modal>
		</div>
	);
}

export default StudentTimetable;
