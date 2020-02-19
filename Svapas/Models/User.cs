using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Svapas.Models
{
    public class User
    {
        /*
        An user will have following data
        userId
        userName
        userPassword
        userFname
        userLname
        userEmail
        userPhone
        */

        [Key]
        public int UserId { get; set; }//is the primary key
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }

        public ICollection<Order> Orders { get; set; } //representing many orders in one user many orders




    }
}