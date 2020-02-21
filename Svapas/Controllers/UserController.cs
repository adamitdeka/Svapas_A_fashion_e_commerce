using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Svapas.Data;
using Svapas.Models;
using System.Diagnostics;
using System.IO;

namespace Svapas.Controllers
{
    public class UserController : Controller
    {
        private SvapasContext db = new SvapasContext();
        public static int LoggedInUserId;

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string UserName, string UserPassword, string UserFname, string UserLname, string UserEmail, string UserPhone)
        {
            string query = "insert into Users(UserName, UserPassword, UserFname, UserLname, UserEmail, UserPhone) Values(@userName, @userPassword, @userFname, @userLname, @userEmail, @userPhone)";

            SqlParameter[] sqlparams = new SqlParameter[6];

            sqlparams[0] = new SqlParameter("@userName", UserName);
            sqlparams[1] = new SqlParameter("@userPassword", UserPassword);
            sqlparams[2] = new SqlParameter("@userFname", UserFname);
            sqlparams[3] = new SqlParameter("@userLname", UserLname);
            sqlparams[4] = new SqlParameter("@userEmail", UserEmail);
            sqlparams[5] = new SqlParameter("@userPhone", UserPhone);

            db.Database.ExecuteSqlCommand(query, sqlparams);

            return Redirect("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string UserPassword)
        {
            string query = "select * from Users where userName= '"+UserName+"' and userPassword= '"+UserPassword+"'";
            Debug.WriteLine("Query running---"+query);
            User User = db.Users.SqlQuery(query).FirstOrDefault();
           
            if(User == null)
            {
                return View();
                
            }
            else
            {
                LoggedInUserId = User.UserId;
                return Redirect("UserProfile/"+User.UserId);
            }
        }
        
        public ActionResult UserProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User User = db.Users.SqlQuery("select * from users where UserId=@userId", new SqlParameter("@userId", id)).FirstOrDefault();
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

    }
}