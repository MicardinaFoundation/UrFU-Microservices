import React from 'react';
import { Document, Page, Text, View, StyleSheet, Font } from '@react-pdf/renderer';
import RobotoRegular from '@/services/fonts/font.ttf';
import RobotoBold from '@/services/fonts/fontbd.ttf';
import { useModel } from '@umijs/max';
import { BoilerCalculationResponse } from '@/constants/typing';

Font.register({
  family: 'Roboto',
  fonts: [
    { src: RobotoRegular, fontWeight: 'normal' },
    { src: RobotoBold, fontWeight: 'bold' },
  ],
});

const styles = StyleSheet.create({
  page: {
    padding: 40,
    fontFamily: 'Roboto',
    fontSize: 10,
    lineHeight: 1.5,
    color: '#333333',
  },
  header: {
    marginBottom: 20,
    borderBottomWidth: 1,
    borderBottomColor: '#1A365D',
    paddingBottom: 10,
  },
  mainTitle: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#1A365D',
    textAlign: 'center',
    marginBottom: 5,
  },
  metaText: {
    fontSize: 9,
    color: '#555555',
    textAlign: 'center',
  },
  sectionTitle: {
    fontSize: 12,
    fontWeight: 'bold',
    color: '#2C5282',
    backgroundColor: '#EBF8FF',
    padding: 5,
    marginTop: 15,
    marginBottom: 8,
  },
  table: {
    display: 'flex',
    flexDirection: 'column',
    borderWidth: 1,
    borderColor: '#CBD5E0',
    marginBottom: 10,
  },
  tableRow: {
    flexDirection: 'row',
    borderBottomWidth: 1,
    borderBottomColor: '#E2E8F0',
    minHeight: 22,
    alignItems: 'center',
  },
  tableRowAlternating: {
    flexDirection: 'row',
    borderBottomWidth: 1,
    borderBottomColor: '#E2E8F0',
    minHeight: 22,
    alignItems: 'center',
    backgroundColor: '#F7FAFC',
  },
  tableHeader: {
    flexDirection: 'row',
    backgroundColor: '#EDF2F7',
    borderBottomWidth: 2,
    borderBottomColor: '#CBD5E0',
    minHeight: 24,
    alignItems: 'center',
  },
  colParam: {
    width: '70%',
    paddingLeft: 8,
    borderRightWidth: 1,
    borderRightColor: '#E2E8F0',
  },
  colValue: {
    width: '30%',
    paddingLeft: 8,
    fontWeight: 'bold',
  },
  colHeaderParam: {
    width: '70%',
    paddingLeft: 8,
    fontWeight: 'bold',
    borderRightWidth: 1,
    borderRightColor: '#CBD5E0',
  },
  colHeaderValue: {
    width: '30%',
    paddingLeft: 8,
    fontWeight: 'bold',
  },
  pageNumber: {
    position: 'absolute',
    fontSize: 9,
    bottom: 20,
    left: 0,
    right: 0,
    textAlign: 'center',
    color: '#A0AEC0',
  },
});

interface DataRow {
  param: string;
  value: string;
}

const ParamTable: React.FC<{ data: DataRow[] }> = ({ data }) => (
  <View style={styles.table}>
    <View style={styles.tableHeader}>
      <Text style={styles.colHeaderParam}>Параметр</Text>
      <Text style={styles.colHeaderValue}>Значение</Text>
    </View>
    {data.map((row, index) => (
      <View
        key={index}
        style={index % 2 === 0 ? styles.tableRow : styles.tableRowAlternating}
      >
        <Text style={styles.colParam}>{row.param}</Text>
        <Text style={styles.colValue}>{row.value}</Text>
      </View>
    ))}
  </View>
);
type Props = { data?: BoilerCalculationResponse, advInform: boolean }

