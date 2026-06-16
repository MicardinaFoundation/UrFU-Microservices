using CalculatorAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using KotelUtilizatorLibrary.Models;
using Microsoft.EntityFrameworkCore;
using RecuperatorCore.Models;
using AutoMapper;
using CalculatorAPI.Data;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly CalculationDbContext _context;
        private readonly IMapper _mapper;
        public AuthController(CalculationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Index([FromBody] AuthRequest model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == model.Login && x.Password == model.Password);
            if (user != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Login) };
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return Ok(new AuthResponse()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwt).ToString(),
                    UserIndex = _context.Users.FirstOrDefault(x => x.Login == model.Login).Id,
                    UName = _context.Users.FirstOrDefault(x => x.Login == model.Login).UName
                });

            }
            else
            {
                return BadRequest("Неправильный логин или пароль");
            }

        }

        [HttpPut]
        public IActionResult RegisterUser(UserAddDto model)
        {
            var user = _mapper.Map<User>(model);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }

    }
}
