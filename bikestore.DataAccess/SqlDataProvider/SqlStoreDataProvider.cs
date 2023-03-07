using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using bikestore.Core;
using bikestore.DataAccess.DataMapper.Sale;
using bikestore.DataAccess.DataProvider;
using bikestore.Entity.Sale;

namespace bikestore.DataAccess.SqlDataProvider
{
    public class SqlStoreDataProvider : IStoreDataProvider
    {
        private readonly ICommonService _commonService;

        public SqlStoreDataProvider(ICommonService commonService)
        {
            _commonService = commonService;
        }

        public List<Store> GetAll()
        {
            List<Store> result = new List<Store>();
            try
            {
                var connection = _commonService.GetConnectionString();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connection;

                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Store_GetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        var map = new StoreDataMapper();
                        result = map.MapAll(dataReader);
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}

