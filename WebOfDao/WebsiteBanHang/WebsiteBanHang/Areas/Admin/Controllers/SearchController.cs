using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using WebsiteBanHang.Areas.Admin.Models.DAO;
using PagedList.Mvc;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class SearchController : Controller
    {
        // GET: Admin/Search
        WebsiteModel db = new WebsiteModel();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f,int? page)
        {
            string sKey = f["timkiem"].ToString();
            List<SanPham> lst = db.SanPham.Where(n => n.TenLap.Contains(sKey)).ToList();

            // Phan trang 
            int pageNum = (page ?? 1);
            int pageSize = 5;

            if (lst.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SanPham.OrderBy(n => n.MaLap).ToPagedList(pageNum,pageSize));
            }
            else
            {
                return View(lst.OrderBy(n => n.MaLap).ToPagedList(pageNum, pageSize));
            }

        }
    }
}