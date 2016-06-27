using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chooseName.Code;
namespace chooseName.Controllers
{
    public class HomeController : Controller
    {
      
        //
        // GET: /Home/

        public ActionResult Index()
        {
            SqliteManager manager = new SqliteManager();
            //public Program()
            //{
            manager.createNewDatabase();
            manager.connectToDatabase();
            manager.createTable();
            manager.fillTable();
            manager.printHighscores();
            //}
            return View();
        }

    }
}
