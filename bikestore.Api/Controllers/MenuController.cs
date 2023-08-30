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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuController(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseData GetAll()
        {
            try
            {
                var users = _menuService.GetAll();
                return new ResponseData { Success = true, Data = _mapper.Map<List<Menu>, List<MenuModel>>(users) };
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
                return new ResponseData { Success = true, Data = _mapper.Map<MenuModel>(_menuService.GetById(id)) };
            }
            catch (Exception ex)
            {
                return new ResponseData { Success = false, Message = ex.Message };
            }
        }

        [HttpPost]
        public ResponseData Create(MenuModel model)
        {
            try
            {
                var result = _menuService.Create(_mapper.Map<Menu>(model));
                return new ResponseData { Success = true, Data = _mapper.Map<MenuModel>(result) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }

        [HttpPut]
        public ResponseData Update(MenuModel model)
        {
            try
            {
                var result = _menuService.Update(_mapper.Map<Menu>(model));
                return new ResponseData { Success = true, Data = _mapper.Map<MenuModel>(result) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }

        [HttpDelete("{id}")]
        public ResponseData Delete(int id)
        {
            try
            {
                return new ResponseData { Success = _menuService.Delete(id) };
            }
            catch (Exception ex) { return new ResponseData { Success = false, Message = ex.Message }; }
        }
    }
}
