using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.User.Models;

namespace WebsiteBanHang.Areas.User.Controllers
{
    public class GioHangController : Controller
    {
        // GET: User/GioHang
        LaptopModel db = new LaptopModel();

        public ActionResult Index()
        {
            return View();
        }

        // lay gio hang
        public List<GioHang> Taogiohang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang == null)
            {
                //neu gio hang chua ton tai thi minh khoi tao
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Them gio hang
        public ActionResult ThemSanPham(int masp,string strUrl)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaLap == masp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lay ra session gio hang
            List<GioHang> lstGioHang = Taogiohang();
            // kiểm tra sp đã tồn tai trong session chưa
            GioHang sanpham = lstGioHang.Find(n => n.Masp == masp);
            if(sanpham == null)
            {
                sanpham = new GioHang(masp);
                //add sản phẩm mới vào thêm vào list
                lstGioHang.Add(sanpham);
                return Redirect(strUrl);
            }
            else
            {
                sanpham.Soluong++;
                return Redirect(strUrl);
            }

        }
        //cap nhat gio hang

        public ActionResult CapNhatSanPham(int masp, FormCollection f)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaLap == masp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstgiohang = Taogiohang();
            GioHang sanpham = lstgiohang.SingleOrDefault(n => n.Masp == masp);
            if(sanpham != null)
            {
                sanpham.Soluong = int.Parse(f["txtSoluong"].ToString());
            }
            return View("GioHang");
        }
        [HttpPost]
        public ActionResult Update(FormCollection f)
        {
            string[] quantites = f.GetValues("quantity");
            List<GioHang> sp = Session["GioHang"] as List<GioHang>;
            for(int i = 0; i < sp.Count; i++)
            {
                sp[i].Soluong = int.Parse(quantites[i].ToString());
            }
            Session["GioHang"] = sp;
          /*  ViewBag.sp = Session["GioHang"];*/
            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult Xoagiohang(int masp)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaLap == masp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstgiohang = Taogiohang();
            GioHang sanpham = lstgiohang.SingleOrDefault(n => n.Masp == masp);
            if (sanpham != null)
            {
                lstgiohang.RemoveAll(n => n.Masp == masp);
            }
            if(lstgiohang.Count == 0)
            {
                RedirectToAction("Index","Home");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult GioHang()
        {
            //    List<GioHang> lstGioHang = Taogiohang();
    /*        if (Session["GioHang"] == null) 
            {
                return RedirectToAction("Index", "Home");
            }*/
            List<GioHang> lstGioHang = Taogiohang();
       /*     ViewBag.sp = lstGioHang;*/
            return View(lstGioHang);
        }
        //tính tổng số lượng và tổng tiền
        //Tính tổng số lượng 
        private int Tongsoluong()
        {
            int sl = 0;
            List<GioHang> lstSanPham = Session["GioHang"] as List<GioHang>;
            if(lstSanPham != null)
            {
                sl = lstSanPham.Sum(n => n.Soluong);
            }
            return sl;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double tt = 0;
            List<GioHang> lstSanPham = Session["GioHang"] as List<GioHang>;
            if(lstSanPham != null)
            {
                tt = lstSanPham.Sum(n => n.ThanhTien);
            }
            return tt;
        }

        // tạo giỏ hàng partial

        public ActionResult GioHangPartial()
        {
            if(Tongsoluong() == 0)
            {
                return View();
            }
            ViewBag.TongSoLuong = Tongsoluong();
            ViewBag.TongTien = TongTien();
            return View();
        }

        [HttpPost]
        public ActionResult ThanhToan()
        {
            if(Session["taikhoan"] == null || Session["taikhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
             
            }
            if(Session["GioHang"] == null)
            {
               return RedirectToAction("Index", "Home");
            }
            //Thêm đơn hang
            DonHang dh = new DonHang();
            KhachHang kh = (KhachHang)Session["taikhoan"];
            List<GioHang> gh = Taogiohang();
            dh.MaKH = kh.MaKH;
            dh.NgayDat = DateTime.Now;
            db.DonHang.Add(dh);
            db.SaveChanges();
            //Them chi tiet don hang
            foreach(var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = dh.MaDonHang;
                ctDH.MaLap = item.Masp;
                ctDH.SoLuong = item.Soluong;
                ctDH.DonGia = item.Dongia.ToString();
                db.ChiTietDonHang.Add(ctDH);
                db.SaveChanges();

            }
            ViewBag.tt = "Thanh toán thành công!";
          return  RedirectToAction("GioHang","GioHang");
        }

    }
}