import ErrorHandler from "@/components/ErrorHandler";
import { request, useModel } from "@umijs/max";
import { message } from "antd";
import { useState } from "react";

export default () => {
    //const [options, setOptions] = useState<Category[]>(cathegoriesSource);
    //const [options, setOptions] = useState<Category[]>([]);
    const [isModalViewOpen, setIsModalViewOpen] = useState(false);
    const [showSaveButton, setShowSaveButton] = useState(true);
    const { data, setData, setDataVal } = useModel('variantModel');
    const { form } = useModel('formModel');
    const handleStudentView = (values: number) => {
        const val = {
            "userId": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
            "variantId": values
        }
        request(`/api/Calculator/LoadVariant`, { method: 'POST', data: val }).then((newRow: any) => {
            console.log(newRow.value);
            setData(newRow.value)
            setIsModalViewOpen(true);
            //loadVariants();
        }).catch((resp: any) => {
            console.log(resp);
            message.error(ErrorHandler(resp.response.status))
        })


    }
    const handleStudentSolveView = (values: number) => {
        const val = {
            "userId": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
            "variantId": values
        }
        request(`/api/Calculator/LoadSolveVariant`, { method: 'POST', data: val }).then((newRow: any) => {
            console.log(newRow.value);
            setData(newRow.value)
            setIsModalViewOpen(true);
            //loadVariants();
        }).catch((resp: any) => {
            console.log(resp);
            message.error(ErrorHandler(resp.response.status))
        })


    }


    return { isModalViewOpen, setIsModalViewOpen, showSaveButton, setShowSaveButton, handleStudentView, handleStudentSolveView };
};