export const CalculationReport: React.FC<Props> = (rs) => {
  console.log(rs);
  
  //const { data } = useModel('variantModel');
  return (
    <Document>

      {/* Start */}
      <Page size="A4" style={styles.page}>
        <View style={styles.header}>
          <Text style={styles.mainTitle}>Расчет конвективного котла-утилизатора</Text>
          <Text style={styles.metaText}>Дата формирования: {new Date().toLocaleDateString()} {new Date().toTimeString()}</Text>
        </View>

        <Text style={styles.sectionTitle}>ИСХОДНЫЕ ДАННЫЕ: ГАЗЫ</Text>
        <ParamTable data={[
          { param: 'Углекислый газ %', value: `${rs.data?.otherVal.co2} %` },
          { param: 'Вода %', value: `${rs.data?.otherVal.h2o} %` },
          { param: 'Азот %', value: `${rs.data?.otherVal.n2} %` },
          { param: 'Кислород %', value: `${rs.data?.otherVal.o2} %` },
          { param: 'Общий %', value: `${rs.data?.otherVal.co2 + rs.data?.otherVal.h2o + rs.data?.otherVal.n2 + rs.data?.otherVal.o2} %` },
        ]} />

        <Text style={styles.sectionTitle}>ИСХОДНЫЕ ДАННЫЕ: ОСНОВНОЕ</Text>
        <ParamTable data={[
          { param: 'Расход газа, м³/ч', value: `${rs.data?.otherVal.gaz_used} м³/ч` },
          { param: 'Давление получаемого пара, МПа', value: `${rs.data?.otherVal.presure_putten_par} МПа` },
          { param: 'Температура питательной воды, °C', value: `${rs.data?.otherVal.temperature_eaten_water} °C` },
          { param: 'Температура получаемого пара, °C', value: `${rs.data?.otherVal.temperature_arrive_smoke} °C` },
        ]} />

        <Text style={styles.sectionTitle}>ИСХОДНЫЕ ДАННЫЕ: ДОПОЛНИТЕЛЬНО</Text>
        <ParamTable data={[
          { param: 'Доля подсасываемого воздуха', value: `${rs.data?.otherVal.proportion_of_intake_air}` },
          { param: 'Термическое сопротивление отложений на трубах', value: `${rs.data?.otherVal.thermal_resistance_of_deposits_on_pipes} °C` },
          { param: 'Коэффициент излучения абсолютно черного тела', value: `${rs.data?.otherVal.the_emission_coefficient_of_a_completely_black_body} (м²*K)/Вт` },
          { param: 'Степень черноты стенок трубного пакета', value: `${rs.data?.otherVal.the_degree_of_blackness_of_the_walls_of_the_tube_package} ` },
          { param: 'Коэффициент сохранения тепла', value: `${rs.data?.otherVal.heat_preservation_coefficient} ` },
          { param: 'Продувка n, %', value: `${rs.data?.otherVal.purge_n} %` },
        ]} />


        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page>

        {/* PIP */}
      <Page size="A4" style={styles.page}>
        <Text style={styles.sectionTitle}>Секция ПИП - Исходные данные</Text>
        <ParamTable data={[
          { param: 'Температура входящих газов', value: `${rs.data?.value[0].inputVal.temperature_of_incoming_gases} °C` },
          { param: 'Поправка на число рядов труб Cz', value: `${rs.data?.value[0].inputVal.popravka_na_chair_radov_pipes}` },
          { param: 'Температура отходящих газов', value: `${rs.data?.value[0].inputVal.temperature_of_outcoming_gases} °C` },
          { param: 'Площадь сечения для прохода продуктов сгорания', value: `${rs.data?.value[0].inputVal.cross_sectional_area_for_passage_of_combustion_products} м²` },
          { param: 'Расчетная площадь поверхности нагрева', value: `${rs.data?.value[0].inputVal.estimated_heating_surface_area} м²` },
          { param: 'Диаметр труб', value: `${rs.data?.value[0].inputVal.pipe_diametr} м` },
          { param: 'Поперечный шаг труб S1', value: `${rs.data?.value[0].inputVal.transverse_pitch_of_pipe} м` },
          { param: 'Продольный шаг труб S2', value: `${rs.data?.value[0].inputVal.longitudinal_pitch_of_pipes} м` },
          { param: 'Количество рядов труб по ходу продуктов сгорания', value: `${rs.data?.value[0].inputVal.number_of_pipe_rows} шт` },
          { param: 'Температура нагреваемой среды на входе', value: `${rs.data?.value[0].inputVal.temperature_of_the_the_heated_medium_at_The_inlet} °C` },
          { param: 'Температура нагреваемой среды на выходе', value: `${rs.data?.value[0].inputVal.temperature_of_the_the_heated_medium_at_The_outlet} °C` },
        ]} />
        <Text style={styles.sectionTitle}>Секция ПИП - Расчётные данные</Text>
        <ParamTable data={[
          { param: 'Средняя тепмература в секции', value: `${rs.data?.value[0].outputCodeVal.aver_temperature_section} °C` },
          { param: 'Число Прандтля', value: `${rs.data?.value[0].outputCodeVal.prandle_number}` },
          { param: 'Коеффициент теплопроводности', value: `${rs.data?.value[0].outputCodeVal.coef_of_thermal_conductivity} Вт/(м*К)` },
          { param: 'Коеффициент кинематической вязкости', value: `${rs.data?.value[0].outputCodeVal.coef_of_kinematic_viscosity} м²/с` },
          { param: 'Расход газа при н.у', value: `${rs.data?.value[0].outputCodeVal.gaz_used_n_u} м³/с` },
          { param: 'Расход газа с учетом подсоса', value: `${rs.data?.value[0].outputCodeVal.gaz_used_podsos} м³/с` },
          { param: 'Действительный расход дымовых газов', value: `${rs.data?.value[0].outputCodeVal.actual_flue_gas_consumption} м³/с` },
          { param: 'Диагональный шаг труб', value: `${rs.data?.value[0].outputCodeVal.aver_smok_gaz_speed}` },
          { param: 'Параметр p', value: `${rs.data?.value[0].outputCodeVal.p_parametr}` },
          { param: 'Конвективный коэффициент теплопередачи', value: `${rs.data?.value[0].outputCodeVal.convective_coef_thermosender} Вт/(м²*К)` },
          { param: 'Параметр ps', value: `${rs.data?.value[0].outputCodeVal.ps_parametr}` },
          { param: 'Парциональное давление H₂O', value: `${rs.data?.value[0].outputCodeVal.parti_presure_h2o} бар` },
          { param: 'Парциональное давление CO₂', value: `${rs.data?.value[0].outputCodeVal.parti_presure_co2} бар` },
          { param: 'Эффективная толщина излучающего слоя Sэф', value: `${rs.data?.value[0].outputCodeVal.effective_thickness_emission_layer} м` },
          { param: 'Температура наружной поверхности стенки Tст', value: `${rs.data?.value[0].outputCodeVal.temperature_outside_cover} K` },
          { param: 'Средняя температура дымовых газов Tср', value: `${rs.data?.value[0].outputCodeVal.aver_temperature_smoke_gaz} K` },
          { param: 'Спектральный коэффициент ослабления K1', value: `${rs.data?.value[0].outputCodeVal.spektr_coeff_lower1}` },
          { param: 'Спектральный коэффициент ослабления K2', value: `${rs.data?.value[0].outputCodeVal.spektr_coeff_lower2}` },
          { param: 'Степень черноты дымовых газов εд', value: `${rs.data?.value[0].outputCodeVal.degree_blackness_smokness_gazez}` },
          { param: 'Коэффициент поглощаения αд', value: `${rs.data?.value[0].outputCodeVal.absorption_coeff}` },
          { param: 'Cпр', value: `${rs.data?.value[0].outputCodeVal.c_pr}` },
          { param: 'Коэффициент теплоотдачи излучением, αдл', value: `${rs.data?.value[0].outputCodeVal.coeff_heat_transfer_by_emmision} Вт/(м²*К)` },
          { param: 'Суммарный коэффициент теплоотдачи от продуктов, αд', value: `${rs.data?.value[0].outputCodeVal.total_heat_coeff_from_products} Вт/(м²*К)` },
          { param: 'Разность температур начальная, ∆tн', value: `${rs.data?.value[0].outputCodeVal.initial_temperature_difference} °C` },
          { param: 'Разность температур конечная, ∆tк', value: `${rs.data?.value[0].outputCodeVal.finitial_temperature_difference} °C` },
          { param: 'Коэффициент теплоотдачи к нагреваемой среде и обратный', value: `${rs.data?.value[0].outputCodeVal.coeff_thermal_transfer_heating_env}` },
          { param: 'Коэффициент теплопередачи, k', value: `${rs.data?.value[0].outputCodeVal.coeff_heat_transfer} Вт/(м²*К)` },
          { param: 'Среднелогарифмическая разность температур', value: `${rs.data?.value[0].outputCodeVal.averlogarifmic_thermal_difference} °C` },
          { param: 'Количество тепла, переданное газами', value: `${rs.data?.value[0].outputCodeVal.thermal_total_gazes_transfer} кВт` },
          { param: 'Теоретическая энтальпия входящих газов', value: `${rs.data?.value[0].outputCodeVal.incoming_entalpia_gazes} кДж/м³` },
          { param: 'Теоретическая энтальпия выходящих газов', value: `${rs.data?.value[0].outputCodeVal.outcoming_entalpia_gazes} кДж/м³` },
          { param: 'Расчетная энтальпия iд', value: `${rs.data?.value[0].outputCodeVal.calculated_entalpia_from_thermal_total} кДж/м³` },
        ]} />

        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page>

      {/* Paroperegrevatel */}
      <Page size="A4" style={styles.page}>
        <Text style={styles.sectionTitle}>Секция Пароперегреватель - Исходные данные</Text>
        <ParamTable data={[
          { param: 'Температура входящих газов', value: `${rs.data?.value[1].inputVal.temperature_of_incoming_gases} °C` },
          { param: 'Поправка на число рядов труб Cz', value: `${rs.data?.value[1].inputVal.popravka_na_chair_radov_pipes}` },
          { param: 'Температура отходящих газов', value: `${rs.data?.value[1].inputVal.temperature_of_outcoming_gases} °C` },
          { param: 'Площадь сечения для прохода продуктов сгорания', value: `${rs.data?.value[1].inputVal.cross_sectional_area_for_passage_of_combustion_products} м²` },
          { param: 'Расчетная площадь поверхности нагрева', value: `${rs.data?.value[1].inputVal.estimated_heating_surface_area} м²` },
          { param: 'Диаметр труб', value: `${rs.data?.value[1].inputVal.pipe_diametr} м` },
          { param: 'Поперечный шаг труб S1', value: `${rs.data?.value[1].inputVal.transverse_pitch_of_pipe} м` },
          { param: 'Продольный шаг труб S2', value: `${rs.data?.value[1].inputVal.longitudinal_pitch_of_pipes} м` },
          { param: 'Количество рядов труб по ходу продуктов сгорания', value: `${rs.data?.value[1].inputVal.number_of_pipe_rows} шт` },
          { param: 'Температура нагреваемой среды на входе', value: `${rs.data?.value[1].inputVal.temperature_of_the_the_heated_medium_at_The_inlet} °C` },
          { param: 'Температура нагреваемой среды на выходе', value: `${rs.data?.value[1].inputVal.temperature_of_the_the_heated_medium_at_The_outlet} °C` },
        ]} />
        <Text style={styles.sectionTitle}>Секция Пароперегреватель - Расчётные данные</Text>
        <ParamTable data={[
          { param: 'Средняя тепмература в секции', value: `${rs.data?.value[1].outputCodeVal.aver_temperature_section} °C` },
          { param: 'Число Прандтля', value: `${rs.data?.value[1].outputCodeVal.prandle_number}` },
          { param: 'Коеффициент теплопроводности', value: `${rs.data?.value[1].outputCodeVal.coef_of_thermal_conductivity} Вт/(м*К)` },
          { param: 'Коеффициент кинематической вязкости', value: `${rs.data?.value[1].outputCodeVal.coef_of_kinematic_viscosity} м²/с` },
          { param: 'Расход газа при н.у', value: `${rs.data?.value[1].outputCodeVal.gaz_used_n_u} м³/с` },
          { param: 'Расход газа с учетом подсоса', value: `${rs.data?.value[1].outputCodeVal.gaz_used_podsos} м³/с` },
          { param: 'Действительный расход дымовых газов', value: `${rs.data?.value[1].outputCodeVal.actual_flue_gas_consumption} м³/с` },
          { param: 'Диагональный шаг труб', value: `${rs.data?.value[1].outputCodeVal.aver_smok_gaz_speed}` },
          { param: 'Параметр p', value: `${rs.data?.value[1].outputCodeVal.p_parametr}` },
          { param: 'Конвективный коэффициент теплопередачи', value: `${rs.data?.value[1].outputCodeVal.convective_coef_thermosender} Вт/(м²*К)` },
          { param: 'Параметр ps', value: `${rs.data?.value[1].outputCodeVal.ps_parametr}` },
          { param: 'Парциональное давление H₂O', value: `${rs.data?.value[1].outputCodeVal.parti_presure_h2o} бар` },
          { param: 'Парциональное давление CO₂', value: `${rs.data?.value[1].outputCodeVal.parti_presure_co2} бар` },
          { param: 'Эффективная толщина излучающего слоя Sэф', value: `${rs.data?.value[1].outputCodeVal.effective_thickness_emission_layer} м` },
          { param: 'Температура наружной поверхности стенки Tст', value: `${rs.data?.value[1].outputCodeVal.temperature_outside_cover} K` },
          { param: 'Средняя температура дымовых газов Tср', value: `${rs.data?.value[1].outputCodeVal.aver_temperature_smoke_gaz} K` },
          { param: 'Спектральный коэффициент ослабления K1', value: `${rs.data?.value[1].outputCodeVal.spektr_coeff_lower1}` },
          { param: 'Спектральный коэффициент ослабления K2', value: `${rs.data?.value[1].outputCodeVal.spektr_coeff_lower2}` },
          { param: 'Степень черноты дымовых газов εд', value: `${rs.data?.value[1].outputCodeVal.degree_blackness_smokness_gazez}` },
          { param: 'Коэффициент поглощаения αд', value: `${rs.data?.value[1].outputCodeVal.absorption_coeff}` },
          { param: 'Cпр', value: `${rs.data?.value[1].outputCodeVal.c_pr}` },
          { param: 'Коэффициент теплоотдачи излучением, αдл', value: `${rs.data?.value[1].outputCodeVal.coeff_heat_transfer_by_emmision} Вт/(м²*К)` },
          { param: 'Суммарный коэффициент теплоотдачи от продуктов, αд', value: `${rs.data?.value[1].outputCodeVal.total_heat_coeff_from_products} Вт/(м²*К)` },
          { param: 'Разность температур начальная, ∆tн', value: `${rs.data?.value[1].outputCodeVal.initial_temperature_difference} °C` },
          { param: 'Разность температур конечная, ∆tк', value: `${rs.data?.value[1].outputCodeVal.finitial_temperature_difference} °C` },
          { param: 'Коэффициент теплоотдачи к нагреваемой среде и обратный', value: `${rs.data?.value[1].outputCodeVal.coeff_thermal_transfer_heating_env}` },
          { param: 'Коэффициент теплопередачи, k', value: `${rs.data?.value[1].outputCodeVal.coeff_heat_transfer} Вт/(м²*К)` },
          { param: 'Среднелогарифмическая разность температур', value: `${rs.data?.value[1].outputCodeVal.averlogarifmic_thermal_difference} °C` },
          { param: 'Количество тепла, переданное газами', value: `${rs.data?.value[1].outputCodeVal.thermal_total_gazes_transfer} кВт` },
          { param: 'Теоретическая энтальпия входящих газов', value: `${rs.data?.value[1].outputCodeVal.incoming_entalpia_gazes} кДж/м³` },
          { param: 'Теоретическая энтальпия выходящих газов', value: `${rs.data?.value[1].outputCodeVal.outcoming_entalpia_gazes} кДж/м³` },
          { param: 'Расчетная энтальпия iд', value: `${rs.data?.value[1].outputCodeVal.calculated_entalpia_from_thermal_total} кДж/м³` },
        ]} />

        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page>

      {/* IS */}
      <Page size="A4" style={styles.page}>
        <Text style={styles.sectionTitle}>Секция ИС - Исходные данные</Text>
        <ParamTable data={[
          { param: 'Температура входящих газов', value: `${rs.data?.value[2].inputVal.temperature_of_incoming_gases} °C` },
          { param: 'Поправка на число рядов труб Cz', value: `${rs.data?.value[2].inputVal.popravka_na_chair_radov_pipes}` },
          { param: 'Температура отходящих газов', value: `${rs.data?.value[2].inputVal.temperature_of_outcoming_gases} °C` },
          { param: 'Площадь сечения для прохода продуктов сгорания', value: `${rs.data?.value[2].inputVal.cross_sectional_area_for_passage_of_combustion_products} м²` },
          { param: 'Расчетная площадь поверхности нагрева', value: `${rs.data?.value[2].inputVal.estimated_heating_surface_area} м²` },
          { param: 'Диаметр труб', value: `${rs.data?.value[2].inputVal.pipe_diametr} м` },
          { param: 'Поперечный шаг труб S1', value: `${rs.data?.value[2].inputVal.transverse_pitch_of_pipe} м` },
          { param: 'Продольный шаг труб S2', value: `${rs.data?.value[2].inputVal.longitudinal_pitch_of_pipes} м` },
          { param: 'Количество рядов труб по ходу продуктов сгорания', value: `${rs.data?.value[2].inputVal.number_of_pipe_rows} шт` },
          { param: 'Температура нагреваемой среды на входе', value: `${rs.data?.value[2].inputVal.temperature_of_the_the_heated_medium_at_The_inlet} °C` },
          { param: 'Температура нагреваемой среды на выходе', value: `${rs.data?.value[2].inputVal.temperature_of_the_the_heated_medium_at_The_outlet} °C` },
        ]} />
        <Text style={styles.sectionTitle}>Секция ИС - Расчётные данные</Text>
        <ParamTable data={[
          { param: 'Средняя тепмература в секции', value: `${rs.data?.value[2].outputCodeVal.aver_temperature_section} °C` },
          { param: 'Число Прандтля', value: `${rs.data?.value[2].outputCodeVal.prandle_number}` },
          { param: 'Коеффициент теплопроводности', value: `${rs.data?.value[2].outputCodeVal.coef_of_thermal_conductivity} Вт/(м*К)` },
          { param: 'Коеффициент кинематической вязкости', value: `${rs.data?.value[2].outputCodeVal.coef_of_kinematic_viscosity} м²/с` },
          { param: 'Расход газа при н.у', value: `${rs.data?.value[2].outputCodeVal.gaz_used_n_u} м³/с` },
          { param: 'Расход газа с учетом подсоса', value: `${rs.data?.value[2].outputCodeVal.gaz_used_podsos} м³/с` },
          { param: 'Действительный расход дымовых газов', value: `${rs.data?.value[2].outputCodeVal.actual_flue_gas_consumption} м³/с` },
          { param: 'Диагональный шаг труб', value: `${rs.data?.value[2].outputCodeVal.aver_smok_gaz_speed}` },
          { param: 'Параметр p', value: `${rs.data?.value[2].outputCodeVal.p_parametr}` },
          { param: 'Конвективный коэффициент теплопередачи', value: `${rs.data?.value[2].outputCodeVal.convective_coef_thermosender} Вт/(м²*К)` },
          { param: 'Параметр ps', value: `${rs.data?.value[2].outputCodeVal.ps_parametr}` },
          { param: 'Парциональное давление H₂O', value: `${rs.data?.value[2].outputCodeVal.parti_presure_h2o} бар` },
          { param: 'Парциональное давление CO₂', value: `${rs.data?.value[2].outputCodeVal.parti_presure_co2} бар` },
          { param: 'Эффективная толщина излучающего слоя Sэф', value: `${rs.data?.value[2].outputCodeVal.effective_thickness_emission_layer} м` },
          { param: 'Температура наружной поверхности стенки Tст', value: `${rs.data?.value[2].outputCodeVal.temperature_outside_cover} K` },
          { param: 'Средняя температура дымовых газов Tср', value: `${rs.data?.value[2].outputCodeVal.aver_temperature_smoke_gaz} K` },
          { param: 'Спектральный коэффициент ослабления K1', value: `${rs.data?.value[2].outputCodeVal.spektr_coeff_lower1}` },
          { param: 'Спектральный коэффициент ослабления K2', value: `${rs.data?.value[2].outputCodeVal.spektr_coeff_lower2}` },
          { param: 'Степень черноты дымовых газов εд', value: `${rs.data?.value[2].outputCodeVal.degree_blackness_smokness_gazez}` },
          { param: 'Коэффициент поглощаения αд', value: `${rs.data?.value[2].outputCodeVal.absorption_coeff}` },
          { param: 'Cпр', value: `${rs.data?.value[2].outputCodeVal.c_pr}` },
          { param: 'Коэффициент теплоотдачи излучением, αдл', value: `${rs.data?.value[2].outputCodeVal.coeff_heat_transfer_by_emmision} Вт/(м²*К)` },
          { param: 'Суммарный коэффициент теплоотдачи от продуктов, αд', value: `${rs.data?.value[2].outputCodeVal.total_heat_coeff_from_products} Вт/(м²*К)` },
          { param: 'Разность температур начальная, ∆tн', value: `${rs.data?.value[2].outputCodeVal.initial_temperature_difference} °C` },
          { param: 'Разность температур конечная, ∆tк', value: `${rs.data?.value[2].outputCodeVal.finitial_temperature_difference} °C` },
          { param: 'Коэффициент теплоотдачи к нагреваемой среде и обратный', value: `${rs.data?.value[2].outputCodeVal.coeff_thermal_transfer_heating_env}` },
          { param: 'Коэффициент теплопередачи, k', value: `${rs.data?.value[2].outputCodeVal.coeff_heat_transfer} Вт/(м²*К)` },
          { param: 'Среднелогарифмическая разность температур', value: `${rs.data?.value[2].outputCodeVal.averlogarifmic_thermal_difference} °C` },
          { param: 'Количество тепла, переданное газами', value: `${rs.data?.value[2].outputCodeVal.thermal_total_gazes_transfer} кВт` },
          { param: 'Теоретическая энтальпия входящих газов', value: `${rs.data?.value[2].outputCodeVal.incoming_entalpia_gazes} кДж/м³` },
          { param: 'Теоретическая энтальпия выходящих газов', value: `${rs.data?.value[2].outputCodeVal.outcoming_entalpia_gazes} кДж/м³` },
          { param: 'Расчетная энтальпия iд', value: `${rs.data?.value[2].outputCodeVal.calculated_entalpia_from_thermal_total} кДж/м³` },
        ]} />


        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page>

      {/* Economizer */}
      <Page size="A4" style={styles.page}>
        <Text style={styles.sectionTitle}>Секция Экономайзер - Исходные данные</Text>
        <ParamTable data={[
          { param: 'Температура входящих газов', value: `${rs.data?.value[3].inputVal.temperature_of_incoming_gases} °C` },
          { param: 'Поправка на число рядов труб Cz', value: `${rs.data?.value[3].inputVal.popravka_na_chair_radov_pipes}` },
          { param: 'Температура отходящих газов', value: `${rs.data?.value[3].inputVal.temperature_of_outcoming_gases} °C` },
          { param: 'Площадь сечения для прохода продуктов сгорания', value: `${rs.data?.value[3].inputVal.cross_sectional_area_for_passage_of_combustion_products} м²` },
          { param: 'Расчетная площадь поверхности нагрева', value: `${rs.data?.value[3].inputVal.estimated_heating_surface_area} м²` },
          { param: 'Диаметр труб', value: `${rs.data?.value[3].inputVal.pipe_diametr} м` },
          { param: 'Поперечный шаг труб S1', value: `${rs.data?.value[3].inputVal.transverse_pitch_of_pipe} м` },
          { param: 'Продольный шаг труб S2', value: `${rs.data?.value[3].inputVal.longitudinal_pitch_of_pipes} м` },
          { param: 'Количество рядов труб по ходу продуктов сгорания', value: `${rs.data?.value[3].inputVal.number_of_pipe_rows} шт` },
          { param: 'Температура нагреваемой среды на входе', value: `${rs.data?.value[3].inputVal.temperature_of_the_the_heated_medium_at_The_inlet} °C` },
          { param: 'Температура нагреваемой среды на выходе', value: `${rs.data?.value[3].inputVal.temperature_of_the_the_heated_medium_at_The_outlet} °C` },
        ]} />
        <Text style={styles.sectionTitle}>Секция Экономайзер - Расчётные данные</Text>
        <ParamTable data={[
          { param: 'Средняя тепмература в секции', value: `${rs.data?.value[3].outputCodeVal.aver_temperature_section} °C` },
          { param: 'Число Прандтля', value: `${rs.data?.value[3].outputCodeVal.prandle_number}` },
          { param: 'Коеффициент теплопроводности', value: `${rs.data?.value[3].outputCodeVal.coef_of_thermal_conductivity} Вт/(м*К)` },
          { param: 'Коеффициент кинематической вязкости', value: `${rs.data?.value[3].outputCodeVal.coef_of_kinematic_viscosity} м²/с` },
          { param: 'Расход газа при н.у', value: `${rs.data?.value[3].outputCodeVal.gaz_used_n_u} м³/с` },
          { param: 'Расход газа с учетом подсоса', value: `${rs.data?.value[3].outputCodeVal.gaz_used_podsos} м³/с` },
          { param: 'Действительный расход дымовых газов', value: `${rs.data?.value[3].outputCodeVal.actual_flue_gas_consumption} м³/с` },
          { param: 'Диагональный шаг труб', value: `${rs.data?.value[3].outputCodeVal.aver_smok_gaz_speed}` },
          { param: 'Параметр p', value: `${rs.data?.value[3].outputCodeVal.p_parametr}` },
          { param: 'Конвективный коэффициент теплопередачи', value: `${rs.data?.value[3].outputCodeVal.convective_coef_thermosender} Вт/(м²*К)` },
          { param: 'Параметр ps', value: `${rs.data?.value[3].outputCodeVal.ps_parametr}` },
          { param: 'Парциональное давление H₂O', value: `${rs.data?.value[3].outputCodeVal.parti_presure_h2o} бар` },
          { param: 'Парциональное давление CO₂', value: `${rs.data?.value[3].outputCodeVal.parti_presure_co2} бар` },
          { param: 'Эффективная толщина излучающего слоя Sэф', value: `${rs.data?.value[3].outputCodeVal.effective_thickness_emission_layer} м` },
          { param: 'Температура наружной поверхности стенки Tст', value: `${rs.data?.value[3].outputCodeVal.temperature_outside_cover} K` },
          { param: 'Средняя температура дымовых газов Tср', value: `${rs.data?.value[3].outputCodeVal.aver_temperature_smoke_gaz} K` },
          { param: 'Спектральный коэффициент ослабления K1', value: `${rs.data?.value[3].outputCodeVal.spektr_coeff_lower1}` },
          { param: 'Спектральный коэффициент ослабления K2', value: `${rs.data?.value[3].outputCodeVal.spektr_coeff_lower2}` },
          { param: 'Степень черноты дымовых газов εд', value: `${rs.data?.value[3].outputCodeVal.degree_blackness_smokness_gazez}` },
          { param: 'Коэффициент поглощаения αд', value: `${rs.data?.value[3].outputCodeVal.absorption_coeff}` },
          { param: 'Cпр', value: `${rs.data?.value[3].outputCodeVal.c_pr}` },
          { param: 'Коэффициент теплоотдачи излучением, αдл', value: `${rs.data?.value[3].outputCodeVal.coeff_heat_transfer_by_emmision} Вт/(м²*К)` },
          { param: 'Суммарный коэффициент теплоотдачи от продуктов, αд', value: `${rs.data?.value[3].outputCodeVal.total_heat_coeff_from_products} Вт/(м²*К)` },
          { param: 'Разность температур начальная, ∆tн', value: `${rs.data?.value[3].outputCodeVal.initial_temperature_difference} °C` },
          { param: 'Разность температур конечная, ∆tк', value: `${rs.data?.value[3].outputCodeVal.finitial_temperature_difference} °C` },
          { param: 'Коэффициент теплоотдачи к нагреваемой среде и обратный', value: `${rs.data?.value[3].outputCodeVal.coeff_thermal_transfer_heating_env}` },
          { param: 'Коэффициент теплопередачи, k', value: `${rs.data?.value[3].outputCodeVal.coeff_heat_transfer} Вт/(м²*К)` },
          { param: 'Среднелогарифмическая разность температур', value: `${rs.data?.value[3].outputCodeVal.averlogarifmic_thermal_difference} °C` },
          { param: 'Количество тепла, переданное газами', value: `${rs.data?.value[3].outputCodeVal.thermal_total_gazes_transfer} кВт` },
          { param: 'Теоретическая энтальпия входящих газов', value: `${rs.data?.value[3].outputCodeVal.incoming_entalpia_gazes} кДж/м³` },
          { param: 'Теоретическая энтальпия выходящих газов', value: `${rs.data?.value[3].outputCodeVal.outcoming_entalpia_gazes} кДж/м³` },
          { param: 'Расчетная энтальпия iд', value: `${rs.data?.value[3].outputCodeVal.calculated_entalpia_from_thermal_total} кДж/м³` },
        ]} />


        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page>


      {/* Result */}
      <Page size="A4" style={styles.page}>
        <Text style={styles.sectionTitle}>РЕЗУЛЬТАТЫ РАСЧЁТА ПАРОПРОИЗВОДИТЕЛЬНОСТИ</Text>
        <ParamTable data={[
          { param: 'Количество теплоты, переданное воде и пару', value: `${rs.data?.result.thermal_count_transfered_water_and_steam} кВт` },
          { param: 'Количество тепла, переданное в пароперегревателе', value: `${rs.data?.result.thermal_count_transfered_in_paroperegrevatel} кВт` },
          { param: 'Энтальпия питательной воды', value: `${rs.data?.result.entalpia_eaten_water} кДж/кг` },
          { param: 'Расчетная энтальпия перегретого пара', value: `${rs.data?.result.calculated_theoretic_entalpia_hotest_steam} кДж/кг` },
          { param: 'Расхождение процентное', value: `${rs.data?.result.percentage_discrepancy} %` },
          { param: 'Паропроизводительность, кг/с', value: `${rs.data?.result.steam_capicity} кг/с` },
        ]} />

        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page>
        {/* {rs.advInform == true ? (
        <Page size="A4" style={styles.page}>
          <Text style={styles.sectionTitle}>Секция "Все данные"</Text>
          <ParamTable data={[
            rs.data?.otherVal.forEach(el => {
              
            })
            // { param: 'Температура входящих газов', value: '310,60 °C' },
          ]} />

          <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
        </Page>

        )} */}
    </Document>
  );
};