using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SoftFX_Task.Chart_Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SoftFX_Task.Controllers
{
    public class configController : apiBase
    {
        public string Get()
        {
            return JsonConvert.SerializeObject(new Configuration());
        }
    }
}