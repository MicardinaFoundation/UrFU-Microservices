import ErrorHandler from "@/components/ErrorHandler";
import { BoilerCalculationResponse } from "@/constants/typing";
import { request, useModel } from "@umijs/max";
import { Form, message } from "antd";
import React from "react";

// src/models/user.ts
export default () => {
  const [data, setData] = React.useState<BoilerCalculationResponse>();
  const [dataVal, setDataVal] = React.useState([]);
  const { refresh } = useModel('@@initialState');
  

    const saveVariants = (name: string, description: string) => {
        const val = {
            "name": name,
            "desc": description,
            "userid": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
            "modela": dataVal
        }
        
        console.log(val);
        request('/api/Calculator/Save', { method: 'POST', data: val }).then((data: any) => {
        console.log(data);
  
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
    const editVariants = (name: string, description: string) => {
        const val = {
            "name": name,
            "desc": description,
            "userid": parseInt(localStorage.getItem('TAD3E7S%vCgk')!),
            "modela": dataVal
        }
        
        console.log(val);
        request('/api/Calculator/Edit', { method: 'PATCH', data: val }).then((data: any) => {
        console.log(data);
  
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

  

  return { data, setData, saveVariants, editVariants, dataVal, setDataVal};
};