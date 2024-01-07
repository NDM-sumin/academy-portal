import { useState } from "react"
import CRUDPage from "../../components/base/crud"
import { useForm } from "antd/es/form/Form";
import { Form, Input, message } from "antd";
import useMajorApi from "../../apis/major.api";



const Major = () => {
    const [data, setData] = useState({ totalItems: 0, items: [] })
    const [query, setQuery] = useState({
        skip: 0,
        top: 50
    });
    const [modalProps, setModalProps] = useState({
        open: false
    })
    const [reload, setReload] = useState(true);
    const columns = [
        {
            title: 'Mã chuyên ngành',
            dataIndex: 'majorCode'
        },
        {
            title: 'Tên chuyên ngành',
            dataIndex: 'majorName'
        },
    ]
    const majorApi = useMajorApi();
    const crudApi = {
        create: majorApi.create,
        update: majorApi.update,
        search: majorApi.get,
        delete: majorApi.del
    }
    const searchBarItems = []
    const formItems = [
        <Form.Item
            key={1}
            label='Mã chuyên ngành'
            name='majorCode'
            rules={[{ required: true, message: 'Vui lòng nhập mã chuyên ngành' }]}>
            <Input />
        </Form.Item>,
        <Form.Item
            key={2}
            label='Tên chuyên ngành'
            name='majorName'
            rules={[{ required: true, message: 'Vui lòng nhập tên chuyên ngành' }]}>
            <Input />
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
export default Major