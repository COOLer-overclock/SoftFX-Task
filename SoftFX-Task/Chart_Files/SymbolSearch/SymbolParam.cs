using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFX_Task.Chart_Files
{
    public class SymbolParam
    {
        public string Query { get; set; }
        public string Type { get; set; }
        public string Exchange { get; set; }
        public int Limit { get; set; }
    }
}