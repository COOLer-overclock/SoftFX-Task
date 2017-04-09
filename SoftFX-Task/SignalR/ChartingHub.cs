using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Web.Mvc;
using Newtonsoft.Json;
using SoftFX_Task.Chart_Files;
using Newtonsoft.Json.Serialization;
using SoftFX_Task.EntityFramework.EntityModels;
using SoftFX_Task.Services.Repositories;
using static AutoMapper.Mapper;
using System.Threading.Tasks;

namespace SoftFX_Task.SignalR
{
    public class ChartingHub : Hub
    {
        SymbolsRepository _symbolRepo = new SymbolsRepository();
        QuotesRepository _quoteRepo = new QuotesRepository();
        public void Connect(string name)
        {
            return;
        }
        public ContentResult OnReady()
        {
            string json = JsonConvert.SerializeObject(new Configuration(),
                Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return new ContentResult { Content = json, ContentType = "application/json" };
        }
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
        public ContentResult ResolveSymbol(string symbolName)
        {
            int index = symbolName.IndexOf(":");
            if (index > 0)
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
        /*public ContentResult GetBars(string name, string resolution, long from, long to)
        {
            var data = Map<ICollection<Quote>, ICollection<Bar>>(_quoteRepo.GetList(x => x.Symbol.Name.ToUpper() == name && (x.DateTime > from)));
            var bars = new BarsResponse(data);
            string json = JsonConvert.SerializeObject(bars, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return new ContentResult { Content = json, ContentType = "application/json" };
        }*/
        public long GetServerTime()
        {
            long unixTime = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds / 1000;
            return unixTime;
        }
    }
}