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
    public class TheLoaiController : Controller
    {
        WebsiteModel db;
        public TheLoaiController()
        {
            db = new WebsiteModel();
        }
        // GET: Admin/TheLoai
        public ActionResult Index(string timkiem, int PageNum = 1, int PageSize = 2)
        {
            TheLoaiDAO dao = new TheLoaiDAO();
            return View(dao.ListTheLoai(timkiem,  PageNum, PageSize));
        }
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.TheLoai.ToList().OrderBy(n => n.MaLoai), "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public ActionResult Create(TheLoai tl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TheLoaiDAO dao = new TheLoaiDAO();
                    dao.Add(tl);
                    return RedirectToAction("Index");
                }
                else
                    return View(tl);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            ViewBag.MaLoai = new SelectList(db.TheLoai.ToList().OrderBy(n => n.MaLoai), "MaLoai", "TenLoai");
            TheLoaiDAO dao = new TheLoaiDAO();
            TheLoai tl = new TheLoai();
            tl = dao.GetIdTheLoai(id);
            return View(tl);
        }
        [HttpPost]
        public ActionResult Edit(TheLoai tl)
        { 
            if (ModelState.IsValid)
            {
                TheLoaiDAO dao = new TheLoaiDAO();
                dao.Edit(tl);
                return RedirectToAction("Index");
            }
            else
                return View(tl);
            
        }
        public ActionResult Delete(int id)
        {
            TheLoaiDAO dao = new TheLoaiDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}