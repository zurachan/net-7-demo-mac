using System.Data;
using bikestore.Core.Helper;
using bikestore.Entity.BikeStore.Management;

namespace bikestore.DataAccess.DataMapper.Management
{
    public class AccountDataMapper : DataMapper<Account>
    {
        protected override Account Map(IDataReader dr)
        {
            Account model = new();
            model.Id = ConvertHelper.ToInt32(dr["Id"]);
            model.Email = ConvertHelper.ToString(dr["Email"]);
            model.PasswordHash = ConvertHelper.ToString(dr["PasswordHash"]);
            model.PasswordSalt = ConvertHelper.ToString(dr["PasswordSalt"]);
            model.PasswordResetCode = ConvertHelper.ToString(dr["PasswordResetCode"]);
            return model;
        }
    }
}

