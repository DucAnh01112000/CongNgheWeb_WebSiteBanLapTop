using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models.DAO;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using System.IO;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        WebsiteModel db;
        public KhachHangController()
        {
            db = new WebsiteModel();
        }
        public ActionResult Index(string timkiem, string gioitinh, int PageNum = 1, int PageSize = 2)
        {
            KhachHangDAO dao = new KhachHangDAO();
            return View(dao.ListKhachHang(timkiem, gioitinh, PageNum, PageSize));
        }
        public ActionResult Create()
        {
            //ViewBag.GioiTinh = new SelectList(db.KhachHang.ToList().OrderBy(n => n.MaKH), "GioiTinh", "GioiTinh");
            return View();
        }
        [HttpPost]
        public ActionResult Create(KhachHang kh)
        {
            try
            {
                if (ModelState.IsValid)
                {   
                    KhachHangDAO dao = new KhachHangDAO();
                    dao.Add(kh);
                    return RedirectToAction("Index");
                }
                else return View(kh);
            }
            catch
            {
                return View();
            }
 
        }
        public ActionResult Edit(int id)
        {
            KhachHangDAO dao = new KhachHangDAO();
            KhachHang kh = new KhachHang();
            kh = dao.GetIdKhachHang(id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    KhachHangDAO dao = new KhachHangDAO();
                    dao.Edit(kh);
                    return RedirectToAction("Index");
                }
                else
                    return View(kh);
            }
            catch
            {
                return View();
            }
               
        }

        public ActionResult Delete(int id)
        {
            KhachHangDAO dao = new KhachHangDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}