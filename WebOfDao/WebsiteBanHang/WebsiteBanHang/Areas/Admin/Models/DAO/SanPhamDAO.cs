using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using PagedList; 

namespace WebsiteBanHang.Areas.Admin.Models.DAO
{
    public class SanPhamDAO
    {
        WebsiteModel model;

        public SanPhamDAO()
        {
            model = new WebsiteModel();
        }
        public IEnumerable<SanPham> ListSanPham(string timkiem,string HangSX,string PhanLoai,string KhoangGia,int PageNum, int Pagesize)
        {
            IQueryable<SanPham> kq = model.SanPham;
            if (!string.IsNullOrEmpty(timkiem))
            {
                kq = kq.Where(x => x.TenLap.Contains(timkiem));
            }
            if (!string.IsNullOrEmpty(HangSX) && HangSX != "1")
            {
                kq = kq.Where( x => x.HangSX.TenHangSX == HangSX);
            }
            if (!string.IsNullOrEmpty(PhanLoai) && PhanLoai != "1")
            {
                kq = kq.Where(x => x.TheLoai.TenLoai == PhanLoai);
            }
            if(!string.IsNullOrEmpty(KhoangGia) && KhoangGia != "0")
            {
                switch (KhoangGia) 
                {
                    case "1":
                        kq = kq.Where(x => x.GiaBan >= 10000 && x.GiaBan <= 20000 ) ;
                        break;
                    case "2":
                        kq = kq.Where(x => x.GiaBan >= 20000 && x.GiaBan <= 30000);
                        break;
                    case "3":
                        kq = kq.Where(x => x.GiaBan >= 30000 && x.GiaBan <= 40000);
                        break;
                    case "4":
                        kq = kq.Where(x => x.GiaBan >= 40000 && x.GiaBan <= 50000);
                        break;
                    default:
                        break;
                }                  
            }    

            return kq.OrderBy(a => a.MaLap).ToPagedList(PageNum, Pagesize);
        }

        public void Add(SanPham pro)
        {
            model.SanPham.Add(pro);
            model.SaveChanges();
        }

        public void Edit(SanPham pro)
        {
            SanPham sanpham = GetIdSanPham(pro.MaLap);
            if(sanpham != null)
            {
                sanpham.MaLap = pro.MaLap;
                sanpham.MaLoai = pro.MaLoai;
                sanpham.MaHangSX = pro.MaHangSX;
                sanpham.GiaBan = pro.GiaBan;
                sanpham.HangSX = pro.HangSX;
                sanpham.MoTa = pro.MoTa;
                sanpham.NgayCapNhat = pro.NgayCapNhat;
                sanpham.SoLuongTon = pro.SoLuongTon;
                sanpham.TenLap = pro.TenLap;
                sanpham.TheLoai = pro.TheLoai;
                sanpham.AnhBia = pro.AnhBia;
                model.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            SanPham sanpham = model.SanPham.Find(id);
            if(sanpham != null)
            {
                model.SanPham.Remove(sanpham);
                model.SaveChanges();
            }
        }

        public SanPham GetIdSanPham(int id)
        {
            return model.SanPham.Find(id);
        }

    }
}