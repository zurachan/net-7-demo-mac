using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace bikestore.DataAccess
{
    public class BaseDataProvider<T>
    {
        private static Dictionary<string, Database> _currentDBMap = new Dictionary<string, Database>();

        public virtual string DatabaseName { get; set; }

        public Database GetDatabase()
        {
            if (string.IsNullOrEmpty(DatabaseName))
            {
                DatabaseName = "DefaultConnection";
            }
            Database db = null;
            bool isLoadOk = _currentDBMap.TryGetValue(DatabaseName, out db);
            if (!isLoadOk || db == null)
            {
                db = DatabaseFactory.CreateDatabase(DatabaseName);
                if (_currentDBMap.ContainsKey(DatabaseName))
                {
                    _currentDBMap.Add(DatabaseName, db);
                }
                else
                {
                    _currentDBMap[DatabaseName] = db;
                }
            }

            return db;
        }

        public Database GetDatabase(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                DatabaseName = "DefaultConnection";
            }

            Database db = null;
            bool isLoadOk = _currentDBMap.TryGetValue(connectionString, out db);
            if (!isLoadOk || db == null)
            {
                db = new SqlDatabase(connectionString);
                _currentDBMap.Add(connectionString, db);
            }

            return db;
        }
    }
}

