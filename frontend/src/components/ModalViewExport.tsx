import { request, useModel } from "@umijs/max";
import { Button, Divider, Form, Input, message, Modal, Popconfirm, Space, Table, TableProps } from "antd";
import { Column, Pie } from "@ant-design/charts";
import * as XLSX from 'xlsx';
import { useEffect, useState } from "react";
import { UserOutlined, LockOutlined, MailOutlined, SaveOutlined } from '@ant-design/icons';
import React from "react";
import { BoilerCalculationResponse } from "@/constants/typing";
import { PDFDownloadLink } from "@react-pdf/renderer";
import { CalculationReport } from "@/services/CalculationReport";

type Props = { data?: BoilerCalculationResponse, advInform: boolean }

export default function (props: Props) {
    const { data, setData, saveVariants } = useModel('variantModel');
    //const { isModalEditOpen, setIsModalEditOpen, handleStudentEditStart, handleStudentEdit, handleEditCancel } = useModel('variantEditModel');
    const { isModalViewOpen, setIsModalViewOpen, showSaveButton } = useModel('variantViewModel');

    //const { options, setOptions } = useModel('variantCathModel');
    //const { form } = useModel('formModel');
    const saveState: boolean = true;
    const handleViewCancel = () => {
        setIsModalViewOpen(false);
        //form.resetFields();
    }

    const saveVariant = (event) => {
        console.log(event.name);
        //saveVariants(parseInt(localStorage.getItem("TAD3E7S%vCgk")!))
        saveVariants(event.name, event.desc)
    }

    return (
        <>
            <Modal
                title="Предпросмотр вывода"
                closable={{ 'aria-label': 'Custom Close Button' }}
                open={isModalViewOpen}
                onCancel={handleViewCancel}
                footer={[
                    <Space>
                        {showSaveButton && (
                            <>
                                <Form layout='inline' onFinish={saveVariant}>
                                    <Form.Item name='name' label='' >
                                        <Input style={{ width: 100 }} placeholder="Назвать" />
                                    </Form.Item>
                                    <Form.Item name='desc' label=''>
                                        <Input style={{ width: 125 }} placeholder="Описать" />
                                    </Form.Item>


                                    <Form.Item>
                                        <Button type="primary" htmlType="submit" title="Сохранить в базу данных для дальнейших расчётов">
                                            <SaveOutlined />
                                        </Button>
                                    </Form.Item>

                                </Form>
                                <Divider orientation="vertical" />
                            </>
                        )}


                        <Button key="back" onClick={handleViewCancel}>
                            Закрыть
                        </Button>

                    </Space>
                ]}
            >
                <table>
                    <thead>
                        <tr>
                            <th>Параметр</th>
                            <th>Значение</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Количество теплоты, переданное воде и пару</td>
                            <td>{data?.result.thermal_count_transfered_water_and_steam}</td>
                        </tr>
                        <tr>
                            <td>Количество тепла, переданное в пароперегревателе</td>
                            <td>{data?.result.thermal_count_transfered_in_paroperegrevatel}</td>
                        </tr>
                        <tr>
                            <td>Энтальпия кипящей воды</td>
                            <td>{data?.result.entalpia_hot_water} кДж/кг</td>
                        </tr>
                        <tr>
                            <td>Энтальпия питательной воды</td>
                            <td>{data?.result.entalpia_eaten_water} кДж/кг</td>
                        </tr>
                        <tr>
                            <td>Энтальпия кипящей воды</td>
                            <td>{data?.result.entalpia_saturated_dry_steam} кДж/кг</td>
                        </tr>
                        <tr>
                            <td>Расчетная энтальпия перегретого пара</td>
                            <td>{data?.result.calculated_entalpia_hotest_steam} кДж/кг</td>
                        </tr>
                        <tr>
                            <td>Теоретическая энтальпия перегретого пара</td>
                            <td>{data?.result.calculated_theoretic_entalpia_hotest_steam} кДж/кг</td>
                        </tr>
                        <tr>
                            <td>Расхождение процентное</td>
                            <td>{data?.result.percentage_discrepancy} %</td>
                        </tr>
                        <tr>
                            <td>Паропроизводительность, кг/с</td>
                            <td>{data?.result.steam_capicity} кг/с</td>
                        </tr>
                    </tbody>
                </table>
                <Space>
                    <PDFDownloadLink
                        document={<CalculationReport data={props?.data} advInform={props.advInform} />}
                        fileName="CalculationResults_Export.pdf"
                        style={{
                            textDecoration: 'none',
                            padding: '4px 14px',
                            color: '#fff',
                            backgroundColor: '#1890ff',
                            borderRadius: '4px',
                            display: 'inline-block',
                        }}
                    >
                        {/* @ts-ignore */}
                        {({ blob, url, loading, error }) =>
                            error ? 'Ошибка!' : loading ? 'Формирование PDF...' : 'Скачать отчет в PDF'
                        }
                    </PDFDownloadLink>


                </Space>

            </Modal>



        </>
    );
}