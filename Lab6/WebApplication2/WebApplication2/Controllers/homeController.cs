using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using Library3;
using Library4;


namespace WebApplication2.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public double Rezult(myClass ms)
        {
            KI3_Class_3 ex = new KI3_Class_3();
           
            double res = 0;
            res = ex.F3(ms.x, ms.y) + 2 * KI3_Class_4.F4(ms.x, ms.y) ;
            return res;
            
        }
    }
}