// type Variant = {
//     id: number;
//     lastName: string;
//     firstName: string;
//     midName?: string;
//     group: string;
// }
type Variant = {
    id: number;
    namsName: string;
    name: string;
    numb: number;
    description: string;
    groupId: string;
    createdAt: string;
    updatedAt: string;

}

type Category = {
    idChanged: number;
    cathegories: string;
}


// --- 1. Входные параметры для отдельной секции котла ---
export interface SectionInputVal {
  temperature_of_incoming_gases: number;                             // Температура входящих газов, °C
  popravka_na_chair_radov_pipes: number;                             // Поправка на число рядов труб Cz
  temperature_of_outcoming_gases: number;                            // Температура отходящих газов, °C
  cross_sectional_area_for_passage_of_combustion_products: number;   // Площадь сечения для прохода продуктов сгорания, м²
  estimated_heating_surface_area: number;                            // Расчетная площадь поверхности нагрева, м²
  pipe_diametr: number;                                              // Диаметр труб, м
  transverse_pitch_of_pipe: number;                                  // Поперечный шаг труб S1, м
  longitudinal_pitch_of_pipes: number;                               // Продольный шаг труб S2, м
  number_of_pipe_rows: number;                                       // Количество рядов труб, шт
  temperature_of_the_the_heated_medium_at_The_inlet: number;         // Температура нагреваемой среды на входе, °C
  temperature_of_the_the_heated_medium_at_The_outlet: number;        // Температура нагреваемой среды на выходе, °C
}

// --- 2. Выходные (расчетные) параметры для отдельной секции ---
export interface SectionOutputCodeVal {
  aver_temperature_section: number;                  // Средняя температура в секции, °C
  gaz_used_n_u: number;                              // Расход газа при н.у., м³/с
  gaz_used_podsos: number;                           // Расход газа с учетом подсоса, м³/с
  actual_flue_gas_consumption: number;               // Действительный расход дымовых газов, м³/с
  aver_smok_gaz_speed: number;                       // Диагональный шаг труб (или средняя скорость газов)
  initial_temperature_difference: number;            // Разность температур начальная, °C
  finitial_temperature_difference: number;           // Разность температур конечная, °C
  averlogarifmic_thermal_difference: number;         // Среднелогарифмическая разность температур, °C
  diagonal_pipe_step: number;                        // Диагональный шаг труб
  p_parametr: number;                                // Параметр p
  prandle_number: number;                            // Число Прандтля
  coef_of_thermal_conductivity: number;              // Коэффициент теплопроводности, Вт/(м·К)
  coef_of_kinematic_viscosity: number;               // Коэффициент кинематической вязкости, м²/с
  convective_coef_thermosender: number;              // Конвективный коэффициент теплопередачи, Вт/(м²·К)
  ps_parametr: number;                               // Параметр ps
  effective_thickness_emission_layer: number;        // Эффективная толщина излучающего слоя Sэф, м
  parti_presure_h2o: number;                         // Парциальное давление H2O, бар
  parti_presure_co2: number;                         // Парциальное давление CO2, бар
  temperature_outside_cover: number;                 // Температура наружной поверхности стенки Тст, К
  aver_temperature_smoke_gaz: number;                // Средняя температура дымовых газов Тср, К
  spektr_coeff_lower1: number;                       // Спектральный коэффициент ослабления К1
  degree_blackness_smokness_gazez: number;           // Степень черноты дымовых газов εд
  spektr_coeff_lower2: number;                       // Спектральный коэффициент ослабления К2
  absorption_coeff: number;                          // Коэффициент поглощения ад
  c_pr: number;                                      // Спр
  coeff_heat_transfer_by_emmision: number;           // Коэффициент теплоотдачи излучением, αлл, Вт/(м²·К)
  total_heat_coeff_from_products: number;            // Суммарный коэф. теплоотдачи от продуктов, ад, Вт/(м²·К)
  coeff_thermal_transfer_heating_env: number;        // Коэффициент теплоотдачи к нагреваемой среде и обратный
  coeff_heat_transfer: number;                       // Коэффициент теплопередачи, k, Вт/(м²·К)
  thermal_total_gazes_transfer: number;              // Количество тепла, переданное газами, кВт
  incoming_entalpia_gazes: number;                   // Теоретическая энтальпия входящих газов, кДж/м³
  outcoming_entalpia_gazes: number;                  // Теоретическая энтальпия выходящих газов, кДж/м³
  calculated_entalpia_from_thermal_total: number;    // Расчетная энтальпия iд", кДж/м³
}

// --- 3. Структура одного элемента массива секций ---
export interface BoilerSectionItem {
  inputVal: SectionInputVal;
  outputCodeVal: SectionOutputCodeVal;
}

// --- 4. Финальные результаты расчета паропроизводительности ---
export interface BoilerTotalResult {
  thermal_count_transfered_water_and_steam: number;  // Количество теплоты, переданное воде и пару, кВт
  thermal_count_transfered_in_paroperegrevatel: number; // Количество тепла, переданное в пароперегревателе, кВт
  entalpia_hot_water: number;                        // Энтальпия кипящей воды, кДж/кг
  entalpia_eaten_water: number;                      // Энтальпия питательной воды, кДж/кг
  entalpia_saturated_dry_steam: number;              // Энтальпия сухого насыщенного пара (кипящей воды в PDF), кДж/кг
  calculated_entalpia_hotest_steam: number;          // Расчетная энтальпия перегретого пара, кДж/кг
  calculated_theoretic_entalpia_hotest_steam: number; // Теоретическая энтальпия перегретого пара, кДж/кг
  percentage_discrepancy: number;                    // Расхождение процентное, %
  steam_capicity: number;                            // Паропроизводительность, кг/с
}

// --- 5. Корневой тип для всего JSON-ответа ---
export interface BoilerCalculationResponse {
  otherVal: any;
  value: BoilerSectionItem[];
  result: BoilerTotalResult;
}