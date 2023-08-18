using EShoppingAPI.Business.Abstract;
using EShoppingAPI.Entity.DTO.Login;
using EShoppingAPI.Entity.Result;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using EShoppingAPI.Apı.Aspect;
using EShoppingAPI.Apı.Validation.FluentValidation;

namespace EShoppingAPI.Apı.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class LoginController : Controller
    {

        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        [HttpPost("/Login")]
        //[ValidationFilter(typeof(LoginValidator))]
        [ProducesResponseType(typeof(Sonuç<LoginResponseDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
        {

            var user = await _userService.GetAsync(q => q.Username == loginRequestDTO.KullanıcıAdı && q.Password == loginRequestDTO.Şifre);

            if (user == null)
            {
                return NotFound(Sonuç<LoginResponseDTO>.AuthenticationError());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<String>("AppSettings:JWTKey"));

                var claims = new List<Claim>();
                claims.Add(new Claim("KullanıcıAdı", user.Username));
                claims.Add(new Claim("KullanıcıID", user.ID.ToString()));

                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(30),
                    claims: claims,
                    issuer: "http://jhgfyjdgfjhs.com",
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature));

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                LoginResponseDTO loginResponseDTO = new()
                {
                    AdSoyad = user.FirstName + " " + user.LastName,
                    UserID = user.ID,
                    EPosta = user.Email,
                    Adres = user.Adress,
                    Token = token,
                };

                return Ok(Sonuç<LoginResponseDTO>.SuccessWithData(loginResponseDTO));

            }



        }
    }
}
