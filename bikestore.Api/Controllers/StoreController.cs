using bikestore.Core.Entity;
using bikestore.DataAccess.DataProvider;
using bikestore.Entity.Sale;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bikestore.Api.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {
        private readonly IStoreDataProvider _storeDataProvider;

        public StoreController(IStoreDataProvider storeDataProvider)
        {
            _storeDataProvider = storeDataProvider;
        }


        // GET: api/values
        [HttpGet]
        public ResponseData GetAll()
        {
            ResponseData rs = new ResponseData();
            var data = _storeDataProvider.GetAll();

            rs.Data = data;
            rs.Success = true;

            return rs;
            //return rs JsonConvert.SerializeObject(rs);
        }

        [HttpGet("{Id:int}")]
        public ResponseData GetById(int Id)
        {
            ResponseData rs = new ResponseData();

            return rs;
        }
        [HttpPost]
        public ResponseData Create(Store model)
        {
            ResponseData rs = new ResponseData();

            return rs;
        }
        [HttpPut]
        public ResponseData Update(Store model)
        {
            ResponseData rs = new ResponseData();

            return rs;
        }
        [HttpDelete("{Id:int}")]
        public ResponseData Delete(int Id)
        {
            ResponseData rs = new ResponseData();

            return rs;
        }

    }
}

