using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;

namespace JOURNAL.Tables
{
    public class RegisterCityTable
    {
        readonly SQLiteAsyncConnection _database;

        public string Name { get; internal set; }
        public int Country { get; internal set; }

        public RegisterCityTable(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<City>().Wait();
        }

        public Task<List<City>> GetPeopleAsync()
        {
            return _database.Table<City>().ToListAsync();
        }

        internal Task<IEnumerable> GetRegisterCityTableAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveCityAsync(City city)
        {
            return _database.InsertAsync(city);
        }

        internal Task SaveCityAsync(RegisterCityTable registerCityTable)
        {
            throw new NotImplementedException();
        }
    }
}


