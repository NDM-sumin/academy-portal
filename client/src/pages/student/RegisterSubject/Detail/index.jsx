import { Descriptions, Table } from "antd"



const RegisterSubjectDetail  =({selectedSubject}) => {

const formatter = new Intl.NumberFormat('vi-VN', {
  style: 'currency',
  currency: 'VND',
});

const column = [
    {
        title:'#',
        dataIndex: 'id',
        render: (v, r, idx) => idx + 1
    },
    {
        title:'Code',
        dataIndex: 'subjectCode'
    },
    {
        title:'Name',
        dataIndex: 'subjectName'
    },
    {
        title:'Price',
        dataIndex: 'price',
        render: (v, r, idx) => formatter.format(v)
    }
    
]


    return <Table
        bordered={true}
       columns={column}
       rowKey={'id'}
       dataSource={selectedSubject}
       pagination={false}
    >
        
    </Table>
}
export default RegisterSubjectDetail