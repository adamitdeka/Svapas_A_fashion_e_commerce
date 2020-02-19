using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Svapas.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }//is the primary key
        public string CategoryName { get; set; }
        public ICollection<Clothing> Clothings { get; set; } // representing many in 1 category many clothings
    }
}