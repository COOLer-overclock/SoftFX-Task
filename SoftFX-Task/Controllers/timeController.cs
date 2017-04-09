using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftFX_Task.Controllers
{
    public class timeController : apiBase
    {
        public long Get()
        {
            long unixTime = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds / 1000;
            return unixTime;
        }
    }
}
