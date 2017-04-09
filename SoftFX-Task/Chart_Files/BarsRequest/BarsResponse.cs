using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFX_Task.Chart_Files
{
    public class BarsResponse
    {
        [JsonProperty(PropertyName = "s")]
        public string StatusCode { get; set; }
        [JsonProperty(PropertyName = "t")]
        public IEnumerable<long> Time { get; set; }
        [JsonProperty(PropertyName = "c")]
        public IEnumerable<double> Close { get; set; }
        
    }
}