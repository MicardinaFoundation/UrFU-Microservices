using static System.Collections.Specialized.BitVector32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KotelUtilizatorLibrary
{
    public class MathLibExample
    {
        [DefaultValue(10)] public double Co2 {  get; set; }
        [DefaultValue(15)] public double H2o { get; set; } 
        [DefaultValue(70)] public double N2 { get; set; } 
        [DefaultValue(5)] public double O2 { get; set; } 
        [DefaultValue(40000)] public double Gaz_used { get; set; } 
        [DefaultValue(1.8)] public double Presure_putten_par { get; set; } 
        [DefaultValue(100)] public double Temperature_eaten_water { get; set; } 
        [DefaultValue(375)] public double Temperature_arrive_smoke { get; set; } 
        [DefaultValue(0.1)] public double Proportion_of_intake_air { get; set; } 
        [DefaultValue(0)] public double Thermal_resistance_of_deposits_on_pipes { get; set; } 
        [DefaultValue(5.67)] public double The_emission_coefficient_of_a_completely_black_body { get; set; } 
        [DefaultValue(0.8)] public double The_degree_of_blackness_of_the_walls_of_the_tube_package { get; set; } 
        [DefaultValue(0.9)] public double Heat_preservation_coefficient { get; set; }
        [DefaultValue(10)] public double Purge_n { get; set; } 

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

    /// <summary>
    /// Математическая библиотека Котла утилизатора
    /// </summary>
    public class MathLib
    {
        //private List<Nsi_Data nsi_Data;

        //public Nsi_Data Nsi_Data
        //{
        //    get { return nsi_Data; }
        //    set { nsi_Data = value; }
        //}

        #region - Состав дымовых газов -
        /// <summary>
        /// Углекислый газ %
        /// </summary>
        private double co2;
        /// <summary>
        /// Углекислый газ %
        /// </summary>
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

        #region - Расчётные данные -

        /// <summary>
        /// Средняя тепмература в секции
        /// </summary>
        private double aver_temperature_section;
        /// <summary>
        /// Средняя тепмература в секции
        /// </summary>
        public double Aver_temperature_section()
        {
            aver_temperature_section = (temperature_of_outcoming_gases + temperature_of_incoming_gases) / 2;
            return aver_temperature_section;
        }

        /// <summary>
        /// Число Прандтля
        /// </summary>
        private double prandle_number;
        /// <summary>
        /// Число Прандтля
        /// </summary>
        public double Prandle_number()
        {
            prandle_number = 0.00000008 * Math.Pow(aver_temperature_section, 2) + 0.0002 * aver_temperature_section + 0.7127;
            return prandle_number;
        }

        /// <summary>
        /// Коеффициент теплопроводности
        /// </summary>
        private double coef_of_thermal_conductivity;
        /// <summary>
        /// Коеффициент теплопроводности
        /// </summary>
        public double Coef_of_thermal_conductivity()
        {
            coef_of_thermal_conductivity = 0.00009 * aver_temperature_section + 0.0227;
            return coef_of_thermal_conductivity;
        }

        /// <summary>
        /// Коеффициент кинематической вязкости
        /// </summary>
        private double coef_of_kinematic_viscosity;
        /// <summary>
        /// Коеффициент кинематической вязкости
        /// </summary>
        public double Coef_of_kinematic_viscosity()
        {
            coef_of_kinematic_viscosity = 0.00000000007 * Math.Pow(aver_temperature_section, 2) + 0.0000001 * aver_temperature_section + 0.00001;
            return coef_of_kinematic_viscosity;
        }

        /// <summary>
        /// Расход газа при н.у.
        /// </summary>
        private double gaz_used_n_u;
        /// <summary>
        /// Расход газа при н.у.
        /// </summary>
        public double Gaz_used_n_u()
        {
            gaz_used_n_u = gaz_used / 3600;
            return gaz_used_n_u;
        }

        /// <summary>
        /// Расход газа с учетом подсоса
        /// </summary>
        private double gaz_used_podsos;
        /// <summary>
        /// Расход газа с учетом подсоса
        /// </summary>
        public double Gaz_used_podsos()
        {
            gaz_used_podsos = Gaz_used_n_u() * (1 + 0.5 * proportion_of_intake_air);
            return gaz_used_podsos;
        }

        /// <summary>
        /// Действительный расход дымовых газов
        /// </summary>
        private double actual_flue_gas_consumption;
        /// <summary>
        /// Действительный расход дымовых газов
        /// </summary>
        public double Actual_flue_gas_consumption()
        {
            actual_flue_gas_consumption = gaz_used_podsos * (1 + (aver_temperature_section / 273));
            return actual_flue_gas_consumption;
        }

        /// <summary>
        /// Средняя скорость дымовых газов
        /// </summary>
        private double aver_smok_gaz_speed;
        /// <summary>
        /// Средняя скорость дымовых газов
        /// </summary>
        public double Aver_smok_gaz_speed()
        {
            aver_smok_gaz_speed = actual_flue_gas_consumption / cross_sectional_area_for_passage_of_combustion_products;
            return aver_smok_gaz_speed;
        }

        /// <summary>
        /// Диагональный шаг труб
        /// </summary>
        private double diagonal_pipe_step;
        /// <summary>
        /// Диагональный шаг труб
        /// </summary>
        public double Diagonal_pipe_step()
        {
            diagonal_pipe_step = Math.Pow(0.25 * transverse_pitch_of_pipes + longitudinal_pitch_of_pipes, 0.5);
            return diagonal_pipe_step;
        }

        /// <summary>
        /// Параметр p
        /// </summary>
        private double p_parametr;
        /// <summary>
        /// Параметр p
        /// </summary>
        public double P_parametr()
        {
            p_parametr = (transverse_pitch_of_pipes - pipe_diametr) / (diagonal_pipe_step - pipe_diametr);
            return p_parametr;
        }

        /// <summary>
        /// Конвективный коэффициент теплопередачи
        /// </summary>
        private double convective_coef_thermosender;
        /// <summary>
        /// Конвективный коэффициент теплопередачи
        /// </summary>
        public double Convective_coef_thermosender()
        {
            convective_coef_thermosender = 0.305 * popravka_na_chislo_radov_pipes * (coef_of_thermal_conductivity * Math.Pow(prandle_number, 0.35) / Math.Pow(pipe_diametr, 0.4)) * Math.Pow(aver_smok_gaz_speed / coef_of_kinematic_viscosity, 0.6);
            return convective_coef_thermosender;
        }

        /// <summary>
        /// Параметр ps
        /// </summary>
        private double ps_parametr;
        /// <summary>
        /// Параметр ps
        /// </summary>
        public double Ps_parametr()
        {
            ps_parametr = (transverse_pitch_of_pipes + longitudinal_pitch_of_pipes) / pipe_diametr;
            return ps_parametr;
        }

        /// <summary>
        /// Парциональное давление H2O
        /// </summary>
        private double parti_presure_h2o;
        /// <summary>
        /// Парциональное давление H2O
        /// </summary>
        public double Parti_presure_h2o()
        {
            parti_presure_h2o = h2o / 100;
            return parti_presure_h2o;
        }

        /// <summary>
        /// Парциональное давление CO2
        /// </summary>
        private double parti_presure_co2;
        /// <summary>
        /// Парциональное давление CO2
        /// </summary>
        public double Parti_presure_co2()
        {
            parti_presure_co2 = co2 / 100;
            return parti_presure_co2;
        }

        /// <summary>
        /// Эффективная толщина излучающего слоя Sэф
        /// </summary>
        private double effective_thickness_emission_layer;
        /// <summary>
        /// Эффективная толщина излучающего слоя Sэф
        /// </summary>
        public double Effective_thickness_emission_layer()
        {
            effective_thickness_emission_layer = (2.82 * ps_parametr - 10.6) * pipe_diametr;
            return effective_thickness_emission_layer;
        }

        /// <summary>
        /// Температура наружной поверхности стенки Tст
        /// </summary>
        private double temperature_outside_cover;
        /// <summary>
        /// Температура наружной поверхности стенки Tст
        /// </summary>
        public double Temperature_outside_cover()
        {
            temperature_outside_cover = temperature_of_the_heated_medium_at_the_outlet + 273.15;
            return temperature_outside_cover;
        }

        /// <summary>
        /// Средняя температура дымовых газов Tср
        /// </summary>
        private double aver_temperature_smoke_gaz;
        /// <summary>
        /// Средняя температура дымовых газов Tср
        /// </summary>
        public double Aver_temperature_smoke_gaz()
        {
            aver_temperature_smoke_gaz = aver_temperature_section + 273.15;
            return aver_temperature_smoke_gaz;
        }

        /// <summary>
        /// Спектральный коэффициент ослабления K1
        /// </summary>
        private double spektr_coeff_lower1;
        /// <summary>
        /// Спектральный коэффициент ослабления K1
        /// </summary>
        public double Spektr_coeff_lower1()
        {
            spektr_coeff_lower1 = (0.8 + 1.6 * parti_presure_h2o) * (1 - 0.00038 * aver_temperature_smoke_gaz) / Math.Pow((parti_presure_h2o + parti_presure_co2) * effective_thickness_emission_layer, 0.5);
            return spektr_coeff_lower1;
        }

        /// <summary>
        /// Спектральный коэффициент ослабления K2
        /// </summary>
        private double spektr_coeff_lower2;
        /// <summary>
        /// Спектральный коэффициент ослабления K2
        /// </summary>
        public double Spektr_coeff_lower2()
        {
            spektr_coeff_lower2 = (0.8 + 1.6 * parti_presure_h2o) * (1 - 0.00038 * temperature_outside_cover) / Math.Pow((parti_presure_h2o + parti_presure_co2) * effective_thickness_emission_layer, 0.5);
            return spektr_coeff_lower2;
        }

        /// <summary>
        /// Степень черноты дымовых газов εд
        /// </summary>
        private double degree_blackness_smokness_gazez;
        /// <summary>
        /// Степень черноты дымовых газов εд
        /// </summary>
        public double Degree_blackness_smokness_gazez()
        {
            degree_blackness_smokness_gazez = 1 - Math.Exp(-spektr_coeff_lower1 * (parti_presure_h2o + parti_presure_co2) * effective_thickness_emission_layer);
            return degree_blackness_smokness_gazez;
        }

        /// <summary>
        /// Коэффициент поглощаения αд
        /// </summary>
        private double absorption_coeff;
        /// <summary>
        /// Коэффициент поглощаения αд
        /// </summary>
        public double Absorption_coeff()
        {
            absorption_coeff = 1 - Math.Exp(-spektr_coeff_lower2 * (parti_presure_h2o + parti_presure_co2) * effective_thickness_emission_layer);
            return absorption_coeff;
        }

        /// <summary>
        /// Cпр
        /// </summary>
        private double c_pr;
        /// <summary>
        /// Cпр
        /// </summary>
        public double C_pr()
        {
            c_pr = the_emission_coefficient_of_a_completely_black_body / (1 / the_degree_of_blackness_of_the_walls_of_the_tube_package + (1 / absorption_coeff) - 1);
            return c_pr;
        }

        /// <summary>
        /// Коэффициент теплоотдачи излучением, αдл
        /// </summary>
        private double coeff_heat_transfer_by_emmision;
        /// <summary>
        /// Коэффициент теплоотдачи излучением, αдл
        /// </summary>
        public double Coeff_heat_transfer_by_emmision()
        {
            coeff_heat_transfer_by_emmision = c_pr * ((degree_blackness_smokness_gazez / absorption_coeff) * Math.Pow(aver_temperature_smoke_gaz / 100, 4) - Math.Pow(temperature_outside_cover / 100, 4)) / (aver_temperature_smoke_gaz - temperature_outside_cover);
            return coeff_heat_transfer_by_emmision;
        }

        /// <summary>
        /// Суммарный коэффициент теплоотдачи от продуктов, αд
        /// </summary>
        private double total_heat_coeff_from_products;
        /// <summary>
        /// Суммарный коэффициент теплоотдачи от продуктов, αд
        /// </summary>
        public double Total_heat_coeff_from_products()
        {
            total_heat_coeff_from_products = convective_coef_thermosender + coeff_heat_transfer_by_emmision;
            return total_heat_coeff_from_products;
        }

        /// <summary>
        /// Разность температур начальная, ∆tн
        /// </summary>
        private double initial_temperature_difference;
        /// <summary>
        /// Разность температур начальная, ∆tн
        /// </summary>
        public double Initial_temperature_difference()
        {
            initial_temperature_difference = temperature_of_incoming_gases - temperature_of_the_heated_medium_at_the_inlet;
            return initial_temperature_difference;
        }

        /// <summary>
        /// Разность температур конечная, ∆tк
        /// </summary>
        private double finitial_temperature_difference;
        /// <summary>
        /// Разность температур конечная, ∆tк
        /// </summary>
        public double Finitial_temperature_difference()
        {
            finitial_temperature_difference = temperature_of_outcoming_gases - temperature_of_the_heated_medium_at_the_outlet;
            return finitial_temperature_difference;
        }

        /// <summary>
        /// Коэффициент теплоотдачи к нагреваемой среде и обратный
        /// </summary>
        private double coeff_thermal_transfer_heating_env;
        /// <summary>
        /// Коэффициент теплоотдачи к нагреваемой среде и обратный
        /// </summary>
        public double Coeff_thermal_transfer_heating_env(bool isOn)
        {
            if (isOn)
            {
                coeff_thermal_transfer_heating_env = 1 / (164.29 * presure_putten_par + 61.429);
            }
            else
            {
                coeff_thermal_transfer_heating_env = 0;
            }

            return coeff_thermal_transfer_heating_env;
        }

        /// <summary>
        /// Коэффициент теплопередачи, k
        /// </summary>
        private double coeff_heat_transfer;
        /// <summary>
        /// Коэффициент теплопередачи, k
        /// </summary>
        public double Coeff_heat_transfer()
        {
            coeff_heat_transfer = 1 / (1 / total_heat_coeff_from_products + thermal_resistance_of_deposits_on_pipes + coeff_thermal_transfer_heating_env);
            return coeff_heat_transfer;
        }

        /// <summary>
        /// Среднелогарифмическая разность температур
        /// </summary>
        private double averlogarifmic_thermal_difference;
        /// <summary>
        /// Среднелогарифмическая разность температур
        /// </summary>
        public double Averlogarifmic_thermal_difference()
        {
            averlogarifmic_thermal_difference = (initial_temperature_difference - finitial_temperature_difference) / (Math.Log(initial_temperature_difference / finitial_temperature_difference));
            return averlogarifmic_thermal_difference;
        }

        /// <summary>
        /// Количество тепла, переданное газами
        /// </summary>
        private double thermal_total_gazes_transfer;
        /// <summary>
        /// Количество тепла, переданное газами
        /// </summary>
        public double Thermal_total_gazes_transfer()
        {
            thermal_total_gazes_transfer = coeff_heat_transfer * estimated_heating_surface_area * averlogarifmic_thermal_difference / 1000;
            return thermal_total_gazes_transfer;
        }

        /// <summary>
        /// Теоретическая энтальпия входящих газов
        /// </summary>
        private double incoming_entalpia_gazes;
        /// <summary>
        /// Теоретическая энтальпия входящих газов
        /// </summary>
        public double Incoming_entalpia_gazes()
        {
            incoming_entalpia_gazes = 0.0002 * Math.Pow(temperature_of_incoming_gases, 2) + 1.338 * temperature_of_incoming_gases + 1.9992;
            return incoming_entalpia_gazes;
        }

        /// <summary>
        /// Теоретическая энтальпия выходящих газов
        /// </summary>
        private double outcoming_entalpia_gazes;
        /// <summary>
        /// Теоретическая энтальпия выходящих газов
        /// </summary>
        public double Outcoming_entalpia_gazes()
        {
            outcoming_entalpia_gazes = 0.0002 * Math.Pow(temperature_of_outcoming_gases, 2) + 1.338 * temperature_of_outcoming_gases + 1.9992;
            return outcoming_entalpia_gazes;
        }

        /// <summary>
        /// Расчетная энтальпия iд''
        /// </summary>
        private double calculated_entalpia_from_thermal_total;
        /// <summary>
        /// Расчетная энтальпия iд''
        /// </summary>
        public double Calculated_entalpia_from_thermal_total()
        {
            calculated_entalpia_from_thermal_total = incoming_entalpia_gazes - thermal_total_gazes_transfer / (gaz_used_podsos * heat_preservation_coefficient);
            return calculated_entalpia_from_thermal_total;
        }
        #endregion

        #region - Расчётные данные паропроизводительности -

        /// <summary>
        /// Количество теплоты, переданное воде и пару
        /// </summary>
        private double thermal_count_transfered_water_and_steam;
        /// <summary>
        /// Количество теплоты, переданное воде и пару
        /// </summary>
        /// <param name="inlet">Значение энтальпии входящих газов в секции предвключенного испарительного пакета</param>
        /// <returns></returns>
        public double Thermal_count_transfered_water_and_par(double inlet)
        {
            thermal_count_transfered_water_and_steam = gaz_used_podsos * ((inlet != 0 ? inlet : incoming_entalpia_gazes) - outcoming_entalpia_gazes) * heat_preservation_coefficient;
            return thermal_count_transfered_water_and_steam;
        }

        /// <summary>
        /// Количество тепла, переданное в пароперегревателе
        /// </summary>
        private double thermal_count_transfered_in_paroperegrevatel;
        /// <summary>
        /// Количество тепла, переданное в пароперегревателе
        /// </summary>
        /// <param name="inlet">Значение энтальпии входящих газов в пароперегревателе</param>
        /// <param name="outlet">Значение энтальпии выходящих газов в пароперегревателе</param>
        /// <returns></returns>
        public double Thermal_count_transfered_in_paroperegrevatel(double inlet, double outlet)
        {
            thermal_count_transfered_in_paroperegrevatel = gaz_used_n_u * ((inlet != 0 ? inlet : incoming_entalpia_gazes) - (outlet != 0 ? outlet : incoming_entalpia_gazes)) * heat_preservation_coefficient;
            return thermal_count_transfered_in_paroperegrevatel;
        }

        /// <summary>
        /// Энтальпия кипящей воды
        /// </summary>
        private double entalpia_hot_water;
        /// <summary>
        /// Энтальпия кипящей воды
        /// </summary>
        /// <param name="presure">Значение давления из исходных данных</param>
        /// <returns>Если давление равно 1,8 Мпа - выведет 880,7 кДж/кг; Если давление равно 4,5 Мпа - выведет 1117,0 кДж/кг; Иначе выведет ошибку в виде числа -404</returns>
        public double Entalpia_hot_water(double presure)
        {
            entalpia_hot_water = presure == 1.8 ? 880.7 : presure == 4.5 ? 1117.0 : -333;
            return entalpia_hot_water;
        }

        /// <summary>
        /// Энтальпия питательной воды
        /// </summary>
        private double entalpia_eaten_water;
        /// <summary>
        /// Энтальпия питательной воды
        /// </summary>
        /// <param name="temp">Температура питательной воды</param>
        /// <returns></returns>
        public double Entalpia_eaten_Water(double temp, double presure)
        {
            //Получается нечистый вывод 421,1257 вместо 420,5
            //entalpia_eaten_water = 4.3104 * temp - 9.9143;

            if (presure == 1.8)
            {
                switch (temp)
                {
                    case 100:
                        entalpia_eaten_water = 420.5;
                        break;
                    case 120:
                        entalpia_eaten_water = 505.1;
                        break;
                    case 140:
                        entalpia_eaten_water = 590.5;
                        break;
                    case 160:
                        entalpia_eaten_water = 676.4;
                        break;
                    case 180:
                        entalpia_eaten_water = 764;
                        break;
                    case 200:
                        entalpia_eaten_water = 853.1;
                        break;
                }
            }
            else if (presure == 4.5)
            {
                switch (temp)
                {
                    case 100:
                        entalpia_eaten_water = 422.9;
                        break;
                    case 120:
                        entalpia_eaten_water = 507;
                        break;
                    case 140:
                        entalpia_eaten_water = 592.3;
                        break;
                    case 160:
                        entalpia_eaten_water = 678.2;
                        break;
                    case 180:
                        entalpia_eaten_water = 765.3;
                        break;
                    case 200:
                        entalpia_eaten_water = 854.2;
                        break;
                }
            }
            else { entalpia_eaten_water = 0; }
            return entalpia_eaten_water;
        }

        /// <summary>
        /// Энтальпия кипящей воды
        /// </summary>
        private double entalpia_saturated_dry_steam;
        /// <summary>
        /// Энтальпия кипящей воды
        /// </summary>
        /// <param name="presure">Значение давления из исходных данных</param>
        /// <returns>Если давление равно 1,8 Мпа - выведет 2797 кДж/кг; Если давление равно 4,5 Мпа - выведет 2800 кДж/кг; Иначе выведет ошибку в виде числа -404</returns>
        public double Entalpia_saturated_dry_steam(double presure)
        {
            entalpia_saturated_dry_steam = presure == 1.8 ? 2797 : presure == 4.5 ? 2800 : -333;
            return entalpia_saturated_dry_steam;
        }

        /// <summary>
        /// Расчетная энтальпия перегретого пара
        /// </summary>
        private double calculated_entalpia_hotest_steam;
        /// <summary>
        /// Расчетная энтальпия перегретого пара
        /// </summary>
        /// <returns></returns>
        public double Calculated_entalpia_hotest_steam()
        {
            calculated_entalpia_hotest_steam = (thermal_count_transfered_water_and_steam * entalpia_saturated_dry_steam - thermal_count_transfered_in_paroperegrevatel * (entalpia_eaten_water - 0.01 * purge_n * (entalpia_hot_water - entalpia_eaten_water))) / (thermal_count_transfered_water_and_steam - thermal_count_transfered_in_paroperegrevatel);
            return calculated_entalpia_hotest_steam;
        }

        /// <summary>
        /// Теоретическая энтальпия перегретого пара
        /// </summary>
        private double calculated_theoretic_entalpia_hotest_steam;
        /// <summary>
        /// Теоретическая энтальпия перегретого пара
        /// </summary>
        /// <param name="presure">Значение давления из исходных данных</param>
        /// <param name="temperature">Температура нагреваемой среды на выходе = f(P) из секции пароперегревателя</param>
        /// <returns>Если давление не равно 1,8 Мпа или 4,5 Мпа - выведет вместо ответа ошибку в виде числа -404</returns>
        public double Calculated_theoretic_entalpia_hotest_steam(double presure, double temperature)
        {
            if (presure != 1.8 && presure != 4.5)
            {
                calculated_theoretic_entalpia_hotest_steam = -404;
                return calculated_theoretic_entalpia_hotest_steam;
            }
            else
            {
                if (presure == 1.8)
                {
                    calculated_theoretic_entalpia_hotest_steam = 2.2054 * temperature + 2372.1;
                    return calculated_theoretic_entalpia_hotest_steam;
                }
                else
                {
                    calculated_theoretic_entalpia_hotest_steam = 2.5149 * temperature + 2200.9;
                    return calculated_theoretic_entalpia_hotest_steam;
                }
            }
        }

        /// <summary>
        /// Паропроизводительность
        /// </summary>
        private double steam_capicity;
        /// <summary>
        /// Паропроизводительность
        /// </summary>
        /// <returns></returns>
        public double Steam_capacity()
        {
            steam_capicity = thermal_count_transfered_in_paroperegrevatel / (calculated_entalpia_hotest_steam - entalpia_saturated_dry_steam);
            return steam_capicity;
        }

        /// <summary>
        /// Расхождение процентное
        /// </summary>
        private double percentage_discrepancy;
        /// <summary>
        /// Расхождение процентное
        /// </summary>
        /// <returns></returns>
        public double Percentage_discrepancy()
        {
            percentage_discrepancy = 100 * (calculated_entalpia_hotest_steam - calculated_theoretic_entalpia_hotest_steam) / calculated_entalpia_hotest_steam;
            return percentage_discrepancy;
        }
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

    }

    /// <summary>
    /// Вспомогательный класс для данных из нескольких листов
    /// </summary>
    public class Nsi_Data
    {
        /// <summary>
        /// Температура входящих газов
        /// </summary>
        public double Temperature_of_incoming_gases { get; set; }

        /// <summary>
        /// Поправка на число рядов труб Cz
        /// </summary>
        public double Popravka_na_chair_radov_pipes { get; set; }

        /// <summary>
        /// Температура отходящих газов
        /// </summary>
        public double Temperature_of_outcoming_gases { get; set; }

        /// <summary>
        /// Площадь сечения для прохода продуктов сгорания
        /// </summary>
        public double Cross_sectional_area_for_passage_of_combustion_products { get; set; }

        /// <summary>
        /// Расчетная площадь поверхности нагрева
        /// </summary>
        public double Estimated_heating_surface_area { get; set; }

        /// <summary>
        /// Диаметр труб
        /// </summary>
        public double Pipe_diametr { get; set; }

        /// <summary>
        /// Поперечный шаг труб S1
        /// </summary>
        public double Transverse_pitch_of_pipe { get; set; }

        /// <summary>
        /// Продольный шаг труб S2
        /// </summary>
        public double Longitudinal_pitch_of_pipes { get; set; }

        /// <summary>
        /// Количество рядов труб по ходу продуктов сгорания
        /// </summary>
        public double Number_of_pipe_rows { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на входе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_inlet { get; set; }

        /// <summary>
        /// Температура нагреваемой среды на выходе
        /// </summary>
        public double Temperature_of_the_the_heated_medium_at_The_outlet { get; set; }

    }



    public class Combiners
    {
        public class ValueDiary()
        {
            public string caption;
            public int index;
            public class Input()
            {
                public double temperature_of_incoming_gases;
                public double popravka_na_chair_radov_pipes;
                public double temperature_of_outcoming_gases;
                public double cross_sectional_area_for_passage_of_combustion_products;
                public double estimated_heating_surface_area;
                public double pipe_diametr;
                public double transverse_pitch_of_pipe;
                public double longitudinal_pitch_of_pipes;
                public double number_of_pipe_rows;
                public double temperature_of_the_the_heated_medium_at_The_inlet;
                public double temperature_of_the_the_heated_medium_at_The_outlet;

            }
            public Input inputVal;
            public class Output()
            {
                public double aver_temperature_section;
                public double gaz_used_n_u;
                public double gaz_used_podsos;
                public double actual_flue_gas_consumption;
                public double aver_smok_gaz_speed;

                public double initial_temperature_difference;
                public double finitial_temperature_difference;
                public double averlogarifmic_thermal_difference;

                public double diagonal_pipe_step;
                public double p_parametr;
                //public double averlogarifmic_thermal_difference = Readpublic double("ПИП", 17, rowWork);
                public double prandle_number;
                public double coef_of_thermal_conductivity;
                public double coef_of_kinematic_viscosity;
                public double convective_coef_thermosender;

                public double ps_parametr;
                public double effective_thickness_emission_layer;
                public double parti_presure_h2o;
                public double parti_presure_co2;
                public double temperature_outside_cover;
                public double aver_temperature_smoke_gaz;
                public double spektr_coeff_lower1;
                public double degree_blackness_smokness_gazez;
                public double spektr_coeff_lower2;
                public double absorption_coeff;
                public double c_pr;
                public double coeff_heat_transfer_by_emmision;
                public double total_heat_coeff_from_products;
                public double coeff_thermal_transfer_heating_env;
                public double coeff_heat_transfer;
                public double thermal_total_gazes_transfer;

                public double incoming_entalpia_gazes;
                public double outcoming_entalpia_gazes;
                public double calculated_entalpia_from_thermal_total;
            }

            public Output outputCodeVal;

        }

        public List<ValueDiary> Diary = new List<ValueDiary>();

        public class SteamRun()
        {
            public double thermal_count_transfered_water_and_steam;
            public double thermal_count_transfered_in_paroperegrevatel;
            public double entalpia_hot_water;
            public double entalpia_eaten_water;
            public double entalpia_saturated_dry_steam;
            public double calculated_entalpia_hotest_steam;
            public double calculated_theoretic_entalpia_hotest_steam;
            public double percentage_discrepancy;
            public double steam_capicity;
        }
        public SteamRun SteamValue = new SteamRun();

        public List<ValueDiary> Diarys;
        public SteamRun SteamRunResults;
    }
}

