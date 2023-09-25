using bikestore.Core.Entity;
using bikestore.Entity;
using bikestore.Model.Authentication;
using bikestore.Model.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bikestore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private IConfiguration _configuration;
        private IHttpContextAccessor _contextAccessor;

        public AuthenticationController(AppDbContext context, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ResponseData Login(AuthenRequest model)
        {
            try
            {
                AuthenResponse response = new();
                if (ModelState.IsValid)
                {
                    var account = _context.Accounts.Include(x => x.User).FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
                    if (account != null)
                    {
                        var role = _context.UserRoles.Include(x => x.Role).FirstOrDefault(x => x.UserId == account.UserId);
                        //create claims details based on the user information
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("Username", account.Username),
                        new Claim("Fullname", account.User.FullName),
                        new Claim("Address", account.User.Address),
                        new Claim (ClaimTypes.Role, role.Role.Name),
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["Jwt:ExpiryInDays"]));

                        var tokenDescriptor = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: expiry,
                            signingCredentials: signIn
                            );

                        response.Token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
                    }
                }
                return new ResponseData { Success = true, Data = response };
            }
            catch (Exception ex)
            {
                return new ResponseData { Success = false, Message = ex.Message };
            }
        }
    }
}
