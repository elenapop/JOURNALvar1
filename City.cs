using System;
using SQLite;

namespace JOURNAL.Tables
{
    public class City
    {

            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string CityName { get; set; }
            public int CityCountry { get; set; }
       
    }
}
