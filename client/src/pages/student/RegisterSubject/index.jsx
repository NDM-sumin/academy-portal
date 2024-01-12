import { useForm } from "antd/es/form/Form";
import {  Button, Col, Result, Row, Space, notification } from "antd";
import RegisterSubjectForm from "./Form";
import RegisterSubjectDetail from "./Detail";
import { useAppContext } from "../../../hooks/context/app-bounding-context";
import RegisterSubjectFormSelect from "./Form/Select";
import useSubjectApi from "../../../apis/subject.api";
import { useEffect, useState } from "react";
import RegisterSubjectTotal from "./Total";
import { HubConnectionBuilder } from "@microsoft/signalr";
import useStudentApi from "../../../apis/student.api";

const RegisterSubject = () => {
	const [form] = useForm();
    const subjectApi = useSubjectApi();
	const studentApi = useStudentApi();
  let connection = new HubConnectionBuilder()
    .withUrl(import.meta.env.VITE_API_URL + '/payment')
    .withAutomaticReconnect()
    .build();

	const [subjects, setSubjects] = useState([]);
	useEffect(() => {
		subjectApi.getRegisterableSubjects().then((response) => {
			setSubjects(response);
		});
        return () => {
            setSubjects([])
        }
	}, []); 
	const [paymentTransaction, setPaymentTransaction] = useState();

    const globalContext = useAppContext();
	const [selectedValues, setSelectedValues] = useState([]);
	const onClick = () => {
		subjectApi.GetPayUrl(selectedValues).then(response => {

        var txnRef = response.txnRef
        connection.start().then(() => {
          connection.invoke('RegisterPayment', connection.connectionId, txnRef);
        });
        connection.on('ReceivePaidStatus', (paymentTransaction) => {
			console.log(paymentTransaction);
			setPaymentTransaction(JSON.parse(paymentTransaction));
		
        });
        window.open(response.payUrl, '_blank');
		})
	}
	useEffect(() => {
		if(!paymentTransaction) return;
	const success = paymentTransaction.ResponseCode == 0 && paymentTransaction.TransactionStatus == 0;
		if(success){
			var feeDetails = selectedValues.map((item) => ({
				paymentTransactionId:paymentTransaction.Id,
				subjectId: item
			}))
			studentApi.registerMultiSubject(feeDetails).then(response => {
				notification.success({message:'Đăng ký môn học thành công'})
			})
		}
		return () => {
			setPaymentTransaction(undefined);
		}
	},[JSON.stringify(paymentTransaction)])
const getPaymentResultProps = () => {
   	const success = paymentTransaction.ResponseCode == 0 && paymentTransaction.TransactionStatus == 0;
    return {
      status: (success) ? 'success' : 'error',
      title: `Thanh toán học phí ${success ? 'thành công' : 'thất bại'}`,
      subTitle: (<>
        <p>Số đơn hàng: {paymentTransaction.TxnRef}</p>
        <p>Mã giao dịch: {paymentTransaction.TransactionNo}</p>
        <p>Nội dung giao dịch: {paymentTransaction.OrderInfo}</p>
        <Button onClick={() => {
         setSelectedValues([]);
		 setPaymentTransaction();
        }}>OK</Button>
      </>),
    };
  };



	return (
	<Row style={{width:'100%'}} justify={'center'}>
		<Col span={6} />
		<Col span={12} style={{'textAlign':'center'}}>
			{!paymentTransaction && <Space direction="vertical" style={{width:'100%'}}>
				<RegisterSubjectFormSelect 
 					subjects={subjects}
  					selectedValues={selectedValues}
   					onSelectChange={setSelectedValues}/>
				<RegisterSubjectDetail selectedSubject={subjects.filter(s => selectedValues.includes(s.id))}/>
				<RegisterSubjectTotal selectedSubjects={subjects.filter(s => selectedValues.includes(s.id))} />
				<Button type="primary" onClick={onClick} loading={globalContext.loading} disabled={selectedValues.length == 0} > 
            		Đăng ký
        		</Button>
			</Space>
}
{
paymentTransaction &&
<Result
      {...getPaymentResultProps()}
    />
}
		
		
		</Col>
		<Col span={6} />
		
	</Row>
		
	);
};
export default RegisterSubject;
