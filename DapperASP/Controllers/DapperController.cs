using Dapper;
using DapperASP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperASP.Controllers
{
    public class DapperController : Controller
    {
        // GET: Dapper
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public String Index()
        {
            string output = "";

            string ConnectionString = ConfigurationManager.ConnectionStrings["DapperConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var persons = connection.Query<User>("Select * FROM Users").ToList();

                foreach (User person in persons)
                {
                    output += person.username;
                }


            }

            return output;
        }
    }
}