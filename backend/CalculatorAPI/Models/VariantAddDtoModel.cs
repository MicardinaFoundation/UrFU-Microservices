namespace RecuperatorCore.Models
{
    public class VariantAddDtoModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }

        public modelVal Modela { get; set; }

    }
    public class VariantEditDtoModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public int VariantId { get; set; }

        public modelVal Modela { get; set; }

    }

    public class modelVal
    {
        #region =Vvedenie=

        #region =Gaz General - General=

        /// <summary>
        /// Углекислый газ %
        /// </summary>
        public double Co2 { get; set; }

        /// <summary>
        /// Вода %
        /// </summary>
        public double H2o { get; set; }

        /// <summary>
        /// Азот %
        /// </summary>
        public double N2 { get; set; }

        /// <summary>
        /// Кислород %
        /// </summary>
        public double O2 { get; set; }

        #endregion

        #region =General value - General=

        /// <summary>
        /// Расход газа, м^3/ч
        /// </summary>
        public double Gaz_used { get; set; }

        /// <summary>
        /// Давление получаемого пара, Mpa
        /// </summary>
        public double Presure_putten_par { get; set; }

        /// <summary>
        /// Температура питательной воды, *C
        /// </summary>
        public double Temperature_eaten_water { get; set; }

        /// <summary>
        /// Температура получаемого пара, *C
        /// </summary>
        public double Temperature_arrive_smoke { get; set; }

        #endregion

        #region =Block NSI 1=

        /// <summary>
        /// Температура входящих газов
        /// </summary>
        public double Temperature_of_incoming_gases_1 { get; set; }

        /// <summary>
        /// Поправка на число рядов труб Cz
        /// </summary>
        public double Popravka_na_chair_radov_pipes_1 { get; set; }

        /// <summary>
        /// Температура отходящих газов
        /// </summary>
        public double Temperature_of_outcoming_gases_1 { get; set; }

        /// <summary>
        /// Площадь сечения для прохода продуктов сгорания
        /// </summary>
        public double Cross_sectional_area_for_passage_of_combustion_products_1 { get; set; }

        /// <summary>
        /// Расчетная площадь поверхности нагрева
        /// </summary>
        public double Estimated_heating_surface_area_1 { get; set; }

        /// <summary>
        /// Диаметр труб
        /// </summary>
        public double Pipe_diametr_1 { get; set; }

        /// <summary>
        /// Поперечный шаг труб S1
        /// </summary>
        public double Transverse_pitch_of_pipe_1 { get; set; }

        /// <summary>
        /// Продольный шаг труб S2
        /// </summary>
        public double Longitudinal_pitch_of_pipes_1 { get; set; }

        /// <summary>
        /// Количество рядов труб по ходу продуктов сгорания
        /// </summary>
        public double Number_of_pipe_rows_1 { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на входе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_inlet_1 { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на выходе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_outlet_1 { get; set; }
        #endregion

        #region =Block NSI 2=

        /// <summary>
        /// Температура входящих газов
        /// </summary>
        public double Temperature_of_incoming_gases_2 { get; set; }

        /// <summary>
        /// Поправка на число рядов труб Cz
        /// </summary>
        public double Popravka_na_chair_radov_pipes_2 { get; set; }

        /// <summary>
        /// Температура отходящих газов
        /// </summary>
        public double Temperature_of_outcoming_gases_2 { get; set; }

        /// <summary>
        /// Площадь сечения для прохода продуктов сгорания
        /// </summary>
        public double Cross_sectional_area_for_passage_of_combustion_products_2 { get; set; }

        /// <summary>
        /// Расчетная площадь поверхности нагрева
        /// </summary>
        public double Estimated_heating_surface_area_2 { get; set; }

        /// <summary>
        /// Диаметр труб
        /// </summary>
        public double Pipe_diametr_2 { get; set; }

        /// <summary>
        /// Поперечный шаг труб S1
        /// </summary>
        public double Transverse_pitch_of_pipe_2 { get; set; }

        /// <summary>
        /// Продольный шаг труб S2
        /// </summary>
        public double Longitudinal_pitch_of_pipes_2 { get; set; }

        /// <summary>
        /// Количество рядов труб по ходу продуктов сгорания
        /// </summary>
        public double Number_of_pipe_rows_2 { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на входе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_inlet_2 { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на выходе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_outlet_2 { get; set; }
        #endregion

        #region =Block NSI 3=

        /// <summary>
        /// Температура входящих газов
        /// </summary>
        public double Temperature_of_incoming_gases_3 { get; set; }

        /// <summary>
        /// Поправка на число рядов труб Cz
        /// </summary>
        public double Popravka_na_chair_radov_pipes_3 { get; set; }

        /// <summary>
        /// Температура отходящих газов
        /// </summary>
        public double Temperature_of_outcoming_gases_3 { get; set; }

        /// <summary>
        /// Площадь сечения для прохода продуктов сгорания
        /// </summary>
        public double Cross_sectional_area_for_passage_of_combustion_products_3 { get; set; }

        /// <summary>
        /// Расчетная площадь поверхности нагрева
        /// </summary>
        public double Estimated_heating_surface_area_3 { get; set; }

        /// <summary>
        /// Диаметр труб
        /// </summary>
        public double Pipe_diametr_3 { get; set; }

        /// <summary>
        /// Поперечный шаг труб S1
        /// </summary>
        public double Transverse_pitch_of_pipe_3 { get; set; }

        /// <summary>
        /// Продольный шаг труб S2
        /// </summary>
        public double Longitudinal_pitch_of_pipes_3 { get; set; }

        /// <summary>
        /// Количество рядов труб по ходу продуктов сгорания
        /// </summary>
        public double Number_of_pipe_rows_3 { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на входе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_inlet_3 { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на выходе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_outlet_3 { get; set; }
        #endregion

        #region =Block NSI 4=

        /// <summary>
        /// Температура входящих газов
        /// </summary>
        public double Temperature_of_incoming_gases_4 { get; set; }

        /// <summary>
        /// Поправка на число рядов труб Cz
        /// </summary>
        public double Popravka_na_chair_radov_pipes_4 { get; set; }

        /// <summary>
        /// Температура отходящих газов
        /// </summary>
        public double Temperature_of_outcoming_gases_4 { get; set; }

        /// <summary>
        /// Площадь сечения для прохода продуктов сгорания
        /// </summary>
        public double Cross_sectional_area_for_passage_of_combustion_products_4 { get; set; }

        /// <summary>
        /// Расчетная площадь поверхности нагрева
        /// </summary>
        public double Estimated_heating_surface_area_4 { get; set; }

        /// <summary>
        /// Диаметр труб
        /// </summary>
        public double Pipe_diametr_4 { get; set; }

        /// <summary>
        /// Поперечный шаг труб S1
        /// </summary>
        public double Transverse_pitch_of_pipe_4 { get; set; }

        /// <summary>
        /// Продольный шаг труб S2
        /// </summary>
        public double Longitudinal_pitch_of_pipes_4 { get; set; }

        /// <summary>
        /// Количество рядов труб по ходу продуктов сгорания
        /// </summary>
        public double Number_of_pipe_rows_4 { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на входе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_inlet_4 { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на выходе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_outlet_4 { get; set; }
        #endregion

        #region =Extended values - General=
        /// <summary>
        /// Доля подсасываемого воздуха
        /// </summary>
        public double Proportion_of_intake_air { get; set; }

        /// <summary>
        /// Термическое сопротивление отложений на трубах
        /// </summary>
        public double Thermal_resistance_of_deposits_on_pipes { get; set; }

        /// <summary>
        /// Коэффициент излучения абсолютно черного тела
        /// </summary>
        public double The_emission_coefficient_of_a_completely_black_body { get; set; }

        /// <summary>
        /// Степень черноты стенок трубного пакета
        /// </summary>
        public double The_degree_of_blackness_of_the_walls_of_the_tube_package { get; set; }

        /// <summary>
        /// Коэффициент сохранения тепла
        /// </summary>
        public double Heat_preservation_coefficient { get; set; }

        /// <summary>
        /// Продувка n
        /// </summary>
        public double Purge_n { get; set; }
        #endregion

        #endregion

    }
}
