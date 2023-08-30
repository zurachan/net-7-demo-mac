using AutoMapper;
using bikestore.Core.Entity;
using bikestore.Entity.Auth;
using bikestore.Model.Model;
using bikestore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace bikestore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _userService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseData GetAll()
        {
            try
            {
                var users = _userService.GetAll();
                return new ResponseData { Success = true, Data = _mapper.Map<List<Account>, List<AccountModel>>(users) };
            }
            catch (Exception ex)
            {
                return new ResponseData { Success = false, Message = ex.Message };
            }
        }

        [HttpGet("{id}")]
        public ResponseData GetById(int id)
        {
            try
            {
                return new ResponseData { Success = true, Data = _mapper.Map<AccountModel>(_userService.GetById(id)) };
            }
            catch (Exception ex)
            {
                return new ResponseData { Success = false, Message = ex.Message };
            }
        }

        [HttpPost]
        public ResponseData Create(AccountModel model)
        {
            try
            {
                var result = _userService.Create(_mapper.Map<Account>(model));
                return new ResponseData { Success = true, Data = _mapper.Map<AccountModel>(result) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }

        [HttpPut]
        public ResponseData Update(AccountModel model)
        {
            try
            {
                var result = _userService.Update(_mapper.Map<Account>(model));
                return new ResponseData { Success = true, Data = _mapper.Map<AccountModel>(result) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }

        [HttpDelete("{id}")]
        public ResponseData Delete(int id)
        {
            try
            {
                return new ResponseData { Success = _userService.Delete(id) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }
    }
}