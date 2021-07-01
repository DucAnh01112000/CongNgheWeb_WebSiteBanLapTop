using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Models.DAO
{
    public class HangSXDAO
    {
        WebsiteModel model;
        public HangSXDAO()
        {
            model = new WebsiteModel();
        }
        public IEnumerable<HangSX> ListHangSX(string timkiem, int PageNum, int PageSize)
        {
            IQueryable<HangSX> kq = model.HangSX;
            if (!string.IsNullOrEmpty(timkiem))
            {
               
                  kq = kq.Where(x => x.TenHangSX.Contains(timkiem));
            }
           
            return kq.OrderBy(a => a.MaHangSX).ToPagedList(PageNum, PageSize);
        }
        public void Add(HangSX h)
        {
            model.HangSX.Add(h);
            model.SaveChanges();
        }
        public void Edit(HangSX h)
        {
            HangSX hang = GetIdHangSX(h.MaHangSX);
            if(hang != null)
            {
                hang.MaHangSX = h.MaHangSX;
                hang.TenHangSX = h.TenHangSX;
                hang.DiaChi = h.DiaChi;
                hang.DienThoai = h.DienThoai;
                model.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            HangSX hang = model.HangSX.Find(id);
            if (hang != null)
            {
                model.HangSX.Remove(hang);
                model.SaveChanges();
            }
        }
        public HangSX GetIdHangSX(int id)
        {
            return model.HangSX.Find(id);
        }

    }
}