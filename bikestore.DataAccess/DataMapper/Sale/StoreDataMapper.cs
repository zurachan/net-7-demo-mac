using System.Data;
using bikestore.Core.Helper;
using bikestore.Entity.Sale;

namespace bikestore.DataAccess.DataMapper.Sale
{
    public class StoreDataMapper : DataMapper<Store>
    {
        protected override Store Map(IDataReader dr)
        {
            var model = new Store();

            model.Id = ConvertHelper.ToInt32(dr["store_id"]);
            model.Name = ConvertHelper.ToString(dr["store_name"]);
            model.Phone = ConvertHelper.ToString(dr["phone"]);
            model.Email = ConvertHelper.ToString(dr["email"]);
            model.Street = ConvertHelper.ToString(dr["street"]);
            model.City = ConvertHelper.ToString(dr["city"]);
            model.State = ConvertHelper.ToString(dr["state"]);
            model.ZipCode = ConvertHelper.ToString(dr["zip_code"]);

            return model;
        }
    }
}

