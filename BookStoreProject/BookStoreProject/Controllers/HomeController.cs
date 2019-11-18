using BookStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreProject.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult feed(Contact log)
        {

            con.ConnectionString = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True";


            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "insert into FeedBack(Name,Email,Contact,Message) values('" + log.txtName + "','" + log.txtEmail + "','" + log.txtContact + "','" + log.txtMsg + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            return View("FeedBackAlert");


        }


    }
}