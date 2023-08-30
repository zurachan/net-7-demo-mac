namespace bikestore.Service.Interface
{
    public interface IRepository<T>
    {
        T Create(T model);
        T Update(T model);
        List<T> GetAll();
        T GetById(int id);
        bool Delete(int id);
    }
}
