using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvxSimple.Core.Services.DataStore;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;

namespace MyMvxSimple.Core.Services
{
    public class CollectedItemService : ICollectedItemService
    {
        private readonly string databaseName = "CollectedItem.sqlite";
        private readonly SQLiteConnection _connection;
        private readonly IMvxSqliteConnectionFactory _sqlConnFac;

        public CollectedItemService(IMvxSqliteConnectionFactory sqlConnFac)
        {
            _sqlConnFac = sqlConnFac;
            var sqlConn = _sqlConnFac.GetConnection(databaseName);
            var config = new SqLiteConfig(databaseName);
            _connection = _sqlConnFac.GetConnection(config);
            _connection.CreateTable<CollectedItem>();
        }

        public void Add(CollectedItem collectedItem)
        {
            _connection.Insert(collectedItem);
        }

        public List<CollectedItem> All()
        {
            return _connection.Table<CollectedItem>().OrderByDescending(x => x.WhenUtc).ToList();
        }

        public void Delete(CollectedItem collectedItem)
        {
            _connection.Delete(collectedItem);
        }

        public void Update(CollectedItem collectedItem)
        {
            _connection.Update(collectedItem);
        }
    }
}
