using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using WebsiteBanHang.Areas.Admin.Models.DAO;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class HangSXController : Controller
    {
        WebsiteModel db;
        // GET: Admin/HangSX
        public HangSXController()
        {
            db = new WebsiteModel();
        }
        public ActionResult Index(string timkiem, int PageNum = 1, int PageSize = 2)
        {
            HangSXDAO dao = new HangSXDAO();
            return View(dao.ListHangSX(timkiem, PageNum, PageSize));
        }
        public ActionResult Create()
        {
            ViewBag.MaHangSX = new SelectList(db.HangSX.ToList().OrderBy(n => n.MaHangSX), "MaHangSX", "TenHangSX");
            return View();
        }
        [HttpPost]
        public ActionResult Create(HangSX h)
        {
            if (ModelState.IsValid)
            {
                HangSXDAO dao = new HangSXDAO();
                dao.Add(h);
                return RedirectToAction("Index");
            }else
                return View(h);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.MaHangSX = new SelectList(db.HangSX.ToList().OrderBy(n => n.MaHangSX), "MaHangSX", "TenHangSX");
            HangSXDAO dao = new HangSXDAO();
            HangSX h = new HangSX();
            h = dao.GetIdHangSX(id);
            return View(h);
        }
        [HttpPost]
        public ActionResult Edit(HangSX h)
        {
            if (ModelState.IsValid)
            {
                HangSXDAO dao = new HangSXDAO();
                dao.Edit(h);
                return RedirectToAction("Index");
            }
            else
                return View(h);
        }
      
        public ActionResult Delete(int id)
        {
            HangSXDAO dao = new HangSXDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}