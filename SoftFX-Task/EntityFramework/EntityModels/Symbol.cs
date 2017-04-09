using SoftFX_Task.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftFX_Task.EntityFramework.EntityModels
{
    public class Symbol : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Quote> Quotes { get; set; }
        public Symbol()
        {
            Quotes = new List<Quote>();
        }
    }
}