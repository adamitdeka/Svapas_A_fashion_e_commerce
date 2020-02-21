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
    public class ClothingController : Controller
    {
        private SvapasContext db = new SvapasContext();

        //list all clothing 
        public ActionResult List()
        {
            string query = "Select * from Clothings";
            List<Clothing> Clothings = db.Clothings.SqlQuery(query).ToList();
            return View(Clothings);
        }

        


        //show clothing
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Clothing Clothing = db.Clothings.SqlQuery("select * from clothings where ClothingId=@clothingId", new SqlParameter("@clothingId", id)).FirstOrDefault();
            if (Clothing == null)
            {
                return HttpNotFound();
            }
            return View(Clothing);
        }
    }
}