using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SoftFX_Task.EntityFramework.EntityModels;
using System.Globalization;

namespace SoftFX_Task.EntityFramework
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<Quotes> Quotes { get; set; }
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
        static readonly Random random = new Random();
        static double RandomDouable(double minValue = 0, double maxValue = 0)
        {
            var rndmNumb = random.NextDouble();
            return minValue + (rndmNumb * (maxValue - minValue));
        }

        static readonly double _nextQuoteMaxStepUSD = 0.004;
        static readonly double _deltaMinUSD = 0.023;
        static readonly double _deltaMaxUSD = 0.014;
        static readonly double _firstOpenUSD = 0.0415;

        static readonly int _daysAmount = 3;
        static readonly DateTime _startDateTime = new DateTime(2017, 4, 4, 0, 0, 0);

        /// <summary>
        /// Generate random values for quotes. Quotes.Open is requered.
        /// </summary>
        private Quotes InitializeQuotes(Quotes quotes)
        {
            quotes.Low = RandomDouable(quotes.Open - _deltaMinUSD, quotes.Open);
            quotes.High = RandomDouable(quotes.Open, quotes.Open + _deltaMaxUSD);
            quotes.Close = RandomDouable(quotes.Low, quotes.High);
            quotes.Volume = 0;
            return quotes;
        }

        protected override void Seed(DataBaseContext db)
        {
            Symbol EURUSD = new Symbol { Name = "EURUSD" };
            Symbol GOLD = new Symbol { Name = "GOLD" };
            Symbol USDJPY = new Symbol { Name = "USDJPY" };
            db.Symbols.AddRange(new List<Symbol>() { EURUSD, GOLD, USDJPY });
            db.SaveChanges();

            DateTime datetime = _startDateTime;
            Quotes temp = new Quotes();
            temp.Open = _firstOpenUSD;
            double tempClose;
            /******* Initialize EURUSD bars ********/
            for (int i = 0; i < 24 * _daysAmount; i++)
            {
                InitializeQuotes(temp);
                temp.DateTime = datetime;
                temp.Symbol = EURUSD;
                db.Quotes.Add(temp);
                tempClose = temp.Close;
                datetime = datetime.AddHours(1);
                temp = new Quotes();
                temp.Open = RandomDouable(tempClose - _nextQuoteMaxStepUSD, tempClose + _nextQuoteMaxStepUSD);
            }
            db.SaveChanges();
        }
    }
}