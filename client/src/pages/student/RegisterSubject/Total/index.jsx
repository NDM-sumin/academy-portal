import { Descriptions } from "antd"

const RegisterSubjectTotal = ({selectedSubjects}) => {
const formatter = new Intl.NumberFormat('vi-VN', {
  style: 'currency',
  currency: 'VND',
});
const item = [
    {
        'key':'tong-so-mon',
        label: 'Tổng số môn đăng ký',
        children: selectedSubjects.length + ' môn'
    },
    {
        key:'tong-tien',
        label:'Tổng học phí thanh toán',
        children: formatter.format(selectedSubjects.reduce((prv, next) => prv + next.price , 0))
    }
]


    return <Descriptions 
    title="Tổng cộng"
    items={item}
    bordered={true}
    column={1}

    />
}
export default RegisterSubjectTotal