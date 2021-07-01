using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.User.Models;
using PagedList;

namespace WebsiteBanHang.Areas.User.Controllers
{
    public class HangSanXuatController : Controller
    {
        // GET: User/HangSanXuat
        LaptopModel db = new LaptopModel();
        public ActionResult PatialHangLaptop()
        {
            return View(db.HangSX.ToList());
        }

        public ActionResult XemHangSanXuat(int MaHang = 0, int PageNum = 1, int PageSize = 6)
        {
            List<SanPham> lstlap = db.SanPham.Where(x => x.MaHangSX == MaHang).OrderBy(n => n.GiaBan).ToList();
            ViewBag.Mh = MaHang;
            return View(lstlap.ToPagedList(PageNum, PageSize));
        }
    }
}