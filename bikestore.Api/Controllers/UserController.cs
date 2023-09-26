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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService roleService, IMapper mapper)
        {
            _userService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseData GetAll()
        {
            try
            {
                var roles = _userService.GetAll();
                return new ResponseData { Success = true, Data = _mapper.Map<List<User>, List<UserModel>>(roles) };
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
                return new ResponseData { Success = true, Data = _mapper.Map<UserModel>(_userService.GetById(id)) };
            }
            catch (Exception ex)
            {
                return new ResponseData { Success = false, Message = ex.Message };
            }
        }

        [HttpPost]
        public ResponseData Create(UserModel model)
        {
            try
            {
                var result = _userService.Create(_mapper.Map<User>(model));
                return new ResponseData { Success = true, Data = _mapper.Map<UserModel>(result) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }

        [HttpPut]
        public ResponseData Update(UserModel model)
        {
            try
            {
                var result = _userService.Update(_mapper.Map<User>(model));
                return new ResponseData { Success = true, Data = _mapper.Map<UserModel>(result) };
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