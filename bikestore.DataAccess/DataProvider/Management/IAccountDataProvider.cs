using bikestore.Core;
using bikestore.Entity.BikeStore.Management;

namespace bikestore.DataAccess.DataProvider.Management
{
    public interface IAccountDataProvider : IRepository<Account>
    {
        Account GetByEmail(string email);
    }
}

