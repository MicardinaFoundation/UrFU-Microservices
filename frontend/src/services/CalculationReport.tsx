import React from 'react';
import { Document, Page, Text, View, StyleSheet, Font } from '@react-pdf/renderer';
import RobotoRegular from '@/services/fonts/font.ttf';
import RobotoBold from '@/services/fonts/fontbd.ttf';
import { useModel } from '@umijs/max';
import { BoilerCalculationResponse } from '@/constants/typing';
// 1. Регистрация кириллического шрифта (используем Roboto через Google Fonts CDN)
Font.register({
  family: 'Roboto',
  fonts: [
    { src: RobotoRegular, fontWeight: 'normal' },
    { src: RobotoBold, fontWeight: 'bold' },
  ],
});

// 2. Стилизация в строгом инженерном стиле
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

// Интерфейс для строк таблиц
interface DataRow {
  param: string;
  value: string;
}

// Компонент для рендеринга стандартной таблицы параметров
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
// 3. Основной компонент документа
export const CalculationReport: React.FC<Props> = (rs) => {
  //console.log(rs);
  
  //const { data } = useModel('variantModel');
  return (
    <Document>
      {/* СТРАНИЦА 1: Исходные данные и Секция ПИП */}
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

        <Text style={styles.sectionTitle}>Секция ПИП - Исходные & Расчетные данные</Text>
        <ParamTable data={[
          { param: 'Температура входящих газов', value: `${rs.data?.value[0].inputVal.temperature_of_incoming_gases} °C` },
          { param: 'Температура отходящих газов', value: `${rs.data?.value[0].inputVal.temperature_of_outcoming_gases} °C` },
          { param: 'Расчетная площадь поверхности нагрева', value: `${rs.data?.value[0].inputVal.estimated_heating_surface_area}` },
          { param: 'Количество рядов труб по ходу продуктов сгорания', value: `${rs.data?.value[0].inputVal.estimated_heating_surface_area} шт` },
          { param: 'Температура нагреваемой среды на входе', value: `${rs.data?.value[0].inputVal.temperature_of_the_the_heated_medium_at_The_inlet} °C` },
          { param: 'Температура нагреваемой среды на выходе', value: `${rs.data?.value[0].inputVal.temperature_of_the_the_heated_medium_at_The_outlet} °C` },

          { param: 'Конвективный коэффициент теплопередачи', value: `${rs.data?.value[0].outputCodeVal.coeff_heat_transfer} Вт/(м²·К)` },
          { param: 'Коэффициент теплопередачи, к', value: `${rs.data?.value[0].outputCodeVal.coeff_heat_transfer} Вт/(м²·К)` },
          { param: 'Количество тепла, переданное газами', value: `${rs.data?.value[0].outputCodeVal.thermal_total_gazes_transfer} кВт` },
        ]} />

        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page>

      {/* СТРАНИЦА 2: Секция Пароперегреватель и Секция ИС */}
      <Page size="A4" style={styles.page}>
        <Text style={styles.sectionTitle}>Секция Пароперегреватель - Исходные & Расчетные данные</Text>
        <ParamTable data={[
          { param: 'Температура входящих газов', value: `${rs.data?.value[1].inputVal.temperature_of_incoming_gases} °C` },
          { param: 'Температура отходящих газов', value: `${rs.data?.value[1].inputVal.temperature_of_outcoming_gases} °C` },
          { param: 'Расчетная площадь поверхности нагрева', value: `${rs.data?.value[1].inputVal.estimated_heating_surface_area}` },
          { param: 'Количество рядов труб по ходу продуктов сгорания', value: `${rs.data?.value[1].inputVal.estimated_heating_surface_area} шт` },
          { param: 'Температура нагреваемой среды на входе', value: `${rs.data?.value[1].inputVal.temperature_of_the_the_heated_medium_at_The_inlet} °C` },
          { param: 'Температура нагреваемой среды на выходе', value: `${rs.data?.value[1].inputVal.temperature_of_the_the_heated_medium_at_The_outlet} °C` },

          { param: 'Конвективный коэффициент теплопередачи', value: `${rs.data?.value[1].outputCodeVal.coeff_heat_transfer} Вт/(м²·К)` },
          { param: 'Коэффициент теплопередачи, к', value: `${rs.data?.value[1].outputCodeVal.coeff_heat_transfer} Вт/(м²·К)` },
          { param: 'Количество тепла, переданное газами', value: `${rs.data?.value[1].outputCodeVal.thermal_total_gazes_transfer} кВт` },
        ]} />

        <Text style={styles.sectionTitle}>Секция ИС - Исходные & Расчетные данные</Text>
        <ParamTable data={[
          { param: 'Температура входящих газов', value: `${rs.data?.value[2].inputVal.temperature_of_incoming_gases} °C` },
          { param: 'Температура отходящих газов', value: `${rs.data?.value[2].inputVal.temperature_of_outcoming_gases} °C` },
          { param: 'Расчетная площадь поверхности нагрева', value: `${rs.data?.value[2].inputVal.estimated_heating_surface_area}` },
          { param: 'Количество рядов труб по ходу продуктов сгорания', value: `${rs.data?.value[2].inputVal.estimated_heating_surface_area} шт` },
          { param: 'Температура нагреваемой среды на входе', value: `${rs.data?.value[2].inputVal.temperature_of_the_the_heated_medium_at_The_inlet} °C` },
          { param: 'Температура нагреваемой среды на выходе', value: `${rs.data?.value[2].inputVal.temperature_of_the_the_heated_medium_at_The_outlet} °C` },
          
          { param: 'Конвективный коэффициент теплопередачи', value: `${rs.data?.value[2].outputCodeVal.coeff_heat_transfer} Вт/(м²·К)` },
          { param: 'Коэффициент теплопередачи, к', value: `${rs.data?.value[2].outputCodeVal.coeff_heat_transfer} Вт/(м²·К)` },
          { param: 'Количество тепла, переданное газами', value: `${rs.data?.value[2].outputCodeVal.thermal_total_gazes_transfer} кВт` },
        ]} />

        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page>

      {/* СТРАНИЦА 3: Экономайзер и Итоговая Паропроизводительность */}
      <Page size="A4" style={styles.page}>
        <Text style={styles.sectionTitle}>Секция Экономайзер - Исходные & Расчетные данные</Text>
        <ParamTable data={[
          { param: 'Температура входящих газов', value: `${rs.data?.value[3].inputVal.temperature_of_incoming_gases} °C` },
          { param: 'Температура отходящих газов', value: `${rs.data?.value[3].inputVal.temperature_of_outcoming_gases} °C` },
          { param: 'Расчетная площадь поверхности нагрева', value: `${rs.data?.value[3].inputVal.estimated_heating_surface_area}` },
          { param: 'Количество рядов труб по ходу продуктов сгорания', value: `${rs.data?.value[3].inputVal.estimated_heating_surface_area} шт` },
          { param: 'Температура нагреваемой среды на входе', value: `${rs.data?.value[3].inputVal.temperature_of_the_the_heated_medium_at_The_inlet} °C` },
          { param: 'Температура нагреваемой среды на выходе', value: `${rs.data?.value[3].inputVal.temperature_of_the_the_heated_medium_at_The_outlet} °C` },
          
          { param: 'Конвективный коэффициент теплопередачи', value: `${rs.data?.value[3].outputCodeVal.coeff_heat_transfer} Вт/(м²·К)` },
          { param: 'Коэффициент теплопередачи, к', value: `${rs.data?.value[3].outputCodeVal.coeff_heat_transfer} Вт/(м²·К)` },
          { param: 'Количество тепла, переданное газами', value: `${rs.data?.value[3].outputCodeVal.thermal_total_gazes_transfer} кВт` },
        ]} />

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

      {/* СТРАНИЦА 4: Все данные
      <Page size="A4" style={styles.page}>
        <Text style={styles.sectionTitle}>Секция "Все данные"</Text>
        <ParamTable data={[
          data?.otherVal.forEach(el => {
            
          })
          // { param: 'Температура входящих газов', value: '310,60 °C' },
        ]} />

        <Text style={styles.pageNumber} render={({ pageNumber, totalPages }) => `${pageNumber} / ${totalPages}`} fixed />
      </Page> */}
    </Document>
  );
};