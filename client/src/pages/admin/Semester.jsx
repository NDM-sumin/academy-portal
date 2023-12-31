import { useEffect, useState } from "react"
import CRUDPage from "../../components/base/crud"
import { useForm } from "antd/es/form/Form";
import { DatePicker, Form, Input, Select, message } from "antd";
import useMajorApi from "../../apis/major.api";
import useSemesterApi from "../../apis/semester.api";
import dayjs from "dayjs";



const Semester = () => {
    const [data, setData] = useState({ totalItems: 0, items: [] })
    const [query, setQuery] = useState({
        $skip: 0,
        $top: 50,
    });
    const [modalProps, setModalProps] = useState({
        open: false
    })
    const [reload, setReload] = useState(true);
    const columns = [
        {
            title: 'Mã học kì',
            dataIndex: 'semesterCode'
        },
        {
            title: 'Tên học kì',
            dataIndex: 'semesterName'
        },
        {
            title: 'Ngày bắt đầu học kì',
            render: (_, record, __) => `${record.startDay}/${record.startMonth}`
        },
        {
            title: 'Ngày kết thúc học kì',
            render: (_, record, __) => `${record.endDay}/${record.endMonth}`
        }
    ]
    const api = useSemesterApi();
    const refactorFormValue = (formValues) => {
        return {
            ...formValues,
            startMonth: dayjs(formValues.duration[0]).month() + 1,
            startDay: 1,
            endMonth: dayjs(formValues.duration[1]).month() + 1,
            endDay: 1,
        }
    }
    const onCreate = (formValues) => {
        return api.create(refactorFormValue(formValues))
    }
    const onUpdate = (formValues) => {
        return api.update(refactorFormValue(formValues))
    }
    const onGet = (query) => {
        return api.get(query).then(response => {

            return Promise.resolve({
                totalItems: response.totalItems,
                items: response.items.map(item => ({
                    ...item,
                    duration: [
                        dayjs(`${dayjs().year()}/${item.startMonth}/${item.startDay}`),
                        dayjs(`${dayjs().year()}/${item.endMonth}/${item.endDay}`)
                    ]
                }))
            })

        })
    }
    const [semesters, setSemesters] = useState();
    useEffect(() => {
        api.get().then(response => setSemesters(response.items));
    }, [data.totalItems])

    const crudApi = {
        create: onCreate,
        update: onUpdate,
        search: onGet,
        delete: api.del
    }
    const searchBarItems = []
    const formItems = [
        <Form.Item
            key={1}
            label='Mã học kì'
            name='semesterCode'
            rules={[{ required: true, message: 'Vui lòng nhập mã học kì' }]}>
            <Input />
        </Form.Item>,
        <Form.Item
            key={2}
            label='Tên học kì'
            name='semesterName'
            rules={[{ required: true, message: 'Vui lòng nhập tên học kì' }]}>
            <Input />
        </Form.Item>,
        <Form.Item
            key={3}
            label='Thời gian diễn ra'
            name='duration'
            rules={[{ required: true, message: 'Vui lòng chọn khoảng thời gian của học kì' }]}>
            <DatePicker.RangePicker picker="month" format={'01/MM'} />
        </Form.Item>,
        <Form.Item
            key={4}
            label='Học kì trước đó'
            name='prevSemesterId'
            rules={[{ required: semesters.length > 0, message: 'Vui lòng chọn học kì đã kết thúc trước học kì này' }]}>
            <Select options={semesters.map(item => ({value: item.id, label: item.semesterName}))} />
        </Form.Item>
    ]
    const form = {
        instance: useForm()[0],
        items: formItems
    }

    const contextValue = {
        columns: columns,
        crudApi: crudApi,
        dataState: [data, setData],
        queryState: [query, setQuery],
        searchBarItems: searchBarItems,
        modalState: [modalProps, setModalProps],
        reloadState: [reload, setReload],
        form: form
    }
    return <CRUDPage

        contextValue={contextValue}

    />
}
export default Semester