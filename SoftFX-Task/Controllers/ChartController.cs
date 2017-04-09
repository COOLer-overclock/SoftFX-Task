using static AutoMapper.Mapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SoftFX_Task.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftFX_Task.Chart_Files;
using System.Web.Mvc;
using SoftFX_Task.EntityFramework.EntityModels;

namespace SoftFX_Task.Controllers
{
    public class ChartController : Controller
    {
        QuotesRepository _quoteRepo;
        SymbolsRepository _symbolRepo;

        [HttpGet]
        public ContentResult OnReady()
        {
            string json = JsonConvert.SerializeObject(new Configuration(),
                Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return new ContentResult { Content = json, ContentType = "application/json" };
        }
        [HttpGet]
        public ContentResult SearchSymbols(string searchString)
        {
            var data = _symbolRepo.GetList(x => x.Name.ToUpper().Contains(searchString));
            if (data != null)
            {
                string json = JsonConvert.SerializeObject(Map<ICollection<Symbol>, ICollection<SymbolSearchResponse>>(data),
                    Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                return new ContentResult { Content = json, ContentType = "application/json" };
            }
            else
                return new ContentResult { Content = null, ContentType = "application/json" };
        }
        [HttpGet]
        public ContentResult ResolveSymbol(string symbolName)
        {
            int index = symbolName.IndexOf("?");
            if(index > 0)
            {
                symbolName = symbolName.Substring(0, index);
            }
            var symbol = _symbolRepo.Get(x => x.Name.ToUpper() == symbolName);
            if (symbol != null)
            {
                var symbolInfo = Map<Symbol, SymbolInfo>(symbol);
                string json = JsonConvert.SerializeObject(symbolInfo,
                    Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                return new ContentResult { Content = json, ContentType = "application/json" };
            }
            return new ContentResult { Content = null, ContentType = "application/json" };
        }
        [HttpGet]
        public long GetServerTime()
        {
            long unixTime = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds / 1000;
            return unixTime;
        }
       /* [HttpGet]
        public ContentResult GetBars(string name, string resolution, long from, long to)
        {
            var data = Map<ICollection<Quote>, ICollection<Bar>>(_quoteRepo.GetList(x => x.Symbol.Name.ToUpper() == name && (x.DateTime > from)));
            var bars = new BarsResponse(data);
            string json = JsonConvert.SerializeObject(bars, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return new ContentResult { Content = json, ContentType = "application/json" };
        }*/




       /* [HttpGet]
        public ContentResult GetQuotes()
        {
            var data = Map<ICollection<Quote>, ICollection<SymbolQuoteData>>(_quoteRepo.GetList());
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return new ContentResult { Content = json, ContentType = "application/json" };
        }*/
        [HttpGet]
        public ContentResult GetSymbols()
        {
            var symbols = _symbolRepo.GetList().Select(x => x.Name).ToList();
            string json = JsonConvert.SerializeObject(symbols, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return new ContentResult { Content = json, ContentType = "application/json" };
        }

        public ChartController()
        {
            this._quoteRepo = new QuotesRepository();
            this._symbolRepo = new SymbolsRepository();
        }
    }
}