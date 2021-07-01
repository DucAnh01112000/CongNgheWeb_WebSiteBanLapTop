using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using WebsiteBanHang.Areas.Admin.Models.DAO;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        WebsiteModel db;
        public DonHangController()
        {
            db = new WebsiteModel();
        }
        public ActionResult Index( int PageNum =1, int PageSize = 2)
        {
            DonHangDAO dao = new DonHangDAO();
            return View(dao.ListDonHang( PageNum, PageSize));
        }
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHang.ToList().OrderBy(n => n.MaKH), "MaKH", "HoTen");
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(DonHang dh)
        {
            
                DonHangDAO dao = new DonHangDAO();
                dao.Add(dh);
                return RedirectToAction("Index");
           
        }
        public ActionResult Edit(int id)
        {
            ViewBag.MaKH = new SelectList(db.KhachHang.ToList().OrderBy(n => n.MaKH), "MaKH", "HoTen");
            DonHangDAO dao = new DonHangDAO();
            DonHang dh = new DonHang();
            dh = dao.GetIdDonHang(id);
            return View(dh);
        }
        [HttpPost]
        public ActionResult Edit(DonHang dh)
        {
           
                //ViewBag.MaKH = new SelectList(db.KhachHang.ToList().OrderBy(n => n.MaKH), "MaKH", "HoTen");
                DonHangDAO dao = new DonHangDAO();
                dao.Edit(dh);
                return RedirectToAction("Index");
         
        }
        public ActionResult Delete(int id)
        {
            DonHangDAO dao = new DonHangDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}