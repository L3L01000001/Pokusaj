using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login.Models;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source = LELA\\MSSQLSERVER_OLAP; database=loginbaza; integrated security = SSPI";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM tbl_login WHERE username ='"+acc.Username+"' AND pass='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}