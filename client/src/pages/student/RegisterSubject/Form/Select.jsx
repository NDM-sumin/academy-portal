import { Form, Select } from "antd"
import useSubjectApi from "../../../../apis/subject.api";
import { useEffect, useState } from "react";

const RegisterSubjectFormSelect = ({subjects, selectedValues, onSelectChange}) => {




    return  <Form.Item
    
    style={{width:'100%'}}
        label="Chọn môn học"
        name="subjectId"
        rules={[{ required: true, message: "Vui lòng chọn môn học" }]}
    >
    <Select 
    style={{width:'100%'}}
    placeholder="Chọn môn học"
    mode="multiple"
    value={selectedValues}
    onChange={(value,option) => onSelectChange(value)}
    options={subjects.map((subject) => (
        {
            value:subject.id,
            label: `${subject.subjectName} (${subject.subjectCode})`
        }
    ))}
    />
    </Form.Item>
}
export default RegisterSubjectFormSelect