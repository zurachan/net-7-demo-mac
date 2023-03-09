using bikestore.Core;
using bikestore.Entity.Management;

namespace bikestore.DataAccess.DataProvider.Management
{
    public interface IAccountDataProvider : IRepository<Account>
    {
        Account GetByEmail(string email);
    }
}

