import { Table } from "antd";
import { useCRUDContext } from "../../../../hooks/context/crud-context";
import RowActions from "./row-actions";
import { useAppContext } from "../../../../hooks/context/app-bounding-context";

const CRUDTable = () => {
  const context = useCRUDContext();
  const columns = [
    ...context.columns,
    {
      render: (_, record, index) => <RowActions record={record} />,
    },
  ];
  const appContext = useAppContext();
  console.log(
    Number(((context.queryState[0].skip ?? 0) / (context.queryState[0].top ?? 10))) + 1
  );
  return (
    <Table
      loading={appContext.loading}
      columns={columns}
      dataSource={context.dataState[0].items}
      key={"id"}
      pagination={{
        total: context.dataState[0].totalItems,
        current:
          Number(
            (context.queryState[0].skip ?? 0) /
              (context.queryState[0].top ?? 10)
          ) + 1,
        pageSize: context.queryState[0].top ?? 10,
        onChange: (page, pageSize) => {
          context.queryState[1]({
            ...context.queryState[0],
            skip: (page - 1) * pageSize,
            top: pageSize,
          });
          context.reloadState[1](true);
        },
      }}
    ></Table>
  );
};
export default CRUDTable;
