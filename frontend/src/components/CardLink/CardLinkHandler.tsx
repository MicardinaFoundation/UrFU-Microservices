import { Link, request, useModel } from "@umijs/max";
import { Button, Divider, Form, Input, message, Modal, Popconfirm, Space, Table, TableProps } from "antd";
import { Column, Pie } from "@ant-design/charts";
import * as XLSX from 'xlsx';
import { useEffect, useState } from "react";
import { UserOutlined, LockOutlined, MailOutlined, SaveOutlined } from '@ant-design/icons';
import React from "react";
import { BoilerCalculationResponse } from "@/constants/typing";
import { PDFDownloadLink } from "@react-pdf/renderer";
import { CalculationReport } from "@/services/CalculationReport";
import './homePage.css';
import NoDataImg from '@/assets/noData.png';


type CardInform = { url?: string, caption?: string, description?: string, imgLink?: string }

export default function (props: CardInform) {

  return (
    <>
      <Link className='class-block' to={props.url ?? "/404"}>
        <div className='gcover-place'>
          <img src={props.imgLink ?? NoDataImg} alt="" />
        </div>
        <div className='text-place'>
          <h3 className='title'>{props.caption ?? "Неизвестно"}</h3>
          <p className='description'>{props.description}</p>
        </div>
      </Link>

    </>
  );
}