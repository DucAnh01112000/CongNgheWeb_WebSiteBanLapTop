using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.User.Models;


namespace WebsiteBanHang.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        // GET: User/Home
       
        public ActionResult Index()
        {
            return View();
        }
     
    }
}