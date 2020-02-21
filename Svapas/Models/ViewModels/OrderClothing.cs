using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Svapas.Models.ViewModels
{
    public class OrderClothing
    {
        public Clothing Clothing { get; set; }
        public Order Order { get; set; }

        public List<Clothing> Clothings { get; set; }
        public List<Order> Orders { get; set; }

        
    }
}