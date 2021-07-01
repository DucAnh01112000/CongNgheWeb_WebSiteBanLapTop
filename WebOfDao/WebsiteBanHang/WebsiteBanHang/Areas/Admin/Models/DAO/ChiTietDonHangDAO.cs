using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Models.DAO
{
    public class ChiTietDonHangDAO
    {
        WebsiteModel model;
        public ChiTietDonHangDAO()
        {
            model = new WebsiteModel();
        }
        public IEnumerable<ChiTietDonHang> ListChiTietDonHang(string timkiem, int PageNum, int PageSize)
        {
            IQueryable<ChiTietDonHang> kq = model.ChiTietDonHang;
            if (!string.IsNullOrEmpty(timkiem))
            {
                kq = kq.Where(x => x.DonGia.Contains(timkiem));
            }
            return kq.OrderBy(a => a.MaLap).ToPagedList(PageNum, PageSize);
        }
        public void Add(ChiTietDonHang chitiet)
        {
            model.ChiTietDonHang.Add(chitiet);
            model.SaveChanges();
        }
        public void Edit(ChiTietDonHang chitiet)
        {
            ChiTietDonHang chitietdonhang = GetIdChiTietDonHang(chitiet.MaDonHang, chitiet.MaLap);
            if(chitietdonhang != null)
            {
                chitietdonhang.MaDonHang = chitiet.MaDonHang;
                chitietdonhang.MaLap = chitiet.MaLap;
                chitietdonhang.SoLuong = chitiet.SoLuong;
                chitietdonhang.DonGia = chitiet.DonGia;
                model.SaveChanges();
            }
        }
        public void Delete(int id, int id1)
        {

            ChiTietDonHang chitiet = model.ChiTietDonHang.Find(id, id1);
            if(chitiet != null)
            {
                model.ChiTietDonHang.Remove(chitiet);
                model.SaveChanges();

            }
        }
        public ChiTietDonHang GetIdChiTietDonHang(int id, int id1)
        {
            return model.ChiTietDonHang.Find(id, id1);
        }
     }
}