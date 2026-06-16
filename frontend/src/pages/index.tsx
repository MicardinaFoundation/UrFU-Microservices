import ErrorHandler from '@/components/ErrorHandler';
import FormVariantEditor from '@/components/FormVariantEditor';
import ModalViewExport from '@/components/ModalViewExport';
import { BoilerCalculationResponse } from '@/constants/typing';
import { CalculationReport } from '@/services/CalculationReport';
import { PDFDownloadLink } from '@react-pdf/renderer';
import { Access, useAccess, history, useModel, request } from '@umijs/max';
import { Button, Form, Input, message, Modal, Space } from "antd";
import React, { useEffect } from 'react';
import { useState } from 'react';

// const access = useAccess();

export default function HomePage() {
  //const [data, setData] = React.useState<BoilerCalculationResponse>();
  const { data, setData, setDataVal } = useModel('variantModel');
  const { isModalViewOpen, setIsModalViewOpen, setShowSaveButton } = useModel('variantViewModel');
  
  useEffect(() => {
    setShowSaveButton(true);
  }, [])

  const loadVariants = (values: any) => {
    console.log(values);
    setDataVal(values);
    request('/api/Calculator/Solve', { method: 'POST', data: values }).then((data: BoilerCalculationResponse) => {

      setData(data);
      console.log(data);
      setIsModalViewOpen(true);
    }).catch((resp: any) => {
      // if (resp.response.status == 401) {
      //   localStorage.removeItem("token");
      //   localStorage.removeItem("userName");
      //   //console.log('redf');
      //   refresh();
      // }
      message.error(ErrorHandler(resp.response.status))
    })

  }



  const join = () => {
    history.push('/join');
  };
  const exportedPDF = () => {
    history.push('/PDFExport');
  };

  return (

    <>
      {/* <Access accessible={!access.isAuth}>
        <Space>
          <span>User is not authorization</span>
          <Button onClick={join}>Join</Button>
        </Space>

      </Access>
      <Access accessible={access.isAuth}>

      </Access> */}
      <Form layout="vertical" onFinish={loadVariants}>
        <FormVariantEditor />
        <Form.Item>
          <Button type="primary" htmlType="submit">Войти</Button>
        </Form.Item>
      </Form>

      <ModalViewExport data={data} advInform={false}  />
    </>
  )
};
