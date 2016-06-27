using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using chooseName.Code;
using chooseName.Code.DAL;

using chooseName.Code.Model;
namespace chooseName.Controllers
{
    public class HomeController : Controller
    {
      
        //
        // GET: /Home/

        public ActionResult Index()
        {

            List<NumerologyPattern> patterns = new List<NumerologyPattern>();
            patterns.Add(new NumerologyPattern() { Alphabet = "A", Value = 3 });
            patterns.Add(new NumerologyPattern() { Alphabet = "B", Value = 4 });
            patterns.Add(new NumerologyPattern() { Alphabet = "C", Value = 5 });
            patterns.Add(new NumerologyPattern() { Alphabet = "D", Value = 6 });
            string patt = XmlUtility.ToXML<List<NumerologyPattern>>(patterns);


            string xml = System.IO.File.ReadAllText(@"C:\Apps\getme.xml");

            List<NumerologyPattern> getpat = XmlUtility.FromXML<List<NumerologyPattern>>(xml);
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
