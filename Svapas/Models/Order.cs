using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Svapas.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; } //representing 1 user in one user many orders
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int OrderPrice { get; set; } //all price is in cents
        public ICollection<Clothing> Clothings { get; set; } //representing many clothings in many orders many clothings
    }
}