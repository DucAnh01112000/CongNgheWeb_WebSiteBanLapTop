using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.User.Models;
using PagedList;
using PagedList.Mvc;
namespace WebsiteBanHang.Areas.User.Controllers
{
    public class LoaiLaptopController : Controller
    {
        // GET: User/LoaiLaptop
        LaptopModel db = new LaptopModel();
        public ActionResult PatialLoaiLaptop()
        {

            return View(db.TheLoai.ToList());
        }
        /*        public ActionResult XemLoaiLap(int Maloai = 0)
                {
                    List<SanPham> lstLap = db.SanPham.Where(x => x.MaLoai == Maloai).Take(12).OrderBy(x => x.GiaBan).ToList();

                    return View(lstLap);

                }*/
        public ActionResult XemLoaiLap(int Maloai = 0, int PageNum = 1, int PageSize = 5)
        {
            IQueryable<SanPham>  lstLap = db.SanPham.Where(x => x.MaLoai == Maloai).OrderBy(n => n.MaLap);
            ViewBag.Ml = Maloai;
            return View(lstLap.ToPagedList(PageNum,PageSize));

        }

    }
}