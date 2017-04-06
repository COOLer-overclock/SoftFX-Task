using SoftFX_Task.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoftFX_Task.EntityFramework.EntityModels
{
    public class Quotes : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double Open { get; set; }
        [Required]
        public double High { get; set; }
        [Required]
        public double Low { get; set; }
        [Required]
        public double Close { get; set; }
        [Required]
        public double Volume { get; set; }
        [Required]
        public int SymbolId { get; set; }
        [Required]
        [ForeignKey("SymbolId")]
        public Symbol Symbol { get; set; }
        public Quotes()
        {
            Symbol = new Symbol();
        }
    }
}