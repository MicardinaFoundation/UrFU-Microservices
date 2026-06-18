import React, { useEffect } from 'react';
import { Button, Select, Space } from 'antd';
//import avatar from '../assets/avatar.png';
import { Access, useAccess, history, useModel } from '@umijs/max';
import VariantAdd from '@/components/variant/VariantAdd';
import VariantEdit from '@/components/variant/VariantEdit';
import VariantTable from '@/components/variant/VariantTable';
import VariantSearchForm from '@/components/variant/VariantSearchForm';
import ModalViewExport from '@/components/ModalViewExport';

const DocsPage = () => {
  const { data, setData } = useModel('variantModel');
  const { isModalCreateOpen, setIsModalCreateOpen, handleVariantAdd, handleCreateCancel } = useModel('variantAddModel');
  const { refresh } = useModel('@@initialState');
  const { isModalViewOpen, setIsModalViewOpen, showSaveButton, setShowSaveButton } = useModel('variantViewModel');
  

  useEffect(() => {
    //loadVariants();
    setShowSaveButton(false);
  }, [])

  const access = useAccess();

  const join = () => {
    history.push('/join');
  };
  return (
    <div>
      <Access accessible={!access.isAuth}>
        <Space>
          <span>Необходимо авторизоваться для просмотра сохранёных пользователем данных</span>
          <Button onClick={join}>Join</Button>
        </Space>

      </Access>
      <Access accessible={access.isAuth}>
        <h2>Котёл-утилизатор: Просмотр данных</h2>
        <VariantTable />


        <ModalViewExport data={data} advInform={false} />
        <VariantEdit />
        <VariantAdd />
      </Access>

    </div>
  );
};

export default DocsPage;
