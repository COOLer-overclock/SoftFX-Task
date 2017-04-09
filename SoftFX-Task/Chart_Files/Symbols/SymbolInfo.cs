using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFX_Task.Chart_Files
{
    public class SymbolInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "ticker")]
        public string Ticker { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "session")]
        public string Session { get; set; }//TradingSession Session { get; set; }
        [JsonProperty(PropertyName = "exchange")]
        public string Exchange { get; set; }
        [JsonProperty(PropertyName = "listed_exchange")]
        public string ListedExchange { get; set; }
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZone { get; set; }
        [JsonProperty(PropertyName = "pricescale")]
        public double PriceScale { get; set; }
        [JsonProperty(PropertyName = "minmov")]
        public double MinMov { get; set; }
        [JsonProperty(PropertyName = "fractional")]
        public bool Fractional { get; set; }
        [JsonProperty(PropertyName = "minmove2")]
        public double MinMove2 { get; set; }
        [JsonProperty(PropertyName = "has_intraday")]
        public bool HasIntraday { get; set; }
        [JsonProperty(PropertyName = "supported_resolutions")]
        public ICollection<string> SupportedResolutions { get; set; }
        [JsonProperty(PropertyName = "intraday_multipliers")]
        public ICollection<string> IntradayMultipliers { get; set; }
        [JsonProperty(PropertyName = "has_seconds")]
        public bool HasSeconds { get; set; }
        [JsonProperty(PropertyName = "seconds_multipliers")]
        public ICollection<string> SecondsMultipliers { get; set; }
        [JsonProperty(PropertyName = "has-daily")]
        public bool HasDaily { get; set; }
        [JsonProperty(PropertyName = "has_weekly_and_monthly")]
        public bool HasWeeklyAndMonthly { get; set; }
        [JsonProperty(PropertyName = "has_empty_bars")]
        public bool HasEmptyBars { get; set; }
        [JsonProperty(PropertyName = "force_session_rebuild")]
        public bool ForceSessionRebuild { get; set; }
        [JsonProperty(PropertyName = "has_no_volume")]
        public bool HasNoVolume { get; set; }
        [JsonProperty(PropertyName = "volume_precision")]
        public int VolumePrecision { get; set; }
        [JsonProperty(PropertyName = "data_status")]
        public string DataStatus { get; set; }
        [JsonProperty(PropertyName = "expired")]
        public bool Expired { get; set; }
        [JsonProperty(PropertyName = "expiration_date")]
        public long ExpirationDate { get; set; }
        [JsonProperty(PropertyName = "sector")]
        public string Sector { get; set; }
        [JsonProperty(PropertyName = "industry")]
        public string Industry { get; set; }
        [JsonProperty(PropertyName = "currency_code")]
        public int CurrencyCode { get; set; }
        public SymbolInfo()
        {
            Ticker = string.Empty;
            Description = string.Empty;
            Session = "24x7";
            Exchange = "";
            ListedExchange = "";
            TimeZone = "UTC";
            Fractional = false;
            MinMov = 1;
            PriceScale = 0.01;
            MinMove2 = 0;
            HasIntraday = true;
            SupportedResolutions = new List<string>() { "60", "120", "D" };
            IntradayMultipliers = new List<string>() { "60", "120" };
            HasSeconds = false;
            SecondsMultipliers = new List<string>() { };
            HasDaily = true;
            HasWeeklyAndMonthly = false;
            HasEmptyBars = false;
            ForceSessionRebuild = true;
            HasNoVolume = false;
            VolumePrecision = 0;
            DataStatus = nameof(Chart_Files.DataStatus.pulsed);
            Expired = false;
            ExpirationDate = 0;
            Sector = "";
            Industry = "";
            CurrencyCode = 0;
        }
    }
    public class TradingSession
    {
    }
    public enum TimeZone
    {
        UTC,
        America_New_York,
        America_Los_Angeles,
        America_Toronto,
        Europe_Moscow,
        Europe_London,
        Australia_Sydney,
        Asia_Tokyo,
        Asia_Dubai,
        Pacific_Honolulu,
        Africa_Johannesburg
    }
    public enum DataStatus
    {
        streaming,
        endofday,
        pulsed,
        dalayed_streamin 
    }
}