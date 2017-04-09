using Newtonsoft.Json;
using SoftFX_Task.Chart_Files;
using SoftFX_Task.EntityFramework.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static AutoMapper.Mapper;

namespace SoftFX_Task.Controllers
{
    public class searchController : apiBase
    {
        public string Get(string query, string type, string exchange, int limit)
        {
            var data = _symbolRepo.GetList(x => x.Name.ToUpper().Contains(query));
            if (data != null)
            {
                return JsonConvert.SerializeObject(Map<ICollection<Symbol>, ICollection<SymbolSearchResponse>>(data));
            }   
            return JsonConvert.SerializeObject(new List<SymbolSearchResponse>());
        }
    }
}