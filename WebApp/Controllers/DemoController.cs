using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        // GET: Demo/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}