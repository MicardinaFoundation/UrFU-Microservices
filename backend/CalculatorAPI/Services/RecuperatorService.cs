using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RecuperatorCore.Models;
using KotelUtilizatorLibrary.Models;
using WebApplication1;
using SQLitePCL;
using System.Net.Http;
using CalculatorAPI.Data;
using System.Security.Cryptography;

namespace WebApplication1.Services
{
    public class RecuperatorService
    {
        private readonly CalculationDbContext _context;
        public RecuperatorService(CalculationDbContext context)
        {
            _context = context;
        }
        //public List<VariantUser> GetVariants(int UserId)
        //{
        //    var query = _context.VariantUsers.AsQueryable();
        //    if (UserId != 0) query = query.Where(x => x.UserId == UserId);
        //    return null;
        //}
        public List<VariantUser> GetVariants(int UserId)
        {
            var query = _context.VariantUsers.Where(x => x.UserId == UserId).ToList(); ;
            return query;
        }
        public int GetUserId(string User)
        {
            int UserId = _context.Users.FirstOrDefault(x => x.Login == User).Id;
            return UserId;
        }
        public int GetVariantId(VariantAddDto variant)
        {
            int variantId = _context.Variants.FirstOrDefault(x => x.Name == variant.Name).Id;
            return variantId;
        }
        public int SetVariantId()
        {
            int result = 0;
            int errInf = 0;
            for (int err = 40; err > 0; err--)
            {
                var s = RandomNumberGenerator.GetInt32(0, 9999999);
                if (_context.VariantUsers.FirstOrDefault(x => x.VariantId == s) == null)
                {
                    result = s;
                    break;
                }
                else
                {
                    errInf++;
                }

            }
            return result;
        }
        //public Guid GetGuidVariantId
        public VariantUser GetVariantUser(VariantLoadDto model)
        {
            var variant = _context.VariantUsers.FirstOrDefault(x => x.UserId == model.UserId && x.VariantId == model.VariantId);
            return variant;
        }
        public VariantUser GetDefaultVariantUser(int UserId)
        {
            var variant = _context.VariantUsers.FirstOrDefault(x => x.Id == UserId);
            return variant;
        }
        public bool DeleteVariant(VariantDeleteDto model)
        {
            var variantUser = _context.VariantUsers.FirstOrDefault(x => x.UserId == model.UserId && x.VariantId == model.VariantId);
            _context.VariantUsers.Remove(variantUser);
            var variant = _context.Variants.FirstOrDefault(x => x.Id == model.VariantId);
            if (variant != null)_context.Variants.Remove(variant);
            _context.SaveChanges();
            return true;
        }

