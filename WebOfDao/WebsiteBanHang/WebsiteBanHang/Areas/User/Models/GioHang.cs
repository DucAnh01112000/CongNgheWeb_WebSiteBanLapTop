using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Areas.User.Models
{
    public class GioHang
    {
        LaptopModel db = new LaptopModel();
        public int Masp { get; set; }
        public string Tensp { get; set; }
        public string Hinhanh { get; set; }
        public double Dongia { get; set; }
        public int Soluong { get; set; }
        public double ThanhTien
        {
            get { return Dongia * Soluong; }
        }
        //Hàm tạo giỏ hàng
        public GioHang(int masp)
        {
            SanPham sp = db.SanPham.Single(n => n.MaLap == masp);
            Masp = masp;
            Tensp = sp.TenLap;
            Hinhanh = sp.AnhBia;
            Dongia = double.Parse(sp.GiaBan.ToString());
            Soluong = 1;
        }
    }
}