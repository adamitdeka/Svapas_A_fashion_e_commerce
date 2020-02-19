using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Svapas.Data
{
    public class SvapasContext: DbContext
    {
        public SvapasContext() : base("name=SvapasContext")
        { 
        }
        public System.Data.Entity.DbSet<Svapas.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<Svapas.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Svapas.Models.Clothing> Clothings { get; set; }
        public System.Data.Entity.DbSet<Svapas.Models.Category> Categories { get; set; }
    }

}
