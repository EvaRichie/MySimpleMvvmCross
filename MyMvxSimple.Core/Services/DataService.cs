using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;

namespace MyMvxSimple.Core.Services
{
    public class DataService : IDataService
    {
        private readonly string databaseName = "Kitten.sqlite";
        private readonly SQLiteConnection _connection;
        private readonly IMvxSqliteConnectionFactory _sqlConn;

        public DataService(IMvxSqliteConnectionFactory sqlConnFac)
        {
            _sqlConn = sqlConnFac;
            var sqlConn = _sqlConn.GetConnection(databaseName);
            var config = new SqLiteConfig(databaseName);
            _connection = _sqlConn.GetConnection(config);
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
