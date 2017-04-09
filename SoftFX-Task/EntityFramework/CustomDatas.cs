using SoftFX_Task.EntityFramework.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFX_Task.EntityFramework
{
    public static class CustomDatas
    {
        static readonly Random random = new Random();

        public static DateTime dateTime = new DateTime(2017, 3, 15, 0, 0, 0);
        static QuoteHelperValues _valuesEURUSD = new QuoteHelperValues(0.0415, 0.023, 0.004, 1000, true);
        static Symbol EURUSD = new Symbol { Name = "EURUSD" };
        static QuoteHelperValues _valuesGBPUSD = new QuoteHelperValues(2.23, 0.650, 0.01, 1500, true);
        static Symbol GBPUSD = new Symbol { Name = "GBPUSD" };
        static QuoteHelperValues _valuesGOLD = new QuoteHelperValues(120, 200, 40, 2500, false);
        static Symbol GOLD = new Symbol { Name = "GOLD" };

        static public ICollection<Symbol> GetSymbols()
        {
            return new List<Symbol> { EURUSD, GBPUSD, GOLD };
        } 

        public static void AddQuotesData(DataBaseContext db)
        {
            db.Symbols.Attach(EURUSD);
            db.Symbols.Attach(GBPUSD);
            db.Symbols.Attach(GOLD);
            db.Quotes.Add(InitializeQuotes(new Quote(EURUSD, dateTime), _valuesEURUSD));
            db.Quotes.Add(InitializeQuotes(new Quote(GBPUSD, dateTime), _valuesGBPUSD));
            db.Quotes.Add(InitializeQuotes(new Quote(GOLD, dateTime), _valuesGOLD));
        }
        public static void IncreaseDate()
        {
            dateTime = dateTime.AddHours(1);
        }
        static double RandomDouable(double minValue = 0, double maxValue = 0)
        {
            var rndmNumb = random.NextDouble();
            return minValue + (rndmNumb * (maxValue - minValue));
        }
        static double RandomInt(double minValue = 0, double maxValue = 0)
        {
            return (double)(random.Next((int)minValue, (int)maxValue));
        }
        static Quote InitializeQuotes(Quote quotes, QuoteHelperValues helper)
        {
            quotes.Open = helper.FirstOpen;
            double temp = helper.FirstOpen - helper.Delta;
            quotes.Low = helper.IsDouble ? RandomDouable(temp < 0 ? 0 : temp, quotes.Open)
                : RandomInt(temp < 0 ? 0 : temp, quotes.Open);
            quotes.High = helper.IsDouble ? RandomDouable(quotes.Open, quotes.Open + helper.Delta)
                : RandomInt(quotes.Open, quotes.Open + helper.Delta);
            quotes.Close = helper.IsDouble ? RandomDouable(quotes.Low, quotes.High)
                : RandomInt(quotes.Low, quotes.High);
            quotes.Volume = random.Next(0, helper.VolumeMax);
            temp = quotes.Close - helper.NextQuoteDeltaStep;
            helper.FirstOpen = helper.IsDouble ? RandomDouable(temp < 0 ? 0 : temp, quotes.Close + helper.NextQuoteDeltaStep)
                : RandomInt(temp < 0 ? 0 : temp, quotes.Close + helper.NextQuoteDeltaStep);
            return quotes;
        }
    }
    public class QuoteHelperValues
    {
        public bool IsDouble { get; set; }
        public double NextQuoteDeltaStep { get; }
        public double FirstOpen { get; set; }
        public double Delta { get; }
        public int VolumeMax { get; }
        public QuoteHelperValues(double openValue, double delta, double nextStep, int volume, bool isDouble)
        {
            IsDouble = isDouble;
            NextQuoteDeltaStep = nextStep;
            FirstOpen = openValue;
            Delta = delta;
            VolumeMax = volume;
        }
        public QuoteHelperValues(double openValue, double delta, double nextStep, bool isDouble) : this(openValue, delta, nextStep, int.MaxValue, isDouble)
        { }
    }
}