        public DataInputModel ConvertUserVarToDataInput(VariantUser DataInput)
        {
            DataInputModel inputModel = new DataInputModel
            {
                Co2 = DataInput.Co2,
                H2o = DataInput.H2o,
                N2 = DataInput.N2,
                O2 = DataInput.O2,
                Gaz_used = DataInput.Gaz_used,
                Presure_putten_par = DataInput.Presure_putten_par,
                Temperature_eaten_water = DataInput.Temperature_eaten_water,
                Temperature_arrive_smoke = DataInput.Temperature_arrive_smoke,
                //Temperature_of_incoming_gases = DataInput.Temperature_of_incoming_gases,
                //Cross_sectional_area_for_passage_of_combustion_products = DataInput.Cross_sectional_area_for_passage_of_combustion_products,
                //Number_of_pipe_rows = DataInput.Number_of_pipe_rows,
                Thermal_resistance_of_deposits_on_pipes = DataInput.Thermal_resistance_of_deposits_on_pipes,
                The_emission_coefficient_of_a_completely_black_body = DataInput.The_emission_coefficient_of_a_completely_black_body,
                The_degree_of_blackness_of_the_walls_of_the_tube_package = DataInput.The_degree_of_blackness_of_the_walls_of_the_tube_package,
                Heat_preservation_coefficient = DataInput.Heat_preservation_coefficient,
                Purge_n = DataInput.Purge_n,
                //Temperature_of_the_the_heated_medium_at_The_inlet = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet,
                //Temperature_of_the_the_heated_medium_at_The_outlet = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet,
                Proportion_of_intake_air = DataInput.Proportion_of_intake_air,
                Temperature_of_incoming_gases_1 = DataInput.Temperature_of_incoming_gases_1,
                Popravka_na_chair_radov_pipes_1 = DataInput.Popravka_na_chair_radov_pipes_1,
                Temperature_of_outcoming_gases_1 = DataInput.Temperature_of_outcoming_gases_1,
                Cross_sectional_area_for_passage_of_combustion_products_1 = DataInput.Cross_sectional_area_for_passage_of_combustion_products_1,
                Estimated_heating_surface_area_1 = DataInput.Estimated_heating_surface_area_1,
                Pipe_diametr_1 = DataInput.Pipe_diametr_1,
                Transverse_pitch_of_pipe_1 = DataInput.Transverse_pitch_of_pipe_1,
                Longitudinal_pitch_of_pipes_1 = DataInput.Longitudinal_pitch_of_pipes_1,
                Number_of_pipe_rows_1 = DataInput.Number_of_pipe_rows_1,
                Temperature_of_the_the_heated_medium_at_The_inlet_1 = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_1,
                Temperature_of_the_the_heated_medium_at_The_outlet_1 = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_1,

                //Temperature_of_incoming_gases_2 = DataInput.Temperature_of_incoming_gases_2,
                Popravka_na_chair_radov_pipes_2 = DataInput.Popravka_na_chair_radov_pipes_2,
                Temperature_of_outcoming_gases_2 = DataInput.Temperature_of_outcoming_gases_2,
                Cross_sectional_area_for_passage_of_combustion_products_2 = DataInput.Cross_sectional_area_for_passage_of_combustion_products_2,
                Estimated_heating_surface_area_2 = DataInput.Estimated_heating_surface_area_2,
                Pipe_diametr_2 = DataInput.Pipe_diametr_2,
                Transverse_pitch_of_pipe_2 = DataInput.Transverse_pitch_of_pipe_2,
                Longitudinal_pitch_of_pipes_2 = DataInput.Longitudinal_pitch_of_pipes_2,
                Number_of_pipe_rows_2 = DataInput.Number_of_pipe_rows_2,
                Temperature_of_the_the_heated_medium_at_The_inlet_2 = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_2,
                Temperature_of_the_the_heated_medium_at_The_outlet_2 = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_2,

                //Temperature_of_incoming_gases_3 = DataInput.Temperature_of_incoming_gases_3,
                Popravka_na_chair_radov_pipes_3 = DataInput.Popravka_na_chair_radov_pipes_3,
                Temperature_of_outcoming_gases_3 = DataInput.Temperature_of_outcoming_gases_3,
                Cross_sectional_area_for_passage_of_combustion_products_3 = DataInput.Cross_sectional_area_for_passage_of_combustion_products_3,
                Estimated_heating_surface_area_3 = DataInput.Estimated_heating_surface_area_3,
                Pipe_diametr_3 = DataInput.Pipe_diametr_3,
                Transverse_pitch_of_pipe_3 = DataInput.Transverse_pitch_of_pipe_3,
                Longitudinal_pitch_of_pipes_3 = DataInput.Longitudinal_pitch_of_pipes_3,
                Number_of_pipe_rows_3 = DataInput.Number_of_pipe_rows_3,
                Temperature_of_the_the_heated_medium_at_The_inlet_3 = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_3,
                Temperature_of_the_the_heated_medium_at_The_outlet_3 = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_3,

                //Tem = DataInput.Temperature_of_incoming_gases_4,
                Popravka_na_chair_radov_pipes_4 = DataInput.Popravka_na_chair_radov_pipes_4,
                Temperature_of_outcoming_gases_4 = DataInput.Temperature_of_outcoming_gases_4,
                Cross_sectional_area_for_passage_of_combustion_products_4 = DataInput.Cross_sectional_area_for_passage_of_combustion_products_4,
                Estimated_heating_surface_area_4 = DataInput.Estimated_heating_surface_area_4,
                Pipe_diametr_4 = DataInput.Pipe_diametr_4,
                Transverse_pitch_of_pipe_4 = DataInput.Transverse_pitch_of_pipe_4,
                Longitudinal_pitch_of_pipes_4 = DataInput.Longitudinal_pitch_of_pipes_4,
                Number_of_pipe_rows_4 = DataInput.Number_of_pipe_rows_4,
                Temperature_of_the_the_heated_medium_at_The_inlet_4 = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_4,
                Temperature_of_the_the_heated_medium_at_The_outlet_4 = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_4,

            };
            return inputModel;
        }

