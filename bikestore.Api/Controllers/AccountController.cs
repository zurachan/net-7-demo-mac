using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bikestore.Core.Common;
using bikestore.Core.Entity;
using bikestore.Core.Helper;
using bikestore.DataAccess.DataProvider.Management;
using bikestore.Entity.Management;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bikestore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDataProvider _accountDataProvider;
        public IConfiguration _configuration;

        public AccountController(IAccountDataProvider accountDataProvider, IConfiguration configuration)
        {
            _accountDataProvider = accountDataProvider;
            _configuration = configuration;
        }

        // POST api/values
        [HttpPost]
        [Route("Signup")]
        public async Task<ResponseData> Singup([FromBody] Register model)
        {
            ResponseData rs = new ResponseData();


            var dbAccount = _accountDataProvider.GetByEmail(model.Email);
            if (dbAccount.Id == 0)
            {
                var salt = Guid.NewGuid().ToString();


                var account = new Account
                {
                    Email = model.Email.Trim(),
                    PasswordHash = Utils.EncryptedPassword(model.Password, salt),
                    PasswordSalt = salt,
                    PasswordResetCode = string.Empty,
                };

                var result = _accountDataProvider.Insert(account);
                rs.Success = ConvertHelper.ToBoolean(result.DataOutput);
                rs.Data = result.Data;
                rs.Message = result.UserMessage;
            }
            else
            {
                rs.Success = false;
                rs.Message = "Email da ton tai!";
            }

            return rs;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ResponseData> Login([FromBody] Login model)
        {
            ResponseData rs = new();
            var dbAccount = _accountDataProvider.GetByEmail(model.Email.Trim());
            if (dbAccount.Id != 0)
            {
                var password = Utils.EncryptedPassword(model.Password, dbAccount.PasswordSalt);
                if (dbAccount.PasswordHash != password)
                {
                    rs.Success = false;
                    rs.Message = "Sai password!";
                }
                else
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("Email", dbAccount.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["Jwt:ExpiryInDays"]));

                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: expiry,
                        signingCredentials: signIn
                        );


                    rs.Data = new JwtSecurityTokenHandler().WriteToken(token);
                    rs.Success = true;
                }
            }
            else
            {
                rs.Success = false;
                rs.Message = "Email khong ton tai!";
            }

            return rs;
        }
    }
}

