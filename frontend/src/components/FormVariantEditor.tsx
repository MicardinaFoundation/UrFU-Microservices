import { useModel } from "@umijs/max";
import { Button, Form, Input, Select } from "antd";

export default function (props: any) {
  //const { options, setOptions } = useModel('variantCathModel');
  const { Option } = Select;
  return (
    <>
      <Form.Item
        label="Углекислый газ, %"
        name="co2"
        initialValue={10}
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number"/>
      </Form.Item>

      <Form.Item
        label="Вода (H₂O), %"
        name="h2o"
        initialValue={15}
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Азот (N₂), %"
        name="n2"
        initialValue={70}
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Кислород (O₂), %"
        
        name="o2"
        initialValue={5}
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Расход газа, м³/ч"
        initialValue={40000}
        name="gaz_used"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Давление подаваемого пара, бар"
        initialValue={1.8}
        name="presure_putten_par"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура питательной воды, °C"
        initialValue={100}
        name="temperature_eaten_water"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура уходящих газов, °C"
        initialValue={375}
        name="temperature_arrive_smoke"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура входящих газов, °C"
        initialValue={0}
        name="temperature_of_incoming_gases"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поправка на число рядов труб"
        initialValue={0}
        name="popravka_na_chair_radov_pipes"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Продольный шаг труб, м"
        initialValue={0}
        name="longitudinal_pitch_of_pipes"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Количество рядов труб"
        initialValue={0}
        name="number_of_pipe_rows"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Доля всасываемого воздуха"
        initialValue={0.1}
        name="proportion_of_intake_air"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Термическое сопротивление отложений на трубах, м²·К/Вт"
        initialValue={0}
        name="thermal_resistance_of_deposits_on_pipes"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Коэффициент излучения абсолютно чёрного тела, Вт/(м²·К⁴)"
        initialValue={5.67}
        name="the_emission_coefficient_of_a_completely_black_body"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Степень черноты стенок трубного пучка"
        initialValue={0.8}
        name="the_degree_of_blackness_of_the_walls_of_the_tube_package"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Коэффициент сохранения тепла"
        initialValue={0.9}
        name="heat_preservation_coefficient"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Число продувок"
        initialValue={10}
        name="purge_n"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на входе, °C"
        initialValue={0}
        name="temperature_of_the_the_heated_medium_at_The_inlet"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на выходе, °C"
        initialValue={0}
        name="temperature_of_the_the_heated_medium_at_The_outlet"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура входящих газов (этап 1), °C"
        initialValue={800}
        name="temperature_of_incoming_gases_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поправка на число рядов труб (этап 1)"
        initialValue={0.98}
        name="popravka_na_chair_radov_pipes_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура выходящих газов (этап 1), °C"
        initialValue={704}
        name="temperature_of_outcoming_gases_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Площадь поперечного сечения для прохода продуктов сгорания (этап 1), м²"
        initialValue={4.32}
        name="cross_sectional_area_for_passage_of_combustion_products_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Расчётная площадь поверхности нагрева (этап 1), м²"
        initialValue={30}
        name="estimated_heating_surface_area_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Диаметр трубы (этап 1), м"
        initialValue={0.032}
        name="pipe_diametr_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поперечный шаг трубы (этап 1), м"
        initialValue={0.172}
        name="transverse_pitch_of_pipe_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Продольный шаг труб (этап 1), м"
        initialValue={0.07}
        name="longitudinal_pitch_of_pipes_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Количество рядов труб (этап 1)"
        initialValue={12}
        name="number_of_pipe_rows_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на входе (этап 1), °C"
        initialValue={206}
        name="temperature_of_the_the_heated_medium_at_The_inlet_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на выходе (этап 1), °C"
        initialValue={206}
        name="temperature_of_the_the_heated_medium_at_The_outlet_1"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поправка на число рядов труб (этап 2)"
        initialValue={0.95}
        name="popravka_na_chair_radov_pipes_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура выходящих газов (этап 2), °C"
        initialValue={628}
        name="temperature_of_outcoming_gases_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Площадь поперечного сечения для прохода продуктов сгорания (этап 2), м²"
        initialValue={3.17}
        name="cross_sectional_area_for_passage_of_combustion_products_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Расчётная площадь поверхности нагрева (этап 2), м²"
        initialValue={43.5}
        name="estimated_heating_surface_area_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Диаметр трубы (этап 2), м"
        initialValue={0.032}
        name="pipe_diametr_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поперечный шаг трубы (этап 2), м"
        initialValue={0.086}
        name="transverse_pitch_of_pipe_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Продольный шаг труб (этап 2), м"
        initialValue={0.07}
        name="longitudinal_pitch_of_pipes_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Количество рядов труб (этап 2)"
        initialValue={8}
        name="number_of_pipe_rows_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на входе (этап 2), °C"
        initialValue={206}
        name="temperature_of_the_the_heated_medium_at_The_inlet_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на выходе (этап 2), °C"
        initialValue={375}
        name="temperature_of_the_the_heated_medium_at_The_outlet_2"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поправка на число рядов труб (этап 3)"
        initialValue={1}
        name="popravka_na_chair_radov_pipes_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура выходящих газов (этап 3), °C"
        initialValue={310.6}
        name="temperature_of_outcoming_gases_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Площадь поперечного сечения для прохода продуктов сгорания (этап 3), м²"
        initialValue={9.51}
        name="cross_sectional_area_for_passage_of_combustion_products_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Расчётная площадь поверхности нагрева (этап 3), м²"
        initialValue={432}
        name="estimated_heating_surface_area_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Диаметр трубы (этап 3), м"
        initialValue={0.032}
        name="pipe_diametr_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поперечный шаг трубы (этап 3), м"
        initialValue={0.086}
        name="transverse_pitch_of_pipe_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Продольный шаг труб (этап 3), м"
        initialValue={0.07}
        name="longitudinal_pitch_of_pipes_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Количество рядов труб (этап 3)"
        initialValue={22}
        name="number_of_pipe_rows_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на входе (этап 3), °C"
        initialValue={206}
        name="temperature_of_the_the_heated_medium_at_The_inlet_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на выходе (этап 3), °C"
        initialValue={206}
        name="temperature_of_the_the_heated_medium_at_The_outlet_3"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поправка на число рядов труб (этап 4)"
        initialValue={0.99}
        name="popravka_na_chair_radov_pipes_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура выходящих газов (этап 4), °C"
        initialValue={231}
        name="temperature_of_outcoming_gases_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Площадь поперечного сечения для прохода продуктов сгорания (этап 4), м²"
        initialValue={3.18}
        name="cross_sectional_area_for_passage_of_combustion_products_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Расчётная площадь поверхности нагрева (этап 4), м²"
        initialValue={185}
        name="estimated_heating_surface_area_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Диаметр трубы (этап 4), м"
        initialValue={0.032}
        name="pipe_diametr_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Поперечный шаг труб S1 (этап 4), м"
        initialValue={0.09}
        name="transverse_pitch_of_pipe_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Продольный шаг труб S2 (этап 4), м"
        initialValue={0.07}
        name="longitudinal_pitch_of_pipes_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Диаметр трубы (этап 4), м"
        initialValue={20}
        name="number_of_pipe_rows_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на входе"
        initialValue={100}
        name="temperature_of_the_the_heated_medium_at_The_inlet_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

      <Form.Item
        label="Температура нагреваемой среды на выходе"
        initialValue={206}
        name="temperature_of_the_the_heated_medium_at_The_outlet_4"
        rules={[{ required: false, message: "Введите значение" }]}
      >
        <Input placeholder="Введите значение" type="number" />
      </Form.Item>

    </>
  );
}