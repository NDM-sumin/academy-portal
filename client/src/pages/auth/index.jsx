import { Card, Col, Layout, Row } from "antd";
import "./index.css";
import EPULogo from "../../assets/images/epu-logo.png";
import { Outlet } from "react-router-dom";

const colSpan = {
	xs: {
		span: 24,
		offset: 0,
	},
	sm: {
		span: 16,
		offset: 4,
	},
	md: {
		span: 6,
		offset: 9,
	},
};
const AuthLayout = () => {
	return (
		<Layout className="auth-layout">
			<Row style={{ height: "100%" }} align="middle">
				<Col {...colSpan}>
					<Card
						cover={
							<img
								src={EPULogo}
								style={{ objectFit: "cover", width: "100%" }}
								alt=""
							/>
						}
					>
						<Outlet />
					</Card>
				</Col>
			</Row>
		</Layout>
	);
};
export default AuthLayout;
