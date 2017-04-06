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

        QuoteHelperValues _valuesEURUSD = new QuoteHelperValues(0.0415, 0.023, 0.004);
        Symbol EURUSD = new Symbol { Name = "EURUSD" };
        QuoteHelperValues _valuesGBPUSD = new QuoteHelperValues(1.23, 0.150, 0.005);
        Symbol GBPUSD = new Symbol { Name = "GBPUSD" };

        static readonly int _daysAmount = 3;
        static readonly DateTime _startDateTime = new DateTime(2017, 4, 4, 0, 0, 0);

        protected override void Seed(DataBaseContext db)
        {
            db.Symbols.AddRange(new List<Symbol>() { EURUSD, GBPUSD });
            db.SaveChanges();

            DateTime datetime = _startDateTime;

            /******* Initialize  Quotes ********/
            for (int i = 0; i < 24 * _daysAmount; i++)
            {
                db.Quotes.Add(InitializeQuotes(new Quotes(EURUSD, datetime), _valuesEURUSD));
                db.Quotes.Add(InitializeQuotes(new Quotes(GBPUSD, datetime), _valuesGBPUSD));
                datetime = datetime.AddHours(1);
            }
            db.SaveChanges();
        }

        static double RandomDouable(double minValue = 0, double maxValue = 0)
        {
            var rndmNumb = random.NextDouble();
            return minValue + (rndmNumb * (maxValue - minValue));
        }
        /// <summary>
        /// Generate random values for quotes. Quotes.Open is requered.
        /// </summary>
        private Quotes InitializeQuotes(Quotes quotes, QuoteHelperValues helper)
        {
            quotes.Open = helper.FirstOpen;
            double temp = helper.FirstOpen - helper.Delta;
            quotes.Low = RandomDouable(temp < 0 ? 0 : temp, quotes.Open);
            quotes.High = RandomDouable(quotes.Open, quotes.Open + helper.Delta);
            quotes.Close = RandomDouable(quotes.Low, quotes.High);
            quotes.Volume = random.Next(0, helper.VolumeMax);
            temp = quotes.Close - helper.NextQuoteDeltaStep;
            helper.FirstOpen = RandomDouable(temp < 0 ? 0 : temp, quotes.Close + helper.NextQuoteDeltaStep);
            return quotes;
        }
    }
    public class QuoteHelperValues
    {
        public double NextQuoteDeltaStep { get; }
        public double FirstOpen { get; set; }
        public double Delta { get; }
        public int VolumeMax { get; }
        public QuoteHelperValues(double openValue, double delta, double nextStep, int volume)
        {
            NextQuoteDeltaStep = nextStep;
            FirstOpen = openValue;
            Delta = delta;
            VolumeMax = volume;
        }
        public QuoteHelperValues(double openValue, double delta, double nextStep) : this(openValue, delta, nextStep, int.MaxValue)
        {   }
    }
}