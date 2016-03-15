using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;
using MyMvxSimple.Core.Services.DataStore;

namespace MyMvxSimple.Core.Services
{
    public class DataService : IDataService
    {
        private readonly string databaseName = "Kitten.sqlite";
        private readonly SQLiteConnection _connection;
        private readonly IMvxSqliteConnectionFactory _sqlConnFac;

        public DataService(IMvxSqliteConnectionFactory sqlConnFac)
        {
            _sqlConnFac = sqlConnFac;
            var sqlConn = _sqlConnFac.GetConnection(databaseName);
            var config = new SqLiteConfig(databaseName);
            _connection = _sqlConnFac.GetConnection(config);
            _connection.CreateTable<Kitten>();
        }

        public int Count
        {
            get
            {
                return _connection.Table<Kitten>().Count();
            }
        }

        public void Delete(Kitten kitten)
        {
            _connection.Delete(kitten);
        }

        public void Insert(Kitten kitten)
        {
            _connection.Insert(kitten);
        }

        public List<Kitten> Search(string nameFilter)
        {
            return _connection.Table<Kitten>().OrderBy(x => x.price).Where(p => p.name.Contains(nameFilter)).ToList();
        }

        public void Update(Kitten kitten)
        {
            _connection.Update(kitten);
        }
    }
}
