using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AutoMapper.Mapper;
using SoftFX_Task.EntityFramework.EntityModels;
using SoftFX_Task.Chart_Files;
using Newtonsoft.Json;

namespace SoftFX_Task.Controllers
{
    public class historyController : apiBase
    {
        public string Get(string symbol, long from, long to, string resolution)
        {
            var bars = Map<ICollection<Quote>, Bars>(_quoteRepo.GetList(x => x.Symbol.Name.ToUpper() == symbol && x.DateTime >= from && x.DateTime <= to));
            return JsonConvert.SerializeObject(bars);
        }
    }
}