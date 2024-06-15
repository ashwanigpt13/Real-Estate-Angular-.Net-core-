using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Dtos;
using WebAPI.Errors;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private IConfiguration configuration;
        private readonly IUnitOfWork uow;
        public AccountController(IUnitOfWork uow,IConfiguration configuration)
        {
            this.configuration = configuration;
            this.uow = uow;
            
        }
     [HttpPost("Login")]
        [AllowAnonymous]
public async Task<IActionResult> Login([FromBody] LoginReqDto loginReq)
{
     var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

            ApiError apiError = new ApiError();

            if (user == null)
            {
                apiError.ErrorCode=Unauthorized().StatusCode;
                apiError.ErrorMessage="Invalid user name or password";
                apiError.ErrorDetails="This error appear when provided user id or password does not exists";
                return Unauthorized(apiError);
            }
        if(user!=null){
            var loginRes = new LoginResponseDto
            {
                UserName = user.Username,
                Token = CreateJWT(user)
            };
        return Ok(loginRes);
        }
            else
            {
                return Unauthorized("Invalid user name or password");
            }

 
}
        [AllowAnonymous]
  [HttpPost("register")]
        public async Task<IActionResult> Register(LoginReqDto loginReq)
        {
           ApiError apiError = new ApiError();

           if (string.IsNullOrEmpty(loginReq.UserName) || string.IsNullOrEmpty(loginReq.Password)) {
                   apiError.ErrorCode=BadRequest().StatusCode;
                   apiError.ErrorMessage="User name or password can not be blank";                    
                   return BadRequest(apiError);
            }                    

            if (await uow.UserRepository.UserAlreadyExists(loginReq.UserName)) {
                apiError.ErrorCode=BadRequest().StatusCode;
                apiError.ErrorMessage="User already exists, please try different user name";
                return BadRequest(apiError);
            }                

            uow.UserRepository.Register(loginReq.UserName, loginReq.Password);
            await uow.SaveAsync();
            return StatusCode(201);
        }

  private string CreateJWT(User user)
        {
            
           var secretKey = configuration.GetSection("AppSettings:Key")?.Value ?? "defaultSecretKey";
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(s: secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}