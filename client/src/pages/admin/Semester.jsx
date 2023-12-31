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
        $expand: 'NextSemester,PrevSemester'
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
            startDay: dayjs(formValues.duration[0]).date(),
            endMonth: dayjs(formValues.duration[1]).month() + 1,
            endDay: dayjs(formValues.duration[1]).date(),
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
            const mappedData = {
                totalItems: response.totalItems,
                items: response.items.map(item => {
                    return ({
                        ...item,
                        duration: [
                            dayjs(`${dayjs().year()}/${String(item.startMonth).padStart(2, '0')}/${String(item.startDay).padStart(2, '0')}`, 'YYYY-MM-DD'),
                            dayjs(`${dayjs().year()}/${String(item.endMonth).padStart(2, '0')}/${String(item.endDay).padStart(2, '0')}`, 'YYYY-MM-DD')
                        ]
                    })
                })
            }
            return Promise.resolve(mappedData)

        })
    }
    const [semesters, setSemesters] = useState([]);
    const [disabledDate, setDisabledDate] = useState(null);
    useEffect(() => {
        onGet({ $expand: 'NextSemester,PrevSemester' }).then(response => setSemesters(response.items));
    }, [JSON.stringify(data)])

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
            key={4}
            label='Học kì trước đó'
            name='prevSemesterId'

        >
            <Select
                allowClear
                options={semesters
                    .filter(item => {
                        const notHaveNextSmt = !Boolean(item.nextSemester)
                        return notHaveNextSmt
                    })
                    .map(item => ({ value: item.id, label: item.semesterName }))}
            />
        </Form.Item>,
        <Form.Item
            key={3}
            label='Thời gian diễn ra'
            name='duration'
            rules={[{ required: true, message: 'Vui lòng chọn khoảng thời gian của học kì' }]}>
            <DatePicker.RangePicker
                picker="date"
            />
        </Form.Item>,

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