        public VariantAddDtoModel ConvertUserVarToAddDto(VariantUser DataInput)
        {
            modelVal inputModel = new modelVal
            {
                Co2 = DataInput.Co2,
                H2o = DataInput.H2o,
                N2 = DataInput.N2,
                O2 = DataInput.O2,
                Gaz_used = DataInput.Gaz_used,
                Presure_putten_par = DataInput.Presure_putten_par,
                Temperature_eaten_water = DataInput.Temperature_eaten_water,
                Temperature_arrive_smoke = DataInput.Temperature_arrive_smoke,
                //Temperature_of_incoming_gases = DataInput.Temperature_of_incoming_gases,
                //Cross_sectional_area_for_passage_of_combustion_products = DataInput.Cross_sectional_area_for_passage_of_combustion_products,
                //Number_of_pipe_rows = DataInput.Number_of_pipe_rows,
                Thermal_resistance_of_deposits_on_pipes = DataInput.Thermal_resistance_of_deposits_on_pipes,
                The_emission_coefficient_of_a_completely_black_body = DataInput.The_emission_coefficient_of_a_completely_black_body,
                The_degree_of_blackness_of_the_walls_of_the_tube_package = DataInput.The_degree_of_blackness_of_the_walls_of_the_tube_package,
                Heat_preservation_coefficient = DataInput.Heat_preservation_coefficient,
                Purge_n = DataInput.Purge_n,
                //Temperature_of_the_the_heated_medium_at_The_inlet = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet,
                //Temperature_of_the_the_heated_medium_at_The_outlet = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet,
                Proportion_of_intake_air = DataInput.Proportion_of_intake_air,
                Temperature_of_incoming_gases_1 = DataInput.Temperature_of_incoming_gases_1,
                Popravka_na_chair_radov_pipes_1 = DataInput.Popravka_na_chair_radov_pipes_1,
                Temperature_of_outcoming_gases_1 = DataInput.Temperature_of_outcoming_gases_1,
                Cross_sectional_area_for_passage_of_combustion_products_1 = DataInput.Cross_sectional_area_for_passage_of_combustion_products_1,
                Estimated_heating_surface_area_1 = DataInput.Estimated_heating_surface_area_1,
                Pipe_diametr_1 = DataInput.Pipe_diametr_1,
                Transverse_pitch_of_pipe_1 = DataInput.Transverse_pitch_of_pipe_1,
                Longitudinal_pitch_of_pipes_1 = DataInput.Longitudinal_pitch_of_pipes_1,
                Number_of_pipe_rows_1 = DataInput.Number_of_pipe_rows_1,
                Temperature_of_the_the_heated_medium_at_The_inlet_1 = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_1,
                Temperature_of_the_the_heated_medium_at_The_outlet_1 = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_1,

                //Temperature_of_incoming_gases_2 = DataInput.Temperature_of_incoming_gases_2,
                Popravka_na_chair_radov_pipes_2 = DataInput.Popravka_na_chair_radov_pipes_2,
                Temperature_of_outcoming_gases_2 = DataInput.Temperature_of_outcoming_gases_2,
                Cross_sectional_area_for_passage_of_combustion_products_2 = DataInput.Cross_sectional_area_for_passage_of_combustion_products_2,
                Estimated_heating_surface_area_2 = DataInput.Estimated_heating_surface_area_2,
                Pipe_diametr_2 = DataInput.Pipe_diametr_2,
                Transverse_pitch_of_pipe_2 = DataInput.Transverse_pitch_of_pipe_2,
                Longitudinal_pitch_of_pipes_2 = DataInput.Longitudinal_pitch_of_pipes_2,
                Number_of_pipe_rows_2 = DataInput.Number_of_pipe_rows_2,
                Temperature_of_the_the_heated_medium_at_The_inlet_2 = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_2,
                Temperature_of_the_the_heated_medium_at_The_outlet_2 = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_2,

                //Temperature_of_incoming_gases_3 = DataInput.Temperature_of_incoming_gases_3,
                Popravka_na_chair_radov_pipes_3 = DataInput.Popravka_na_chair_radov_pipes_3,
                Temperature_of_outcoming_gases_3 = DataInput.Temperature_of_outcoming_gases_3,
                Cross_sectional_area_for_passage_of_combustion_products_3 = DataInput.Cross_sectional_area_for_passage_of_combustion_products_3,
                Estimated_heating_surface_area_3 = DataInput.Estimated_heating_surface_area_3,
                Pipe_diametr_3 = DataInput.Pipe_diametr_3,
                Transverse_pitch_of_pipe_3 = DataInput.Transverse_pitch_of_pipe_3,
                Longitudinal_pitch_of_pipes_3 = DataInput.Longitudinal_pitch_of_pipes_3,
                Number_of_pipe_rows_3 = DataInput.Number_of_pipe_rows_3,
                Temperature_of_the_the_heated_medium_at_The_inlet_3 = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_3,
                Temperature_of_the_the_heated_medium_at_The_outlet_3 = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_3,

                //Tem = DataInput.Temperature_of_incoming_gases_4,
                Popravka_na_chair_radov_pipes_4 = DataInput.Popravka_na_chair_radov_pipes_4,
                Temperature_of_outcoming_gases_4 = DataInput.Temperature_of_outcoming_gases_4,
                Cross_sectional_area_for_passage_of_combustion_products_4 = DataInput.Cross_sectional_area_for_passage_of_combustion_products_4,
                Estimated_heating_surface_area_4 = DataInput.Estimated_heating_surface_area_4,
                Pipe_diametr_4 = DataInput.Pipe_diametr_4,
                Transverse_pitch_of_pipe_4 = DataInput.Transverse_pitch_of_pipe_4,
                Longitudinal_pitch_of_pipes_4 = DataInput.Longitudinal_pitch_of_pipes_4,
                Number_of_pipe_rows_4 = DataInput.Number_of_pipe_rows_4,
                Temperature_of_the_the_heated_medium_at_The_inlet_4 = DataInput.Temperature_of_the_the_heated_medium_at_The_inlet_4,
                Temperature_of_the_the_heated_medium_at_The_outlet_4 = DataInput.Temperature_of_the_the_heated_medium_at_The_outlet_4,

            };

            VariantAddDtoModel inputData = new VariantAddDtoModel()
            {
                Name = DataInput.Name,
                Desc = DataInput.Desc,
                UserId = DataInput.UserId,
                Modela = inputModel
            };
            return inputData;
        }

    }
}
