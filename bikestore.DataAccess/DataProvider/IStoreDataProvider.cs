using bikestore.Entity.Sale;

namespace bikestore.DataAccess.DataProvider
{
    public interface IStoreDataProvider
    {
        List<Store> GetAll();
    }
}
