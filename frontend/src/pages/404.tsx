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

export default function NoPage() {

  return (

    <>
    <div style={{fontSize: 64, fontWeight: 700}}>404</div>
      <h2>Oooops :c</h2>
      <p><b>{`${window.location.pathname}${window.location.search}${window.location.hash}`}</b>???<br/>Такой страницы никогда не существовало.</p>
    </>
  )
};
