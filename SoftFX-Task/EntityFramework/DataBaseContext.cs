using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SoftFX_Task.EntityFramework.EntityModels;
using System.Globalization;
using static SoftFX_Task.EntityFramework.CustomDatas;

namespace SoftFX_Task.EntityFramework
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DataBaseContext()
        {
        }
        static DataBaseContext()
        {
            Database.SetInitializer<DataBaseContext>(new DatabaseContextInitializer());
        }
    }
    class DatabaseContextInitializer : DropCreateDatabaseAlways<DataBaseContext>
    {
        static readonly int _daysAmount = 3;
        static readonly int _multiplier = 24;

        protected override void Seed(DataBaseContext db)
        {
            db.Symbols.AddRange(CustomDatas.GetSymbols());
            db.SaveChanges();

            /******* Initialize  Quotes ********/
            /*for (int i = 0; i < _multiplier * _daysAmount; i++)
            {
                AddQuotesData(db);
                IncreaseDate();
            }*/
            while(CustomDatas.dateTime <= new DateTime(2017, 4, 7, 0, 0, 0))
            {
                AddQuotesData(db);
                IncreaseDate();
            }
            db.SaveChanges();
        }
    }
}