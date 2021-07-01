using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.User.Models;

namespace WebsiteBanHang.Areas.User.Controllers
{
    public class NguoiDungController : Controller
    {
        LaptopModel db = new LaptopModel();
        // GET: User/NguoiDung 
        [HttpGet]
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangKi(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHang.Add(kh);
                db.SaveChanges();
             }
                return View();
            /*      db.KhachHang.Add(kh);
                  db.SaveChanges();
                  return View();*/
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string username = f["username"].ToString();
            string password = f.Get("password").ToString();

            KhachHang kh = db.KhachHang.SingleOrDefault(n => n.TaiKhoan == username && n.MatKhau == password);

            if(kh != null)
            {             
                Session["taikhoan"] = kh;
                KhachHang a = (KhachHang)Session["taikhoan"];
                Session["tb"] = a.TaiKhoan;
                return RedirectToAction("Index","Home");
            }
            ViewBag.thongbao = "Tài khoản hoặc mật khẩu không đúng!";
            return View();
        }
    }
}