import { Button, Form, Input, Modal, Select } from "antd";
import FormVariantEditor from "../FormVariantEditor";
import { useModel } from "@umijs/max";

export default function (props: any) {

  const { isModalEditOpen, setIsModalEditOpen, handleStudentEditStart, handleStudentEdit, handleEditCancel } = useModel('variantEditModel');
  //const { options, setOptions } = useModel('variantCathModel');
  const { formEdit } = useModel('formModel');
  const { data, setData } = useModel('variantModel');

  return (
    <>
      <Modal
        title="Edit students"
        closable={{ 'aria-label': 'Custom Close Button' }}
        open={isModalEditOpen}
        onCancel={(handleEditCancel)}
        footer={null}
      >
        <Form
          form={formEdit}
          layout="vertical"
          onFinish={handleStudentEdit}
        // initialValues={data?.result}
        >
          <Form.Item name="variantId" hidden >
            <Input />
          </Form.Item>
          <Form.Item name='name' label='name' >
            <Input placeholder="Назвать" />
          </Form.Item>
          <Form.Item name='desc' label='desc'>
            <Input placeholder="Описать" />
          </Form.Item>

          <FormVariantEditor />
          <Form.Item>
            <Button type="primary" htmlType="submit">
              Саве
            </Button>
          </Form.Item>

        </Form>
      </Modal>



    </>
  );
}