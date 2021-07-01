using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using WebsiteBanHang.Areas.Admin.Models.DAO;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ChiTietDonHangController : Controller
    {
        // GET: Admin/ChiTietDonHang
        WebsiteModel db;
        public ChiTietDonHangController()
        {
            db = new WebsiteModel();
        }
        public ActionResult Index(string timkiem, int PageNum = 1, int PageSize = 2)
        {
            ChiTietDonHangDAO dao = new ChiTietDonHangDAO();
            return View(dao.ListChiTietDonHang(timkiem, PageNum, PageSize));
        }
        public ActionResult Create()
        {
            ViewBag.MaDonHang = new SelectList(db.DonHang.ToList().OrderBy(n => n.MaDonHang), "MaDonHang","MaDonHang");
            ViewBag.MaLap = new SelectList(db.SanPham.ToList().OrderBy(n => n.MaLap), "MaLap", "TenLap");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ChiTietDonHang chitiet)
        {
            ChiTietDonHangDAO dao = new ChiTietDonHangDAO();
            dao.Add(chitiet);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id, int id1)
        {
            ViewBag.MaDonHang = new SelectList(db.DonHang.ToList().OrderBy(n => n.MaDonHang), "MaDonHang", "MaDonHang");
            ViewBag.MaLap = new SelectList(db.SanPham.ToList().OrderBy(n => n.MaLap), "MaLap", "TenLap");
            ChiTietDonHangDAO dao = new ChiTietDonHangDAO();
            ChiTietDonHang chitiet = new ChiTietDonHang();
            chitiet = dao.GetIdChiTietDonHang(id, id1);
            return View(chitiet);
        }
        [HttpPost]
        public ActionResult Edit(ChiTietDonHang chitiet)
        {
            ChiTietDonHangDAO dao = new ChiTietDonHangDAO();
            dao.Edit(chitiet);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id, int id1)
        {
            ChiTietDonHangDAO dao = new ChiTietDonHangDAO();
            dao.Delete(id, id1);
            return RedirectToAction("Index");
        }
    }
}