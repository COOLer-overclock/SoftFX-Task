using SoftFX_Task.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SoftFX_Task.Controllers
{
    public class apiBase : ApiController
    {
        protected SymbolsRepository _symbolRepo = new SymbolsRepository();
        protected QuotesRepository _quoteRepo = new QuotesRepository();
    }
}