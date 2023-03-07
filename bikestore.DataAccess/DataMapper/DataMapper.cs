using System.Data;

namespace bikestore.DataAccess.DataMapper
{
    public abstract class DataMapper<T>
    {
        protected abstract T Map(IDataReader dr);

        public List<T> MapAll(IDataReader dr)
        {
            var lst = new List<T>();
            try
            {
                while (dr.Read())
                {
                    var mapInfo = Map(dr);
                    if (lst.IndexOf(mapInfo) < 0)
                    {
                        lst.Add(mapInfo);
                    }
                }
            }
            finally
            {
                dr.Close();
            }
            return lst;
        }
    }
}

