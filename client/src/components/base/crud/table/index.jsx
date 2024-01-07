import { Table } from "antd";
import { useCRUDContext } from "../../../../hooks/context/crud-context";
import RowActions from "./row-actions";



const CRUDTable = () => {
    const context = useCRUDContext();
    const columns = [
        ...context.columns,
        {
            render: (_, record, index) => <RowActions record={record} />
        }
    ]

    return <Table
        columns={columns}
        dataSource={context.dataState[0].items}
        key={"id"}
        pagination={{
            current: (context.queryState[0].skip ?? 0 / context.queryState[0].top ?? 50) + 1,
            pageSize: context.queryState[0].top ?? 50,
            onChange: (page, pageSize) => {
                context.queryState[1]({
                    ...context.queryState[0],
                    skip: (page - 1) * pageSize,
                    top: pageSize
                })
                context.reloadState[1](true);
            }
        }}
    >

    </Table>
}
export default CRUDTable;