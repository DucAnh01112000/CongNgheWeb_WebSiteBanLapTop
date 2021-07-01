using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using PagedList;


namespace WebsiteBanHang.Areas.Admin.Models.DAO
{
    public class DonHangDAO
    {
        WebsiteModel model;
        public DonHangDAO()
        {
            model = new WebsiteModel();
        }
        public IEnumerable<DonHang> ListDonHang( int PageNum, int PageSize)
        {
            IQueryable<DonHang> kq = model.DonHang;
           
            return kq.OrderBy(a => a.MaDonHang).ToPagedList(PageNum, PageSize);
        }
        public void Add(DonHang dh)
        {
            model.DonHang.Add(dh);
            model.SaveChanges();
        }
        public void Edit(DonHang dh)
        {
            DonHang donhang = GetIdDonHang(dh.MaDonHang);
            if(donhang != null)
            {
                donhang.MaDonHang = dh.MaDonHang;
                donhang.TinhTrangGiaoHang = dh.TinhTrangGiaoHang;
                donhang.DaThanhToan = dh.DaThanhToan;
                donhang.NgayDat = dh.NgayDat;
                donhang.NgayGiao = dh.NgayGiao;
                donhang.MaKH = dh.MaKH;
                model.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            DonHang donhang = model.DonHang.Find(id);
            if(donhang != null)
            {
                model.DonHang.Remove(donhang);
                model.SaveChanges();
            }
        }
        public DonHang GetIdDonHang(int id)
        {
            return model.DonHang.Find(id);
        }
    }
}