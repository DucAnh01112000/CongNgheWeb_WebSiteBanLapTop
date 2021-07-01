using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models.DAO;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return Redirect("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            UserDAO dao = new UserDAO();
            if (dao.checkLogin(username, password))
            {
                Session["username"] = username;
                return Redirect("../Product/Index");
            }
            else
            {
                return Redirect("Login");
            }

        }
    }
}