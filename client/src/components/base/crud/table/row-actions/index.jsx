import { Space } from "antd"
import UpdateButton from "./UpdateButton"
import DeleteButton from "./DeleteButton"


const RowActions = ({ record }) => {


    return <Space>
        <UpdateButton record={record} />
        <DeleteButton record={record} />
    </Space>
}
export default RowActions