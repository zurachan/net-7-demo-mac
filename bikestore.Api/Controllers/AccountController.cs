using bikestore.Core.Common;
using bikestore.Core.Entity;
using bikestore.Core.Helper;
using bikestore.DataAccess.DataProvider.Management;
using bikestore.Entity.Management;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bikestore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDataProvider _accountDataProvider;

        public AccountController(IAccountDataProvider accountDataProvider)
        {
            _accountDataProvider = accountDataProvider;
        }

        // POST api/values
        [HttpPost]
        [Route("Signup")]
        public async Task<ResponseData> SignUp([FromBody] Register model)
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

        //[HttpGet("{Id:int}")]
        //public ResponseData GetById(int Id)
        //{
        //    ResponseData rs = new ResponseData();
        //    var data = _accountDataProvider.GetById(Id);
        //    rs.Data = data;
        //    rs.Success = true;
        //    return rs;
        //}
        //[HttpPost]
        //public ResponseData Insert(Store model)
        //{
        //    ResponseData rs = new ResponseData();
        //    var result = _accountDataProvider.Insert(model);
        //    rs.Success = ConvertHelper.ToBoolean(result.DataOutput);
        //    rs.Data = result.Data;
        //    rs.Message = result.UserMessage;
        //    return rs;
        //}
    }
}

