using bikestore.Core.Entity;
using bikestore.DataAccess.DataProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bikestore.Api.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly IStoreDataProvider _storeDataProvider;

        public StoreController(IStoreDataProvider storeDataProvider)
        {
            _storeDataProvider = storeDataProvider;
        }


        // GET: api/values
        [HttpGet]
        [Route("GetAll")]
        public ResponseData GetAll()
        {
            ResponseData rs = new ResponseData();
            var data = _storeDataProvider.GetAll();

            rs.Data = data;
            rs.Success = true;

            return rs;
            //return rs JsonConvert.SerializeObject(rs);
        }
    }
}

