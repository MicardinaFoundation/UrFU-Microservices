import ErrorHandler from "@/components/ErrorHandler";
import { request, useModel } from "@umijs/max";
import { message } from "antd";
import { useState } from "react";

export default () => {
    //const [data, setData] = React.useState<Variant[]>(studentDataSource);
    const [isModalEditOpen, setIsModalEditOpen] = useState(false);

    const { data, setData, dataVal } = useModel('variantModel');
    const { formEdit } = useModel('formModel');


    const handleStudentEditStart = (values: number) => {
        const val = {
            "userId": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
            "variantId": values
        }
        request(`/api/Calculator/LoadVariant`, { method: 'POST', data: val }).then((newRow: any) => {
            //setData(newRow.value)
            formEdit.setFieldsValue(newRow.value.result)
            //console.log(newRow.value);
            setIsModalEditOpen(true);
            //loadVariants();
        }).catch((resp: any) => {
            console.log(resp);
            message.error(ErrorHandler(resp.response.status))
        })


    }

    const handleStudentEdit = (values: any) => {
        const val = {
            "name": values.name,
            "desc": values.desc,
            "variantid": values.variantId,
            "userid": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
            "modela": values
        }
        console.log(val);
        request(`/api/Calculator/Edit`, { method: 'PATCH', data: val }).then((newRow: any) => {
            console.log(newRow);
        }).catch((resp: any) => {
            message.error(ErrorHandler(resp.response.status))
        }).finally(() => {
            formEdit.resetFields();
            setIsModalEditOpen(false);
        })


    }

    // const editVariants = (name: string, description: string) => {
    //     const val = {
    //         "name": name,
    //         "desc": description,
    //         "userid": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
    //         "modela": dataVal
    //     }

    //     console.log(val);
    //     request('/api/Calculator/Edit', { method: 'PATCH', data: val }).then((data: any) => {
    //         console.log(data);

    //     }).catch((resp: any) => {
    //         // if (resp.response.status == 401) {
    //         //   localStorage.removeItem("token");
    //         //   localStorage.removeItem("userName");
    //         //   //console.log('redf');
    //         //   refresh();
    //         // }
    //         message.error(ErrorHandler(resp.response.status))
    //     }).finally(() => {
    //         formEdit.resetFields();
    //         setIsModalEditOpen(false);

    //     })

    // }


    const handleEditCancel = () => {
        setIsModalEditOpen(false);
        formEdit.resetFields();
    };


    return { isModalEditOpen, setIsModalEditOpen, handleStudentEditStart, handleStudentEdit, handleEditCancel };
};