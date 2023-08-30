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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseData GetAll()
        {
            try
            {
                var users = _roleService.GetAll();
                return new ResponseData { Success = true, Data = _mapper.Map<List<Role>, List<RoleModel>>(users) };
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
                return new ResponseData { Success = true, Data = _mapper.Map<RoleModel>(_roleService.GetById(id)) };
            }
            catch (Exception ex)
            {
                return new ResponseData { Success = false, Message = ex.Message };
            }
        }

        [HttpPost]
        public ResponseData Create(RoleModel model)
        {
            try
            {
                var result = _roleService.Create(_mapper.Map<Role>(model));
                return new ResponseData { Success = true, Data = _mapper.Map<RoleModel>(result) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }

        [HttpPut]
        public ResponseData Update(RoleModel model)
        {
            try
            {
                var result = _roleService.Update(_mapper.Map<Role>(model));
                return new ResponseData { Success = true, Data = _mapper.Map<RoleModel>(result) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }

        [HttpDelete("{id}")]
        public ResponseData Delete(int id)
        {
            try
            {
                return new ResponseData { Success = _roleService.Delete(id) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }
    }
}
