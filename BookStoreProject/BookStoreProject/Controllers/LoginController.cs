using BookStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreProject.Controllers
{
    public class LoginController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;


        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult chkLogin(SearchLogin log)
        {
            con.ConnectionString = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True";


            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select * from Login where UserName='" + log.txtEmail + "' and Password='" + log.txtPassword + "'";

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return View("DashBoard");
            }
            else
            {
                con.Close();
                return View("Invalid");
            }
        }


    }
}