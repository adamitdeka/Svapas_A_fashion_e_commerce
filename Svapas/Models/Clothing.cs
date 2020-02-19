using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Svapas.Models
{
    public class Clothing
    {
        /*
        A clothing will have following data
        ClothingId
        ClothingName
        ClothingDem
        CategoryId
        ClothingSeller
        ClothingPrice
        */

        [Key]
        public int ClothingId { get; set; }//is the primary key
        public string ClothingName { get; set; }
        public string ClothingDem { get; set; } //Dem stands for demography(male| female| kids)
        public int CategoryId { get; set; } //representing 1 category in one category many clothings
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int ClothingPrice { get; set; } //all price is in cents
        public ICollection<Order> orders { get; set; }//representing many orders in many orders many clothings
    }
}