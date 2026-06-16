using KotelUtilizatorLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KotelUtilizatorLibrary.Models
{
    public class DataInputModel 
    {
        // Создать главный объект, который включает в себя все нужные объекты
        private MathLib _cs = new();

        public DataInputModel() { }

        #region - Состав дымовых газов -
        /// <summary>
        /// Углекислый газ %
        /// </summary>
        private double co2;
        /// <summary>
        /// Углекислый газ %
        /// </summary>
        [DefaultValue(10)]
        public double Co2
        {
            get { return co2; }
            set { co2 = value; }
        }

        /// <summary>
        /// Вода %
        /// </summary>
        private double h2o;
        /// <summary>
        /// Вода %
        /// </summary>
        [DefaultValue(15)]
        public double H2o
        {
            get { return h2o; }
            set { h2o = value; }
        }

        /// <summary>
        /// Азот %
        /// </summary>
        private double n2;
        /// <summary>
        /// Азот %
        /// </summary>
        [DefaultValue(70)]
        public double N2
        {
            get { return n2; }
            set { n2 = value; }
        }

        /// <summary>
        /// Кислород %
        /// </summary>
        private double o2;
        /// <summary>
        /// Кислород %
        /// </summary>
        [DefaultValue(5)]
        public double O2
        {
            get { return o2; }
            set { o2 = value; }
        }

        #endregion

        #region - Исходные данные -

        /// <summary>
        /// Расход газа, м^3/ч
        /// </summary>
        private double gaz_used;
        /// <summary>
        /// Расход газа, м^3/ч
        /// </summary>
        [DefaultValue(40000)]
        public double Gaz_used
        {
            get { return gaz_used; }
            set { gaz_used = value; }
        }

        /// <summary>
        /// Давление получаемого пара, Mpa
        /// </summary>
        private double presure_putten_par;
        /// <summary>
        /// Давление получаемого пара, Mpa
        /// </summary>
        [DefaultValue(1.8)]
        public double Presure_putten_par
        {
            get { return presure_putten_par; }
            set { presure_putten_par = value; }
        }

        /// <summary>
        /// Температура питательной воды, *C
        /// </summary>
        private double temperature_eaten_water;
        /// <summary>
        /// Температура питательной воды, *C
        /// </summary>
        [DefaultValue(100)]
        public double Temperature_eaten_water
        {
            get { return temperature_eaten_water; }
            set { temperature_eaten_water = value; }
        }

        /// <summary>
        /// Температура получаемого пара, *C
        /// </summary>
        private double temperature_arrive_smoke;
        /// <summary>
        /// Температура получаемого пара, *C
        /// </summary>
        [DefaultValue(375)]
        public double Temperature_arrive_smoke
        {
            get => temperature_arrive_smoke;
            set => temperature_arrive_smoke = value;
        }
        #endregion

        #region - Блок нормативно-справочной информации (НСИ) -

        /// <summary>
        /// Температура входящих газов
        /// </summary>
        private double temperature_of_incoming_gases;
        /// <summary>
        /// Температура входящих газов
        /// </summary>
        public double Temperature_of_incoming_gases
        {
            get { return temperature_of_incoming_gases; }
            set { temperature_of_incoming_gases = value; }
        }

        /// <summary>
        /// Поправка на число рядов труб Cz
        /// </summary>
        private double popravka_na_chislo_radov_pipes;
        /// <summary>
        /// Поправка на число рядов труб Cz
        /// </summary>
        public double Popravka_na_chair_radov_pipes
        {
            get { return popravka_na_chislo_radov_pipes; }
            set { popravka_na_chislo_radov_pipes = value; }
        }

        /// <summary>
        /// Температура отходящих газов
        /// </summary>
        private double temperature_of_outcoming_gases;
        /// <summary>
        /// Температура отходящих газов
        /// </summary>
        public double Temperature_of_outcoming_gases
        {
            get { return temperature_of_outcoming_gases; }
            set { temperature_of_outcoming_gases = value; }
        }

        /// <summary>
        /// Площадь сечения для прохода продуктов сгорания
        /// </summary>
        private double cross_sectional_area_for_passage_of_combustion_products;
        /// <summary>
        /// Площадь сечения для прохода продуктов сгорания
        /// </summary>
        public double Cross_sectional_area_for_passage_of_combustion_products
        {
            get { return cross_sectional_area_for_passage_of_combustion_products; }
            set { cross_sectional_area_for_passage_of_combustion_products = value; }
        }

        /// <summary>
        /// Расчетная площадь поверхности нагрева
        /// </summary>
        private double estimated_heating_surface_area;
        /// <summary>
        /// Расчетная площадь поверхности нагрева
        /// </summary>
        public double Estimated_heating_surface_area
        {
            get { return estimated_heating_surface_area; }
            set { estimated_heating_surface_area = value; }
        }


        /// <summary>
        /// Диаметр труб
        /// </summary>
        private double pipe_diametr;
        /// <summary>
        /// Диаметр труб
        /// </summary>
        public double Pipe_diametr
        {
            get
            {
                return pipe_diametr;
            }
            set
            {
                pipe_diametr = value;
            }
        }

        /// <summary>
        /// Поперечный шаг труб S1
        /// </summary>
        private double transverse_pitch_of_pipes;
        /// <summary>
        /// Поперечный шаг труб S1
        /// </summary>
        public double Transverse_pitch_of_pipe
        {
            get
            {
                return transverse_pitch_of_pipes;
            }
            set
            {
                transverse_pitch_of_pipes = value;
            }
        }

        /// <summary>
        /// Продольный шаг труб S2
        /// </summary>
        private double longitudinal_pitch_of_pipes;
        /// <summary>
        /// Продольный шаг труб S2
        /// </summary>
        public double Longitudinal_pitch_of_pipes
        {
            get
            {
                return longitudinal_pitch_of_pipes;
            }
            set
            {
                longitudinal_pitch_of_pipes = value;
            }
        }

        /// <summary>
        /// Количество рядов труб по ходу продуктов сгорания
        /// </summary>
        private double number_of_pipe_rows;
        /// <summary>
        /// Количество рядов труб по ходу продуктов сгорания
        /// </summary>
        public double Number_of_pipe_rows
        {
            get { return number_of_pipe_rows; }
            set { number_of_pipe_rows = value; }
        }
        #endregion

        #region - Дополнительные исходные и справочные данные -
        /// <summary>
        /// Доля подсасываемого воздуха
        /// </summary>
        private double proportion_of_intake_air;
        /// <summary>
        /// Доля подсасываемого воздуха
        /// </summary>
        [DefaultValue(0.1)]
        public double Proportion_of_intake_air
        {
            get
            {
                return proportion_of_intake_air;
            }
            set
            {
                proportion_of_intake_air = value;
            }
        }

        /// <summary>
        /// Термическое сопротивление отложений на трубах
        /// </summary>
        private double thermal_resistance_of_deposits_on_pipes;
        /// <summary>
        /// Термическое сопротивление отложений на трубах
        /// </summary>
        [DefaultValue(0)]
        public double Thermal_resistance_of_deposits_on_pipes
        {
            get
            {
                return thermal_resistance_of_deposits_on_pipes;
            }
            set
            {
                thermal_resistance_of_deposits_on_pipes = value;
            }
        }

        /// <summary>
        /// Коэффициент излучения абсолютно черного тела
        /// </summary>
        private double the_emission_coefficient_of_a_completely_black_body;
        /// <summary>
        /// Коэффициент излучения абсолютно черного тела
        /// </summary>
        [DefaultValue(5.67)]
        public double The_emission_coefficient_of_a_completely_black_body
        {
            get
            {
                return the_emission_coefficient_of_a_completely_black_body;
            }
            set
            {
                the_emission_coefficient_of_a_completely_black_body = value;
            }
        }

        /// <summary>
        /// Степень черноты стенок трубного пакета
        /// </summary>
        private double the_degree_of_blackness_of_the_walls_of_the_tube_package;
        /// <summary>
        /// Степень черноты стенок трубного пакета
        /// </summary>
        [DefaultValue(0.8)]
        public double The_degree_of_blackness_of_the_walls_of_the_tube_package
        {
            get
            {
                return the_degree_of_blackness_of_the_walls_of_the_tube_package;
            }
            set
            {
                the_degree_of_blackness_of_the_walls_of_the_tube_package = value;
            }
        }

        /// <summary>
        /// Коэффициент сохранения тепла
        /// </summary>
        private double heat_preservation_coefficient;
        /// <summary>
        /// Коэффициент сохранения тепла
        /// </summary>
        [DefaultValue(0.9)]
        public double Heat_preservation_coefficient
        {
            get
            {
                return heat_preservation_coefficient;
            }
            set
            {
                heat_preservation_coefficient = value;
            }
        }

        /// <summary>
        /// Продувка n
        /// </summary>
        private double purge_n;
        /// <summary>
        /// Продувка n
        /// </summary>
        [DefaultValue(10)]
        public double Purge_n
        {
            get
            {
                return purge_n;
            }
            set
            {
                purge_n = value;
            }
        }
        #endregion

        #region - Данные для среднелогарифмической разности температур -

        /// <summary>
        /// Температура нагреваемой среды на входе
        /// </summary>
        private double temperature_of_the_heated_medium_at_the_inlet;
        /// <summary>
        /// Температура нагреваемой среды на входе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_inlet
        {
            get
            {
                return temperature_of_the_heated_medium_at_the_inlet;
            }
            set
            {
                temperature_of_the_heated_medium_at_the_inlet = value;
            }
        }

        /// <summary>
        /// Температура нагреваемой среды на выходе
        /// </summary>
        private double temperature_of_the_heated_medium_at_the_outlet;
        /// <summary>
        /// Температура нагреваемой среды на выходе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_outlet
        {
            get
            {
                return temperature_of_the_heated_medium_at_the_outlet;
            }
            set
            {
                temperature_of_the_heated_medium_at_the_outlet = value;
            }
        }


        #endregion

        [DefaultValue(800)] public double Temperature_of_incoming_gases_1 { get; set; }
        [DefaultValue(0.98)] public double Popravka_na_chair_radov_pipes_1 { get; set; }
        [DefaultValue(704)] public double Temperature_of_outcoming_gases_1 { get; set; }
        [DefaultValue(4.32)] public double Cross_sectional_area_for_passage_of_combustion_products_1 { get; set; }
        [DefaultValue(30)] public double Estimated_heating_surface_area_1 { get; set; }
        [DefaultValue(0.032)] public double Pipe_diametr_1 { get; set; }
        [DefaultValue(0.172)] public double Transverse_pitch_of_pipe_1 { get; set; }
        [DefaultValue(0.07)] public double Longitudinal_pitch_of_pipes_1 { get; set; }
        [DefaultValue(12)] public double Number_of_pipe_rows_1 { get; set; }
        [DefaultValue(206)] public double Temperature_of_the_the_heated_medium_at_The_inlet_1 { get; set; }
        [DefaultValue(206)] public double Temperature_of_the_the_heated_medium_at_The_outlet_1 { get; set; }

        [DefaultValue(0.95)] public double Popravka_na_chair_radov_pipes_2 { get; set; }
        [DefaultValue(628)] public double Temperature_of_outcoming_gases_2 { get; set; }
        [DefaultValue(3.17)] public double Cross_sectional_area_for_passage_of_combustion_products_2 { get; set; }
        [DefaultValue(43.5)] public double Estimated_heating_surface_area_2 { get; set; }
        [DefaultValue(0.032)] public double Pipe_diametr_2 { get; set; }
        [DefaultValue(0.086)] public double Transverse_pitch_of_pipe_2 { get; set; }
        [DefaultValue(0.07)] public double Longitudinal_pitch_of_pipes_2 { get; set; }
        [DefaultValue(8)] public double Number_of_pipe_rows_2 { get; set; }
        [DefaultValue(206)] public double Temperature_of_the_the_heated_medium_at_The_inlet_2 { get; set; }
        [DefaultValue(375)] public double Temperature_of_the_the_heated_medium_at_The_outlet_2 { get; set; }

        [DefaultValue(1)] public double Popravka_na_chair_radov_pipes_3 { get; set; }
        [DefaultValue(310.6)] public double Temperature_of_outcoming_gases_3 { get; set; }
        [DefaultValue(9.51)] public double Cross_sectional_area_for_passage_of_combustion_products_3 { get; set; }
        [DefaultValue(432)] public double Estimated_heating_surface_area_3 { get; set; }
        //[DefaultValue(0)] public double Thermal_resistance_of_deposits_on_pipes { get; set; } 
        [DefaultValue(0.032)] public double Pipe_diametr_3 { get; set; }
        [DefaultValue(0.086)] public double Transverse_pitch_of_pipe_3 { get; set; }
        [DefaultValue(0.07)] public double Longitudinal_pitch_of_pipes_3 { get; set; }
        [DefaultValue(22)] public double Number_of_pipe_rows_3 { get; set; }
        [DefaultValue(206)] public double Temperature_of_the_the_heated_medium_at_The_inlet_3 { get; set; }
        [DefaultValue(206)] public double Temperature_of_the_the_heated_medium_at_The_outlet_3 { get; set; }

        [DefaultValue(0.99)] public double Popravka_na_chair_radov_pipes_4 { get; set; }
        [DefaultValue(231)] public double Temperature_of_outcoming_gases_4 { get; set; }
        [DefaultValue(3.18)] public double Cross_sectional_area_for_passage_of_combustion_products_4 { get; set; }
        [DefaultValue(185)] public double Estimated_heating_surface_area_4 { get; set; }
        [DefaultValue(0.032)] public double Pipe_diametr_4 { get; set; }
        [DefaultValue(0.09)] public double Transverse_pitch_of_pipe_4 { get; set; }
        [DefaultValue(0.07)] public double Longitudinal_pitch_of_pipes_4 { get; set; }
        [DefaultValue(20)] public double Number_of_pipe_rows_4 { get; set; }
        [DefaultValue(100)] public double Temperature_of_the_the_heated_medium_at_The_inlet_4 { get; set; }
        [DefaultValue(206)] public double Temperature_of_the_the_heated_medium_at_The_outlet_4 { get; set; }

    }
}