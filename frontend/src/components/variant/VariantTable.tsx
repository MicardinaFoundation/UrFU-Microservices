import { request, useModel } from "@umijs/max";
import { Button, message, Popconfirm, Space, Table, TableProps } from "antd";
import ErrorHandler from "../ErrorHandler";
import { Column, Pie } from "@ant-design/charts";
import * as XLSX from 'xlsx';
import { useEffect } from "react";
import React from "react";
import { BoilerCalculationResponse } from "@/constants/typing";

export default function (props: any) {
    const { data, setData } = useModel('variantModel');
    const { isModalCreateOpen, setIsModalCreateOpen, handleVariantAdd, handleCreateCancel } = useModel('variantAddModel');
    //const { options, setOptions } = useModel('variantCathModel');
    const [dataList, setDataList] = React.useState([]);
    const { refresh } = useModel('@@initialState');

      useEffect(() => {
        refresh();
        loadVariant(parseInt(localStorage.getItem("TAD3E7S%vCgk")?? "0"));
      }, [])
    

    const { isModalEditOpen, setIsModalEditOpen, handleStudentEditStart, handleStudentEdit, handleEditCancel } = useModel('variantEditModel');
    const { form } = useModel('formModel');
      const { isModalViewOpen, setIsModalViewOpen, showSaveButton, setShowSaveButton, handleStudentSolveView } = useModel('variantViewModel');
    

    const convData = data;
    //console.log(data)
    // convData.forEach((el) => {
    //     if (parseInt(el.groupId) < options.length) el.groupId = options[parseInt(el.groupId)].cathegories;
    //     else {
    //         if (parseInt(el.groupId) < options.length)
    //             el.groupId = `<NULL GROUP FOR THIS ID> | <ID = ${el.groupId}> <${el.name}>`
    //     }
    // })


    const studentColumns: TableProps<any>['columns'] = [
        {
            title: 'Название',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Описание',
            dataIndex: 'desc',
            key: 'desc',
        },
        {
            title: 'CO₂ %',
            dataIndex: 'co2',
            key: 'co2',
        },
        {
            title: 'H₂O %',
            dataIndex: 'h2o',
            key: 'h2o',
        },
        {
            title: 'N₂ %',
            dataIndex: 'n2',
            key: 'n2',
        },
        {
            title: 'O₂ %',
            dataIndex: 'o2',
            key: 'o2',
        },
        {
            title: 'Газ исп',
            dataIndex: 'gaz_used',
            key: 'gaz_used',
        },
        {
            title: 'Давление пара',
            dataIndex: 'presure_putten_par',
            key: 'presure_putten_par',
        },
        {
            title: 't питат воды',
            dataIndex: 'temperature_eaten_water',
            key: 'temperature_eaten_water',
        },
        {
            title: 't пара',
            dataIndex: 'temperature_arrive_smoke',
            key: 'temperature_arrive_smoke',
        },
        {
            title: 'Действия',
            key: 'action',
            render: (_, record) => <><Space orientation="vertical">
                <a onClick={() => handleStudentEditStart(record.variantId)}>Изменить</a>
                <a onClick={() => handleStudentSolveView(record.variantId)}>Просмотр</a>
                <a onClick={() => handleDiplicate(record.variantId)}>Дублировать</a>
                <Popconfirm
                    title="Удалить эту запись?"
                    okText="Yes"
                    cancelText="No"
                    onConfirm={() => handleRemove(record.variantId)}
                >
                    <a>Удалить</a>
                </Popconfirm>
            </Space>
            </>
        }
    ]



    function handleRemove (values: number) {
            const val = {
                "userId": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
                "variantId": values
            }
            request(`/api/Calculator`, { method: 'DELETE', data: val }).then((newRow: any) => {
                refresh();
            }).catch((resp: any) => {
                console.log(resp);
                message.error(ErrorHandler(resp.response.status))
            })
    }






    function loadVariant (id: number){
        request(`/api/Calculator/LoadListVariant${id}`, { method: 'POST', data: id }).then((datas: any) => {
            setDataList(datas)
            console.log(data)
        }).catch((resp: any) => {
            message.error(ErrorHandler(resp.response.status))
        })
    }

        const handleDiplicate = (values: number) => {
            const val = {
                "userId": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
                "variantId": values
            }
            request(`/api/Calculator/DuplicateVariant`, { method: 'POST', data: val }).then((newRow: any) => {
                refresh();
            }).catch((resp: any) => {
                console.log(resp);
                message.error(ErrorHandler(resp.response.status))
            })
    
    
        }
    

    // const handleDiplicate = (id: number) => {
    //     request(`/api/Calculator/DiplicateVariant${id}`, { method: 'PUT', data: id }).then((data: any) => {
    //         loadVariants();
    //         console.log(data)
    //     }).catch((resp: any) => {
    //         message.error(ErrorHandler(resp.response.status) + `. /api/Calculator/DiplicateVariant${id}`)
    //     })
    // }

    return (
        <>
            <Table dataSource={dataList.value} columns={studentColumns} />;
        </>
    );
}