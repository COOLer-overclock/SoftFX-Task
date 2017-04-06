using SoftFX_Task.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftFX_Task.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext _db = new DataBaseContext();
        public ActionResult Index()
        {
            _db.Symbols.ToList();
            return View();
        }
    }
}