using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WorkWithDb;
using ModComplexProject.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace ModComplexProject.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}