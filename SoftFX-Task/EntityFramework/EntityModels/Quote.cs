using Newtonsoft.Json;
using SoftFX_Task.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoftFX_Task.EntityFramework.EntityModels
{
    public class Quote : IEntity
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "time")]
        [Required]
        public long DateTime { get; set; }
        [Required]
        public double Open { get; set; }
        [Required]
        public double High { get; set; }
        [Required]
        public double Low { get; set; }
        [Required]
        public double Close { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        [ForeignKey("Symbol")]
        public int SymbolId { get; set; }
        [Required]
        public Symbol Symbol { get; set; }
        public Quote()
        { }
        public Quote(Symbol symbol, DateTime datetime)
        {
            Symbol = symbol;
            long timestamp = (long)((long)(datetime - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
            DateTime = timestamp;
        }
    }
}