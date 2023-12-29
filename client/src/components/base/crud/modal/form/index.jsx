import { Form } from "antd"
import { useCRUDContext } from "../../../../../hooks/context/crud-context"



const CRUDForm = () => {

    const context = useCRUDContext();
    return <Form
        form={context.form.instance}
        layout="vertical"
    >
        {context.form.items}
    </Form>
}
export default CRUDForm