using KotelUtilizatorLibrary;
using KotelUtilizatorLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace RecuperatorCore.Models
{
    public class DataOtherLists
    {

        public double Temperature_of_incoming_gases;
        public double Popravka_na_chair_radov_pipes;
        public double Temperature_of_outcoming_gases;
        public double Cross_sectional_area_for_passage_of_combustion_products;
        public double Estimated_heating_surface_area;
        public double Pipe_diametr;
        public double Transverse_pitch_of_pipe;
        public double Longitudinal_pitch_of_pipes;
        public double Number_of_pipe_rows;
    }

    public class DataOutputModel
    {
        public MathLib _cs = new MathLib();
        private DataInputModel _dataInput = new DataInputModel();
        private List<DataOtherLists> DataOtherLists;
        private readonly RecuperatorService _service;

        public DataOutputModel(RecuperatorService recuperator) 
        {
            _service = recuperator;
        }

        public class ValueDiary()
        {
            public string caption;
            public int index;
            public class Input()
            {
                public double temperature_of_incoming_gases{ get; set; }
                public double popravka_na_chair_radov_pipes{ get; set; }
                public double temperature_of_outcoming_gases{ get; set; }
                public double cross_sectional_area_for_passage_of_combustion_products{ get; set; }
                public double estimated_heating_surface_area{ get; set; }
                public double pipe_diametr{ get; set; }
                public double transverse_pitch_of_pipe{ get; set; }
                public double longitudinal_pitch_of_pipes{ get; set; }
                public double number_of_pipe_rows{ get; set; }
                public double temperature_of_the_the_heated_medium_at_The_inlet{ get; set; }
                public double temperature_of_the_the_heated_medium_at_The_outlet{ get; set; }

            }
            public Input inputVal { get; set; }
            public class Output()
            {
                public double aver_temperature_section{ get; set; }
                public double gaz_used_n_u{ get; set; }
                public double gaz_used_podsos{ get; set; }
                public double actual_flue_gas_consumption{ get; set; }
                public double aver_smok_gaz_speed{ get; set; }

                public double initial_temperature_difference{ get; set; }
                public double finitial_temperature_difference{ get; set; }
                public double averlogarifmic_thermal_difference{ get; set; }

                public double diagonal_pipe_step{ get; set; }
                public double p_parametr{ get; set; }
                //public double averlogarifmic_thermal_difference = Readpublic double("ПИП", 17, rowWork){ get; set; }
                public double prandle_number{ get; set; }
                public double coef_of_thermal_conductivity{ get; set; }
                public double coef_of_kinematic_viscosity{ get; set; }
                public double convective_coef_thermosender{ get; set; }

                public double ps_parametr{ get; set; }
                public double effective_thickness_emission_layer{ get; set; }
                public double parti_presure_h2o{ get; set; }
                public double parti_presure_co2{ get; set; }
                public double temperature_outside_cover{ get; set; }
                public double aver_temperature_smoke_gaz{ get; set; }
                public double spektr_coeff_lower1{ get; set; }
                public double degree_blackness_smokness_gazez{ get; set; }
                public double spektr_coeff_lower2{ get; set; }
                public double absorption_coeff{ get; set; }
                public double c_pr{ get; set; }
                public double coeff_heat_transfer_by_emmision{ get; set; }
                public double total_heat_coeff_from_products{ get; set; }
                public double coeff_thermal_transfer_heating_env{ get; set; }
                public double coeff_heat_transfer{ get; set; }
                public double thermal_total_gazes_transfer{ get; set; }

                public double incoming_entalpia_gazes{ get; set; }
                public double outcoming_entalpia_gazes{ get; set; }
                public double calculated_entalpia_from_thermal_total{ get; set; }
            }

            public Output outputCodeVal { get; set; }

        }

        public List<ValueDiary> Diary = new List<ValueDiary>();

        public class SteamRun()
        {
            public double thermal_count_transfered_water_and_steam { get; set; }
            public double thermal_count_transfered_in_paroperegrevatel { get; set; }
            public double entalpia_hot_water { get; set; }
            public double entalpia_eaten_water { get; set; }
            public double entalpia_saturated_dry_steam { get; set; }
            public double calculated_entalpia_hotest_steam { get; set; }
            public double calculated_theoretic_entalpia_hotest_steam { get; set; }
            public double percentage_discrepancy { get; set; }
            public double steam_capicity { get; set; }
        }
        public SteamRun SteamValue = new SteamRun();


        void WriteValue(int indexList)
        {
            _cs.Temperature_of_incoming_gases = Diary[indexList].inputVal.temperature_of_incoming_gases;
            _cs.Popravka_na_chair_radov_pipes = Diary[indexList].inputVal.popravka_na_chair_radov_pipes;
            _cs.Temperature_of_outcoming_gases = Diary[indexList].inputVal.temperature_of_outcoming_gases;
            _cs.Cross_sectional_area_for_passage_of_combustion_products = Diary[indexList].inputVal.cross_sectional_area_for_passage_of_combustion_products;
            _cs.Estimated_heating_surface_area = Diary[indexList].inputVal.estimated_heating_surface_area;
            _cs.Pipe_diametr = Diary[indexList].inputVal.pipe_diametr;
            _cs.Transverse_pitch_of_pipe = Diary[indexList].inputVal.transverse_pitch_of_pipe;
            _cs.Longitudinal_pitch_of_pipes = Diary[indexList].inputVal.longitudinal_pitch_of_pipes;
            _cs.Number_of_pipe_rows = Diary[indexList].inputVal.number_of_pipe_rows;
            _cs.Temperature_of_the_the_heated_medium_at_The_inlet = Diary[indexList].inputVal.temperature_of_the_the_heated_medium_at_The_inlet;
            _cs.Temperature_of_the_the_heated_medium_at_The_outlet = Diary[indexList].inputVal.temperature_of_the_the_heated_medium_at_The_outlet;
            int rowWork = 6;
            if (indexList != 1)
            {
                var ca = Diary.Find(c => c.index == indexList);
                ca.outputCodeVal = new ValueDiary.Output()
                {
                    aver_temperature_section = _cs.Aver_temperature_section(),
                    gaz_used_n_u = _cs.Gaz_used_n_u(),
                    gaz_used_podsos = _cs.Gaz_used_podsos(),
                    actual_flue_gas_consumption = _cs.Actual_flue_gas_consumption(),
                    aver_smok_gaz_speed = _cs.Aver_smok_gaz_speed(),

                    initial_temperature_difference = _cs.Initial_temperature_difference(),
                    finitial_temperature_difference = _cs.Finitial_temperature_difference(),
                    averlogarifmic_thermal_difference = _cs.Averlogarifmic_thermal_difference(),

                    diagonal_pipe_step = _cs.Diagonal_pipe_step(),
                    p_parametr = _cs.P_parametr(),
                    //averlogarifmic_thermal_difference = ReadDouble(keyList, 17, rowWork),
                    prandle_number = _cs.Prandle_number(),
                    coef_of_thermal_conductivity = _cs.Coef_of_thermal_conductivity(),
                    coef_of_kinematic_viscosity = _cs.Coef_of_kinematic_viscosity(),
                    convective_coef_thermosender = _cs.Convective_coef_thermosender(),

                    ps_parametr = _cs.Ps_parametr(),
                    effective_thickness_emission_layer = _cs.Effective_thickness_emission_layer(),
                    parti_presure_h2o = _cs.Parti_presure_h2o(),
                    parti_presure_co2 = _cs.Parti_presure_co2(),
                    temperature_outside_cover = _cs.Temperature_outside_cover(),
                    aver_temperature_smoke_gaz = _cs.Aver_temperature_smoke_gaz(),
                    spektr_coeff_lower1 = _cs.Spektr_coeff_lower1(),
                    degree_blackness_smokness_gazez = _cs.Degree_blackness_smokness_gazez(),
                    spektr_coeff_lower2 = _cs.Spektr_coeff_lower2(),
                    absorption_coeff = _cs.Absorption_coeff(),
                    c_pr = _cs.C_pr(),
                    coeff_heat_transfer_by_emmision = _cs.Coeff_heat_transfer_by_emmision(),
                    total_heat_coeff_from_products = _cs.Total_heat_coeff_from_products(),
                    coeff_thermal_transfer_heating_env = _cs.Coeff_thermal_transfer_heating_env(false),
                    coeff_heat_transfer = _cs.Coeff_heat_transfer(),
                    thermal_total_gazes_transfer = _cs.Thermal_total_gazes_transfer(),

                    incoming_entalpia_gazes = _cs.Incoming_entalpia_gazes(),
                    outcoming_entalpia_gazes = _cs.Outcoming_entalpia_gazes(),
                    calculated_entalpia_from_thermal_total = _cs.Calculated_entalpia_from_thermal_total(),

                };
            }
            else
            {
                var ca = Diary.Find(c => c.index == indexList);
                ca.outputCodeVal = new ValueDiary.Output()
                {
                    aver_temperature_section = _cs.Aver_temperature_section(),
                    gaz_used_n_u = _cs.Gaz_used_n_u(),
                    gaz_used_podsos = _cs.Gaz_used_podsos(),
                    actual_flue_gas_consumption = _cs.Actual_flue_gas_consumption(),
                    aver_smok_gaz_speed = _cs.Aver_smok_gaz_speed(),

                    initial_temperature_difference = _cs.Initial_temperature_difference(),
                    finitial_temperature_difference = _cs.Finitial_temperature_difference(),
                    averlogarifmic_thermal_difference = _cs.Averlogarifmic_thermal_difference(),

                    diagonal_pipe_step = _cs.Diagonal_pipe_step(),
                    p_parametr = _cs.P_parametr(),
                    //averlogarifmic_thermal_difference = ReadDouble(keyList, 17, rowWork),
                    prandle_number = _cs.Prandle_number(),
                    coef_of_thermal_conductivity = _cs.Coef_of_thermal_conductivity(),
                    coef_of_kinematic_viscosity = _cs.Coef_of_kinematic_viscosity(),
                    convective_coef_thermosender = _cs.Convective_coef_thermosender(),

                    ps_parametr = _cs.Ps_parametr(),
                    effective_thickness_emission_layer = _cs.Effective_thickness_emission_layer(),
                    parti_presure_h2o = _cs.Parti_presure_h2o(),
                    parti_presure_co2 = _cs.Parti_presure_co2(),
                    temperature_outside_cover = _cs.Temperature_outside_cover(),
                    aver_temperature_smoke_gaz = _cs.Aver_temperature_smoke_gaz(),
                    spektr_coeff_lower1 = _cs.Spektr_coeff_lower1(),
                    degree_blackness_smokness_gazez = _cs.Degree_blackness_smokness_gazez(),
                    spektr_coeff_lower2 = _cs.Spektr_coeff_lower2(),
                    absorption_coeff = _cs.Absorption_coeff(),
                    c_pr = _cs.C_pr(),
                    coeff_heat_transfer_by_emmision = _cs.Coeff_heat_transfer_by_emmision(),
                    total_heat_coeff_from_products = _cs.Total_heat_coeff_from_products(),
                    coeff_thermal_transfer_heating_env = _cs.Coeff_thermal_transfer_heating_env(true),
                    coeff_heat_transfer = _cs.Coeff_heat_transfer(),
                    thermal_total_gazes_transfer = _cs.Thermal_total_gazes_transfer(),

                    incoming_entalpia_gazes = _cs.Incoming_entalpia_gazes(),
                    outcoming_entalpia_gazes = _cs.Outcoming_entalpia_gazes(),
                    calculated_entalpia_from_thermal_total = _cs.Calculated_entalpia_from_thermal_total(),

                };

            }
        }
        void PIP_Read(DataInputModel DataInput)
        {
            //string keyList = "ПИП"; 
            Diary.Add(new ValueDiary()
            {
                caption = "--- ПИП ---",
                index = 0,
                inputVal = new ValueDiary.Input()
                {
                    temperature_of_incoming_gases = DataInput.Temperature_of_incoming_gases_1,
                    popravka_na_chair_radov_pipes = DataInput.Popravka_na_chair_radov_pipes_1,
                    temperature_of_outcoming_gases = DataInput.Temperature_of_outcoming_gases_1,
                    cross_sectional_area_for_passage_of_combustion_products = DataInput.Cross_sectional_area_for_passage_of_combustion_products_1,
                    estimated_heating_surface_area = DataInput.Estimated_heating_surface_area_1,
                    pipe_diametr = DataInput.Pipe_diametr_1,
                    transverse_pitch_of_pipe = DataInput.Transverse_pitch_of_pipe_1,
                    longitudinal_pitch_of_pipes = DataInput.Longitudinal_pitch_of_pipes_1,
                    number_of_pipe_rows = DataInput.Number_of_pipe_rows_1,
                    temperature_of_the_the_heated_medium_at_The_inlet = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_1,
                    temperature_of_the_the_heated_medium_at_The_outlet = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_1,
                },
            });

        }
        void Steam_Read(DataInputModel DataInput)
        {
            //string keyList = "ПИП"; 
            Diary.Add(new ValueDiary()
            {
                caption = "--- Пароперегреватель ---",
                index = 1,
                inputVal = new ValueDiary.Input()
                {
                    temperature_of_incoming_gases = Diary[0].inputVal.temperature_of_outcoming_gases,
                    popravka_na_chair_radov_pipes = DataInput.Popravka_na_chair_radov_pipes_2,
                    temperature_of_outcoming_gases = DataInput.Temperature_of_outcoming_gases_2,
                    cross_sectional_area_for_passage_of_combustion_products = DataInput.Cross_sectional_area_for_passage_of_combustion_products_2,
                    estimated_heating_surface_area = DataInput.Estimated_heating_surface_area_2,
                    pipe_diametr = DataInput.Pipe_diametr_2,
                    transverse_pitch_of_pipe = DataInput.Transverse_pitch_of_pipe_2,
                    longitudinal_pitch_of_pipes = DataInput.Longitudinal_pitch_of_pipes_2,
                    number_of_pipe_rows = DataInput.Number_of_pipe_rows_2,
                    temperature_of_the_the_heated_medium_at_The_inlet = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_2,
                    temperature_of_the_the_heated_medium_at_The_outlet = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_2,
                },
            });

        }

        void SteamingSection_Read(DataInputModel DataInput)
        {
            Diary.Add(new ValueDiary()
            {
                caption = "--- ИС ---",
                index = 2,
                inputVal = new ValueDiary.Input()
                {
                    temperature_of_incoming_gases = Diary[1].inputVal.temperature_of_outcoming_gases,
                    popravka_na_chair_radov_pipes = DataInput.Popravka_na_chair_radov_pipes_3,
                    temperature_of_outcoming_gases = DataInput.Temperature_of_outcoming_gases_3,
                    cross_sectional_area_for_passage_of_combustion_products = DataInput.Cross_sectional_area_for_passage_of_combustion_products_3,
                    estimated_heating_surface_area = DataInput.Estimated_heating_surface_area_3,
                    pipe_diametr = DataInput.Pipe_diametr_3,
                    transverse_pitch_of_pipe = DataInput.Transverse_pitch_of_pipe_3,
                    longitudinal_pitch_of_pipes = DataInput.Longitudinal_pitch_of_pipes_3,
                    number_of_pipe_rows = DataInput.Number_of_pipe_rows_3,
                    temperature_of_the_the_heated_medium_at_The_inlet = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_3,
                    temperature_of_the_the_heated_medium_at_The_outlet = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_3,
                },
            });

        }

        void Economaizer_Read(DataInputModel DataInput)
        {
            Diary.Add(new ValueDiary()
            {
                caption = "--- Экономайзер ---",
                index = 3,
                inputVal = new ValueDiary.Input()
                {
                    temperature_of_incoming_gases = Diary[2].inputVal.temperature_of_outcoming_gases,
                    popravka_na_chair_radov_pipes = DataInput.Popravka_na_chair_radov_pipes_4,
                    temperature_of_outcoming_gases = DataInput.Temperature_of_outcoming_gases_4,
                    cross_sectional_area_for_passage_of_combustion_products = DataInput.Cross_sectional_area_for_passage_of_combustion_products_4,
                    estimated_heating_surface_area = DataInput.Estimated_heating_surface_area_4,
                    pipe_diametr = DataInput.Pipe_diametr_4,
                    transverse_pitch_of_pipe = DataInput.Transverse_pitch_of_pipe_4,
                    longitudinal_pitch_of_pipes = DataInput.Longitudinal_pitch_of_pipes_4,
                    number_of_pipe_rows = DataInput.Number_of_pipe_rows_4,
                    temperature_of_the_the_heated_medium_at_The_inlet = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_4,
                    temperature_of_the_the_heated_medium_at_The_outlet = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_4,
                },
            });

        }

        void SteamRun_Write()
        {
            SteamValue.thermal_count_transfered_water_and_steam = _cs.Thermal_count_transfered_water_and_par(Diary[0].outputCodeVal.incoming_entalpia_gazes);
            SteamValue.thermal_count_transfered_in_paroperegrevatel = _cs.Thermal_count_transfered_in_paroperegrevatel(Diary[1].outputCodeVal.incoming_entalpia_gazes, Diary[1].outputCodeVal.outcoming_entalpia_gazes);
            SteamValue.entalpia_hot_water = _cs.Entalpia_hot_water(_cs.Presure_putten_par);
            SteamValue.entalpia_eaten_water = _cs.Entalpia_eaten_Water(_cs.Temperature_eaten_water, _cs.Presure_putten_par);
            SteamValue.entalpia_saturated_dry_steam = _cs.Entalpia_saturated_dry_steam(_cs.Presure_putten_par);
            SteamValue.calculated_entalpia_hotest_steam = _cs.Calculated_entalpia_hotest_steam();
            SteamValue.calculated_theoretic_entalpia_hotest_steam = _cs.Calculated_theoretic_entalpia_hotest_steam(_cs.Presure_putten_par, Diary[1].inputVal.temperature_of_the_the_heated_medium_at_The_outlet);
            SteamValue.steam_capicity = _cs.Steam_capacity();
            SteamValue.percentage_discrepancy = _cs.Percentage_discrepancy();
        }

        public DataOutputModel(DataInputModel DataInput)
        {
            _dataInput = DataInput;

            #region --- Передать исходные данные в экземпляр библиотеки

            _cs.Co2 = _dataInput.Co2;
            _cs.H2o = _dataInput.H2o;
            _cs.N2 = _dataInput.N2;
            _cs.O2 = _dataInput.O2;

            _cs.Gaz_used = _dataInput.Gaz_used;
            _cs.Presure_putten_par = _dataInput.Presure_putten_par;
            _cs.Temperature_eaten_water = _dataInput.Temperature_eaten_water;
            _cs.Temperature_arrive_smoke = _dataInput.Temperature_arrive_smoke;

            _cs.Proportion_of_intake_air = _dataInput.Proportion_of_intake_air;
            _cs.Thermal_resistance_of_deposits_on_pipes = _dataInput.Thermal_resistance_of_deposits_on_pipes;
            _cs.The_emission_coefficient_of_a_completely_black_body = _dataInput.The_emission_coefficient_of_a_completely_black_body;
            _cs.The_degree_of_blackness_of_the_walls_of_the_tube_package = _dataInput.The_degree_of_blackness_of_the_walls_of_the_tube_package;
            _cs.Heat_preservation_coefficient = _dataInput.Heat_preservation_coefficient;
            _cs.Purge_n = _dataInput.Purge_n;

            _cs.Temperature_of_the_the_heated_medium_at_The_inlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_inlet;
            _cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;

            //PIP
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;


            #endregion --- Передать исходные данные в экземпляр библиотеки


            PIP_Read(_dataInput);
            WriteValue(0);
            Steam_Read(_dataInput);
            WriteValue(1);
            SteamingSection_Read(_dataInput);
            WriteValue(2);
            Economaizer_Read(_dataInput);
            WriteValue(3);
            SteamRun_Write();

        }
        public DataOutputModel(VariantUser DataInput)
        {
            DataInputModel inputModel = _service.ConvertUserVarToDataInput(DataInput);
            _dataInput = inputModel;

            #region --- Передать исходные данные в экземпляр библиотеки

            _cs.Co2 = _dataInput.Co2;
            _cs.H2o = _dataInput.H2o;
            _cs.N2 = _dataInput.N2;
            _cs.O2 = _dataInput.O2;

            _cs.Gaz_used = _dataInput.Gaz_used;
            _cs.Presure_putten_par = _dataInput.Presure_putten_par;
            _cs.Temperature_eaten_water = _dataInput.Temperature_eaten_water;
            _cs.Temperature_arrive_smoke = _dataInput.Temperature_arrive_smoke;

            _cs.Proportion_of_intake_air = _dataInput.Proportion_of_intake_air;
            _cs.Thermal_resistance_of_deposits_on_pipes = _dataInput.Thermal_resistance_of_deposits_on_pipes;
            _cs.The_emission_coefficient_of_a_completely_black_body = _dataInput.The_emission_coefficient_of_a_completely_black_body;
            _cs.The_degree_of_blackness_of_the_walls_of_the_tube_package = _dataInput.The_degree_of_blackness_of_the_walls_of_the_tube_package;
            _cs.Heat_preservation_coefficient = _dataInput.Heat_preservation_coefficient;
            _cs.Purge_n = _dataInput.Purge_n;

            _cs.Temperature_of_the_the_heated_medium_at_The_inlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_inlet;
            _cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;

            //PIP
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;
            //_cs.Temperature_of_the_the_heated_medium_at_The_outlet = _dataInput.Temperature_of_the_the_heated_medium_at_The_outlet;


            #endregion --- Передать исходные данные в экземпляр библиотеки


            PIP_Read(_dataInput);
            WriteValue(0);
            Steam_Read(_dataInput);
            WriteValue(1);
            SteamingSection_Read(_dataInput);
            WriteValue(2);
            Economaizer_Read(_dataInput);
            WriteValue(3);
            SteamRun_Write();

        }

        /// <summary>
        /// Инициализация данных для четырёх 
        /// </summary>
        public void InitializationValues(DataInputModel DataInput)
        {
            DataOtherLists.Add(new DataOtherLists
            {
                Temperature_of_incoming_gases = DataInput.Temperature_of_incoming_gases,
                Popravka_na_chair_radov_pipes = DataInput.Popravka_na_chair_radov_pipes,
                Temperature_of_outcoming_gases = DataInput.Temperature_of_outcoming_gases,
                Cross_sectional_area_for_passage_of_combustion_products = DataInput.Cross_sectional_area_for_passage_of_combustion_products,
                Estimated_heating_surface_area = DataInput.Estimated_heating_surface_area,
                Pipe_diametr = DataInput.Pipe_diametr,
                Transverse_pitch_of_pipe = DataInput.Transverse_pitch_of_pipe,
                Longitudinal_pitch_of_pipes = DataInput.Longitudinal_pitch_of_pipes,
                Number_of_pipe_rows = DataInput.Number_of_pipe_rows
            });
        }


    }
}
