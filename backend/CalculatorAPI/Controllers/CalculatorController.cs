using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using CalculatorAPI.Data;
using CalculatorAPI.Models;
using KotelUtilizatorLibrary;
using KotelUtilizatorLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RecuperatorCore.Models;
using WebApplication1.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static RecuperatorCore.Models.DataOutputModel;
//using static KotelUtilizatorLibrary.Combiners;

namespace CalculatorAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalculatorController> _logger;

        private readonly CalculationDbContext _context;
        private readonly IMapper _mapper;
        private readonly RecuperatorService _service;


        public CalculatorController(ILogger<CalculatorController> logger, CalculationDbContext context, RecuperatorService recuperator, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _service = recuperator;
            _mapper = mapper;
        }

        public class CombinedData
        {
            public MathLib otherVal { get; set; }
            public List<ValueDiary> value { get; set; }
            public SteamRun result { get; set; }
        }


        [HttpPost("Solve")]
        public IActionResult SolveVal([FromBody] DataInputModel model)
        {
            DataOutputModel _result = new DataOutputModel(model);
            //var log = _result.;
            var data = new CombinedData
            {
                otherVal = _result._cs,
                value = _result.Diary,
                result = _result.SteamValue
            };
            return new JsonResult(data);
        }

        [HttpPut("PutIn{userid}")]
        public IActionResult PutVal([FromBody] DataInputModel model, int userid)
        {
            DataOutputModel _result = new DataOutputModel(model);
            //var log = _result.;
            var data = new CombinedData
            {
                value = _result.Diary,
                result = _result.SteamValue
            };
            return new JsonResult(data);
        }

        #region Сохранение варианта
        [HttpPost("Save")]
        public IActionResult SaveVariant(VariantAddDtoModel model)
        {
            Guid guid = Guid.NewGuid();
            //var temp_variant = new VariantAddDto
            //{
            //    Name = model.Name,
            //    Desc = model.Desc,
            //    //UserId = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name).Id,
            //    UserId = _context.Users.FirstOrDefault(x => x.Id == model.UserId).Id,
            //};
            //var variant = _mapper.Map<Variant>(temp_variant);
            //_context.Variants.Add(variant);
            //_context.SaveChanges();
            var temp_variantUser = new VariantUserAddDto
            {
                Name = model.Name,
                Desc = model.Desc,
                //VariantId = _service.GetVariantId(temp_variant),
                VariantId = _service.SetVariantId(),
                UserId = model.UserId,
                Co2 = model.Modela.Co2,
                H2o = model.Modela.H2o,
                N2 = model.Modela.N2,
                O2 = model.Modela.O2,

                Gaz_used = model.Modela.Gaz_used,
                Presure_putten_par = model.Modela.Presure_putten_par,
                Temperature_eaten_water = model.Modela.Temperature_eaten_water,
                Temperature_arrive_smoke = model.Modela.Temperature_arrive_smoke,

                Proportion_of_intake_air = model.Modela.Proportion_of_intake_air,
                Thermal_resistance_of_deposits_on_pipes = model.Modela.Thermal_resistance_of_deposits_on_pipes,
                The_emission_coefficient_of_a_completely_black_body = model.Modela.The_emission_coefficient_of_a_completely_black_body,
                The_degree_of_blackness_of_the_walls_of_the_tube_package = model.Modela.The_degree_of_blackness_of_the_walls_of_the_tube_package,
                Heat_preservation_coefficient = model.Modela.Heat_preservation_coefficient,
                Purge_n = model.Modela.Purge_n,

                Temperature_of_incoming_gases_1 = model.Modela.Temperature_of_incoming_gases_1,
                Popravka_na_chair_radov_pipes_1 = model.Modela.Popravka_na_chair_radov_pipes_1,
                Temperature_of_outcoming_gases_1 = model.Modela.Temperature_of_outcoming_gases_1,
                Cross_sectional_area_for_passage_of_combustion_products_1 = model.Modela.Cross_sectional_area_for_passage_of_combustion_products_1,
                Estimated_heating_surface_area_1 = model.Modela.Estimated_heating_surface_area_1,
                Pipe_diametr_1 = model.Modela.Pipe_diametr_1,
                Transverse_pitch_of_pipe_1 = model.Modela.Transverse_pitch_of_pipe_1,
                Longitudinal_pitch_of_pipes_1 = model.Modela.Longitudinal_pitch_of_pipes_1,
                Number_of_pipe_rows_1 = model.Modela.Number_of_pipe_rows_1,
                Temperature_of_the_the_heated_medium_at_The_inlet_1 = model.Modela.Temperature_of_the_the_heated_medium_at_The_inlet_1,
                Temperature_of_the_the_heated_medium_at_The_outlet_1 = model.Modela.Temperature_of_the_the_heated_medium_at_The_outlet_1,

                Popravka_na_chair_radov_pipes_2 = model.Modela.Popravka_na_chair_radov_pipes_2,
                Temperature_of_outcoming_gases_2 = model.Modela.Temperature_of_outcoming_gases_2,
                Cross_sectional_area_for_passage_of_combustion_products_2 = model.Modela.Cross_sectional_area_for_passage_of_combustion_products_2,
                Estimated_heating_surface_area_2 = model.Modela.Estimated_heating_surface_area_2,
                Pipe_diametr_2 = model.Modela.Pipe_diametr_2,
                Transverse_pitch_of_pipe_2 = model.Modela.Transverse_pitch_of_pipe_2,
                Longitudinal_pitch_of_pipes_2 = model.Modela.Longitudinal_pitch_of_pipes_2,
                Number_of_pipe_rows_2 = model.Modela.Number_of_pipe_rows_2,
                Temperature_of_the_the_heated_medium_at_The_inlet_2 = model.Modela.Temperature_of_the_the_heated_medium_at_The_inlet_2,
                Temperature_of_the_the_heated_medium_at_The_outlet_2 = model.Modela.Temperature_of_the_the_heated_medium_at_The_outlet_2,

                Popravka_na_chair_radov_pipes_3 = model.Modela.Popravka_na_chair_radov_pipes_3,
                Temperature_of_outcoming_gases_3 = model.Modela.Temperature_of_outcoming_gases_3,
                Cross_sectional_area_for_passage_of_combustion_products_3 = model.Modela.Cross_sectional_area_for_passage_of_combustion_products_3,
                Estimated_heating_surface_area_3 = model.Modela.Estimated_heating_surface_area_3,
                Pipe_diametr_3 = model.Modela.Pipe_diametr_3,
                Transverse_pitch_of_pipe_3 = model.Modela.Transverse_pitch_of_pipe_3,
                Longitudinal_pitch_of_pipes_3 = model.Modela.Longitudinal_pitch_of_pipes_3,
                Number_of_pipe_rows_3 = model.Modela.Number_of_pipe_rows_3,
                Temperature_of_the_the_heated_medium_at_The_inlet_3 = model.Modela.Temperature_of_the_the_heated_medium_at_The_inlet_3,
                Temperature_of_the_the_heated_medium_at_The_outlet_3 = model.Modela.Temperature_of_the_the_heated_medium_at_The_outlet_3,

                Popravka_na_chair_radov_pipes_4 = model.Modela.Popravka_na_chair_radov_pipes_4,
                Temperature_of_outcoming_gases_4 = model.Modela.Temperature_of_outcoming_gases_4,
                Cross_sectional_area_for_passage_of_combustion_products_4 = model.Modela.Cross_sectional_area_for_passage_of_combustion_products_4,
                Estimated_heating_surface_area_4 = model.Modela.Estimated_heating_surface_area_4,
                Pipe_diametr_4 = model.Modela.Pipe_diametr_4,
                Transverse_pitch_of_pipe_4 = model.Modela.Transverse_pitch_of_pipe_4,
                Longitudinal_pitch_of_pipes_4 = model.Modela.Longitudinal_pitch_of_pipes_4,
                Number_of_pipe_rows_4 = model.Modela.Number_of_pipe_rows_4,
                Temperature_of_the_the_heated_medium_at_The_inlet_4 = model.Modela.Temperature_of_the_the_heated_medium_at_The_inlet_4,
                Temperature_of_the_the_heated_medium_at_The_outlet_4 = model.Modela.Temperature_of_the_the_heated_medium_at_The_outlet_4,
            };
            var variantUser = _mapper.Map<VariantUser>(temp_variantUser);
            _context.VariantUsers.Add(variantUser);
            _context.SaveChanges();
            return Ok();
        }
        #endregion
        #region Сохранение варианта
        [HttpPatch("Edit")]
        public IActionResult EditVariant(VariantEditDtoModel model)
        {
            var variant = _context.VariantUsers.FirstOrDefault(x => x.VariantId == model.VariantId);

            if (variant == null)
                return NotFound();

            //var temp_variant = new VariantAddDto
            //{
            //    Name = model.Name,
            //    Desc = model.Desc,
            //    //UserId = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name).Id,
            //    UserId = _context.Users.FirstOrDefault(x => x.Id == model.UserId).Id,
            //};
            //var variant = _mapper.Map<Variant>(temp_variant);
            //_context.Variants.Add(variant);
            //_context.SaveChanges();
            variant.Name = model.Name;
            variant.Desc = model.Desc;
            //VariantId = _service.GetVariantId(temp_variant);
            //variant.VariantId = model.;
            variant.UserId = model.UserId;
            variant.Co2 = model.Modela.Co2;
            variant.H2o = model.Modela.H2o;
            variant.N2 = model.Modela.N2;
            variant.O2 = model.Modela.O2;

            variant.Gaz_used = model.Modela.Gaz_used;
            variant.Presure_putten_par = model.Modela.Presure_putten_par;
            variant.Temperature_eaten_water = model.Modela.Temperature_eaten_water;
            variant.Temperature_arrive_smoke = model.Modela.Temperature_arrive_smoke;

            variant.Proportion_of_intake_air = model.Modela.Proportion_of_intake_air;
            variant.Thermal_resistance_of_deposits_on_pipes = model.Modela.Thermal_resistance_of_deposits_on_pipes;
            variant.The_emission_coefficient_of_a_completely_black_body = model.Modela.The_emission_coefficient_of_a_completely_black_body;
            variant.The_degree_of_blackness_of_the_walls_of_the_tube_package = model.Modela.The_degree_of_blackness_of_the_walls_of_the_tube_package;
            variant.Heat_preservation_coefficient = model.Modela.Heat_preservation_coefficient;
            variant.Purge_n = model.Modela.Purge_n;

            variant.Temperature_of_incoming_gases_1 = model.Modela.Temperature_of_incoming_gases_1;
            variant.Popravka_na_chair_radov_pipes_1 = model.Modela.Popravka_na_chair_radov_pipes_1;
            variant.Temperature_of_outcoming_gases_1 = model.Modela.Temperature_of_outcoming_gases_1;
            variant.Cross_sectional_area_for_passage_of_combustion_products_1 = model.Modela.Cross_sectional_area_for_passage_of_combustion_products_1;
            variant.Estimated_heating_surface_area_1 = model.Modela.Estimated_heating_surface_area_1;
            variant.Pipe_diametr_1 = model.Modela.Pipe_diametr_1;
            variant.Transverse_pitch_of_pipe_1 = model.Modela.Transverse_pitch_of_pipe_1;
            variant.Longitudinal_pitch_of_pipes_1 = model.Modela.Longitudinal_pitch_of_pipes_1;
            variant.Number_of_pipe_rows_1 = model.Modela.Number_of_pipe_rows_1;
            variant.Temperature_of_the_the_heated_medium_at_The_inlet_1 = model.Modela.Temperature_of_the_the_heated_medium_at_The_inlet_1;
            variant.Temperature_of_the_the_heated_medium_at_The_outlet_1 = model.Modela.Temperature_of_the_the_heated_medium_at_The_outlet_1;

            variant.Popravka_na_chair_radov_pipes_2 = model.Modela.Popravka_na_chair_radov_pipes_2;
            variant.Temperature_of_outcoming_gases_2 = model.Modela.Temperature_of_outcoming_gases_2;
            variant.Cross_sectional_area_for_passage_of_combustion_products_2 = model.Modela.Cross_sectional_area_for_passage_of_combustion_products_2;
            variant.Estimated_heating_surface_area_2 = model.Modela.Estimated_heating_surface_area_2;
            variant.Pipe_diametr_2 = model.Modela.Pipe_diametr_2;
            variant.Transverse_pitch_of_pipe_2 = model.Modela.Transverse_pitch_of_pipe_2;
            variant.Longitudinal_pitch_of_pipes_2 = model.Modela.Longitudinal_pitch_of_pipes_2;
            variant.Number_of_pipe_rows_2 = model.Modela.Number_of_pipe_rows_2;
            variant.Temperature_of_the_the_heated_medium_at_The_inlet_2 = model.Modela.Temperature_of_the_the_heated_medium_at_The_inlet_2;
            variant.Temperature_of_the_the_heated_medium_at_The_outlet_2 = model.Modela.Temperature_of_the_the_heated_medium_at_The_outlet_2;

            variant.Popravka_na_chair_radov_pipes_3 = model.Modela.Popravka_na_chair_radov_pipes_3;
            variant.Temperature_of_outcoming_gases_3 = model.Modela.Temperature_of_outcoming_gases_3;
            variant.Cross_sectional_area_for_passage_of_combustion_products_3 = model.Modela.Cross_sectional_area_for_passage_of_combustion_products_3;
            variant.Estimated_heating_surface_area_3 = model.Modela.Estimated_heating_surface_area_3;
            variant.Pipe_diametr_3 = model.Modela.Pipe_diametr_3;
            variant.Transverse_pitch_of_pipe_3 = model.Modela.Transverse_pitch_of_pipe_3;
            variant.Longitudinal_pitch_of_pipes_3 = model.Modela.Longitudinal_pitch_of_pipes_3;
            variant.Number_of_pipe_rows_3 = model.Modela.Number_of_pipe_rows_3;
            variant.Temperature_of_the_the_heated_medium_at_The_inlet_3 = model.Modela.Temperature_of_the_the_heated_medium_at_The_inlet_3;
            variant.Temperature_of_the_the_heated_medium_at_The_outlet_3 = model.Modela.Temperature_of_the_the_heated_medium_at_The_outlet_3;

            variant.Popravka_na_chair_radov_pipes_4 = model.Modela.Popravka_na_chair_radov_pipes_4;
            variant.Temperature_of_outcoming_gases_4 = model.Modela.Temperature_of_outcoming_gases_4;
            variant.Cross_sectional_area_for_passage_of_combustion_products_4 = model.Modela.Cross_sectional_area_for_passage_of_combustion_products_4;
            variant.Estimated_heating_surface_area_4 = model.Modela.Estimated_heating_surface_area_4;
            variant.Pipe_diametr_4 = model.Modela.Pipe_diametr_4;
            variant.Transverse_pitch_of_pipe_4 = model.Modela.Transverse_pitch_of_pipe_4;
            variant.Longitudinal_pitch_of_pipes_4 = model.Modela.Longitudinal_pitch_of_pipes_4;
            variant.Number_of_pipe_rows_4 = model.Modela.Number_of_pipe_rows_4;
            variant.Temperature_of_the_the_heated_medium_at_The_inlet_4 = model.Modela.Temperature_of_the_the_heated_medium_at_The_inlet_4;
            variant.Temperature_of_the_the_heated_medium_at_The_outlet_4 = model.Modela.Temperature_of_the_the_heated_medium_at_The_outlet_4;
            //var variantUser = _mapper.Map<VariantUser>(temp_variantUser);
            _context.VariantUsers.Update(variant);

            _context.SaveChanges();
            return Ok();
        }
        #endregion

        #region Загрузка варианта
        [HttpPost("LoadVariant")]
        public IActionResult LoadVariant([FromBody] VariantLoadDto model)
        {
            var variant = _service.GetVariantUser(model);
            var s = new JsonResult(new {result = variant});
            return Ok(s);
        }
        #endregion

        #region Загрузка варианта с решением
        [HttpPost("LoadSolveVariant")]
        public IActionResult LoadSolveVariant([FromBody] VariantLoadDto model)
        {
            var DataInput = _service.GetVariantUser(model);
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

            DataOutputModel _result = new DataOutputModel(inputModel);
            var data = new CombinedData
            {
                otherVal = _result._cs,
                value = _result.Diary,
                result = _result.SteamValue
            };

            var s = new JsonResult(data);
            return Ok(s);
        }
        #endregion

        #region Дублирование варианта
        [HttpPost("DuplicateVariant")]
        public IActionResult DuplicateVariant([FromBody] VariantLoadDto model)
        {
            var variant = _service.GetVariantUser(model);

            return Ok(SaveVariant(_service.ConvertUserVarToAddDto(variant)));
        }
        #endregion

        #region Загрузка вариантов
        [HttpPost("LoadListVariant{id}")]
        public IActionResult LoadListVariant(int id)
        {
            var variant = _service.GetVariants(id);
            var s = new JsonResult(variant);
            return Ok(s);
        }
        #endregion


        #region Удаление варианта
        [HttpDelete]
        public IActionResult DeleteVariant(VariantDeleteDto model)
        {
            if (_service.DeleteVariant(model))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error for deleten data");
            }
        }
        #endregion



        //public void DataInput(DataInputModel DataInput)
        //{
        //    DataOutputModel _result = new DataOutputModel(DataInput);

        //}




        private MathLib DefValue()
        {
            MathLib _cs = new MathLib();

            return _cs;
        }
    }
}
