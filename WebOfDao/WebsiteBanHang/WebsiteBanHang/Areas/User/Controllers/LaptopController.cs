using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.User.Models;
using PagedList;

namespace WebsiteBanHang.Areas.User.Controllers
{
    public class LaptopController : Controller
    {
        // GET: User/Laptop
        LaptopModel db = new LaptopModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PatialSanPhamMoi()
        {
            var lstLaptopMoi = db.SanPham.Take(6).ToList();
            return View(lstLaptopMoi);
        }
/*        public ActionResult PatialFullSanPham(int PageNum = 1, int PageSize = 12)
        {
            var lstLaptop = db.SanPham.OrderBy(n => n.MaLap);
            return View(lstLaptop.ToPagedList(PageNum, PageSize));
        }*/
        public ActionResult PatialFullSanPham(string ftimkiem = "")
        {
            List<SanPham> lstLaptop;
          //  lstLaptop = db.SanPham.Take(12).ToList();
            if (ftimkiem == "" || ftimkiem == null)
            {
                lstLaptop = db.SanPham.Take(12).ToList();
        
            }
            else
            {
                lstLaptop = db.SanPham.Where(x => x.TenLap.Contains(ftimkiem)).Take(12).ToList();      
            }
            
            return View(lstLaptop);
        }
        public ActionResult XemChiTiet(int malap = 0)
        {
            SanPham Chitiet = db.SanPham.SingleOrDefault(n => n.MaLap == malap);
            if(Chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Chitiet);
        }

    }
}
