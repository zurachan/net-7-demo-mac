using bikestore.Core.Entity;
using bikestore.Core.Helper;
using bikestore.DataAccess.DataProvider;
using bikestore.Entity.Management;
using bikestore.Entity.Sale;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bikestore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreDataProvider _storeDataProvider;

        public StoreController(IStoreDataProvider storeDataProvider)
        {
            _storeDataProvider = storeDataProvider;
        }

        [Authorize]
        [HttpGet]
        public ResponseData GetAll()
        {
            ResponseData rs = new ResponseData();
            var data = _storeDataProvider.GetAll();
            rs.Success = true;
            rs.Data = data;
            rs.DataTotalValue = data.Count;
            return rs;
        }
        [HttpGet("{Id:int}")]
        public ResponseData GetById(int Id)
        {
            ResponseData rs = new ResponseData();
            var data = _storeDataProvider.GetById(Id);
            rs.Data = data;
            rs.Success = true;
            return rs;
        }
        [HttpPost]
        public ResponseData Insert(Store model)
        {
            ResponseData rs = new ResponseData();
            var result = _storeDataProvider.Insert(model);
            rs.Success = ConvertHelper.ToBoolean(result.DataOutput);
            rs.Data = result.Data;
            rs.Message = result.UserMessage;
            return rs;
        }
        [HttpPut]
        public ResponseData Update(Store model)
        {
            ResponseData rs = new ResponseData();
            var result = _storeDataProvider.Update(model);
            rs.Success = ConvertHelper.ToBoolean(result.DataOutput);
            rs.Data = result.Data;
            rs.Message = result.UserMessage;
            return rs;
        }
        [HttpDelete("{Id:int}")]
        public ResponseData Delete(int Id)
        {
            ResponseData rs = new ResponseData();
            var result = _storeDataProvider.Delete(Id);
            rs.Success = ConvertHelper.ToBoolean(result.DataOutput);
            rs.Message = result.UserMessage;
            return rs;
        }
    }
}

