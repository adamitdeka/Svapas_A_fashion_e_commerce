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
using Svapas.Models.ViewModels;
using System.Diagnostics;
using System.IO;
using Svapas.Controllers;


namespace Svapas.Controllers
{
    public class OrderController : Controller
    {
        private SvapasContext db = new SvapasContext();
        //private UserController user = new UserController();
        private int LoggedUserId = UserController.LoggedInUserId;
        
        public ActionResult Buy(int? id)
        {
            Debug.WriteLine("Logged User id == " + LoggedUserId);
            //get clothing price
            string query = "select * from Clothings where ClothingId="+id;
            Debug.WriteLine("Executing "+query);
            Clothing Clothing = db.Clothings.SqlQuery(query).FirstOrDefault();
            int OrderPrice = Clothing.ClothingPrice;

            //add data in orders table
            query = "insert into orders(UserId, OrderDateTime, OrderPrice) values(@userId, @orderDateTime, @orderPrice)";
            Debug.WriteLine("Executing"+query);
            SqlParameter[] sqlparamsOrders = new SqlParameter[3];
            DateTime CurDate = DateTime.Now;
            sqlparamsOrders[0] = new SqlParameter("@userId", LoggedUserId);
            sqlparamsOrders[1] = new SqlParameter("@orderDateTime", CurDate);
            sqlparamsOrders[2] = new SqlParameter("@orderPrice", OrderPrice);
            db.Database.ExecuteSqlCommand(query, sqlparamsOrders);

            //add data in ordersxclothings table
            query = "select * from Orders where userId = " + LoggedUserId ;
            Debug.WriteLine("Executing " + query);
            Order Order = db.Orders.SqlQuery(query).FirstOrDefault();

            query = "insert into OrderClothings (Order_OrderId, Clothing_ClothingId) values(@orderId, @clothingId)";
            Debug.WriteLine("Executing " + query);
            SqlParameter[] sqlparamsOrderClothings = new SqlParameter[2];

            sqlparamsOrderClothings[0] = new SqlParameter("@orderId", Order.OrderId);
            sqlparamsOrderClothings[1] = new SqlParameter("@clothingId", id);
            db.Database.ExecuteSqlCommand(query, sqlparamsOrderClothings);

            //display data of orders
            OrderClothing ViewModel = new OrderClothing();
            ViewModel.Clothing = Clothing;
            ViewModel.Order = Order;
            return View(ViewModel);
            
        }

        public ActionResult List()
        {
            string query = "Select * from orders where userId = " + LoggedUserId;
            Debug.WriteLine("Executing " + query);
            List<Order> Order = db.Orders.SqlQuery(query).ToList();

            query = "Select * from Clothings";
            Debug.WriteLine("Executing " + query);
            List<Clothing> Clothing = db.Clothings.SqlQuery(query).ToList();

            OrderClothing ViewModel = new OrderClothing();
            ViewModel.Clothings = Clothing;
            ViewModel.Orders = Order;
            return View(ViewModel);
        }
    }
}
