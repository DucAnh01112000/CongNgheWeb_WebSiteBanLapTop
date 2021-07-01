using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using WebsiteBanHang.Areas.Admin.Models.DAO;
using System.IO;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class USController : Controller
    {
        // GET: Admin/US
        WebsiteModel db;
        public USController()
        {
            db = new WebsiteModel();
        }
        public ActionResult Index(string timkiem, int PageNum = 1, int PageSize = 2)
        {
            UserDAO dao = new UserDAO();
            return View(dao.ListUS(timkiem, PageNum, PageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(US u)
        {
            if (ModelState.IsValid)
            {
                UserDAO dao = new UserDAO();
                dao.Add(u);
                return RedirectToAction("Index");
            }
            else
                return View(u);
            
        }
        public ActionResult Edit(string id)
        {
            UserDAO dao = new UserDAO();
            US u = new US();
            u = dao.GetIdUS(id);
            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(US u)
        {
            if (ModelState.IsValid)
            {
                UserDAO dao = new UserDAO();
                dao.Edit(u);
                return RedirectToAction("Index");
            }
            else
                return View(u);
        }
        public ActionResult Delete(string id)
        {
            UserDAO dao = new UserDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}