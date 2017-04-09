using Newtonsoft.Json;
using SoftFX_Task.Chart_Files;
using SoftFX_Task.EntityFramework.EntityModels;
using static AutoMapper.Mapper;

namespace SoftFX_Task.Controllers
{
    public class symbolsController : apiBase
    {
        public string Get(string symbol)
        {
            int index = symbol.IndexOf(":");
            if (index > 0)
            {
                symbol = symbol.Substring(0, index);
            }
            var symbolModel = Map<Symbol, SymbolInfo>(_symbolRepo.Get(x => x.Name.ToUpper() == symbol));
            return JsonConvert.SerializeObject(symbolModel);
        }
    }
}