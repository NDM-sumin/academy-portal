import { useForm } from "antd/es/form/Form";
import {  Button, Col, Row, Space } from "antd";
import RegisterSubjectForm from "./Form";
import RegisterSubjectDetail from "./Detail";
import { useAppContext } from "../../../hooks/context/app-bounding-context";
import RegisterSubjectFormSelect from "./Form/Select";
import useSubjectApi from "../../../apis/subject.api";
import { useEffect, useState } from "react";
import RegisterSubjectTotal from "./Total";
import { HubConnectionBuilder } from "@microsoft/signalr";

const RegisterSubject = () => {
	const [form] = useForm();
    const subjectApi = useSubjectApi();
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
    const globalContext = useAppContext();
	const [selectedValues, setSelectedValues] = useState([]);
	return (
	<Row style={{width:'100%'}} justify={'center'}>
		<Col span={6} />
		<Col span={12} style={{'textAlign':'center'}}>
			<Space direction="vertical" style={{width:'100%'}}>
				<RegisterSubjectFormSelect 
 					subjects={subjects}
  					selectedValues={selectedValues}
   					onSelectChange={setSelectedValues}/>
				<RegisterSubjectDetail selectedSubject={subjects.filter(s => selectedValues.includes(s.id))}/>
				<RegisterSubjectTotal selectedSubjects={subjects.filter(s => selectedValues.includes(s.id))} />
				<Button type="primary" htmlType="submit" loading={globalContext.loading} disabled={selectedValues.length == 0} > 
            		Đăng ký
        		</Button>
			</Space>
		
		
		</Col>
		<Col span={6} />
		
	</Row>
		
	);
};
export default RegisterSubject;
