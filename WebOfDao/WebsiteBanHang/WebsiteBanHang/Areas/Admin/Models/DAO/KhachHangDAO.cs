using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Models.DAO
{
    public class KhachHangDAO
    {
        WebsiteModel model;
        public KhachHangDAO()
        {
            model = new WebsiteModel();
        }
        public IEnumerable<KhachHang> ListKhachHang(string timkiem, string gioitinh, int PageNum, int PageSize)
        {
            IQueryable<KhachHang> kq = model.KhachHang;
            if (!string.IsNullOrEmpty(timkiem))
            {
                kq = kq.Where(x => x.HoTen.Contains(timkiem));
            }
            if (!string.IsNullOrEmpty(gioitinh) && gioitinh != "0" )
            {
                kq = kq.Where(x => x.GioiTinh == gioitinh);
            }
            return kq.OrderBy(a => a.MaKH).ToPagedList(PageNum, PageSize);
        }

        public void Add(KhachHang kh)
        {
            model.KhachHang.Add(kh);
            model.SaveChanges();
        }
        public void Edit(KhachHang kh)
        {
            KhachHang khachhang = GetIdKhachHang(kh.MaKH);
            if(khachhang != null)
            {
                khachhang.HoTen = kh.HoTen;
                khachhang.TaiKhoan = kh.TaiKhoan;
                khachhang.MatKhau = kh.MatKhau;
                khachhang.Email = kh.Email;
                khachhang.DiaChi = kh.DiaChi;
                khachhang.DienThoai = kh.DienThoai;
                khachhang.GioiTinh = kh.GioiTinh;
                khachhang.NgaySinh = kh.NgaySinh;
                model.SaveChanges();
            }
        }
        public  void Delete(int id)
        {
            KhachHang khachhang = model.KhachHang.Find(id);
            if(khachhang != null)
            {
                model.KhachHang.Remove(khachhang);
                model.SaveChanges();
            }
        }
        public KhachHang GetIdKhachHang(int id)
        {
            return model.KhachHang.Find(id);
        }
    }
}