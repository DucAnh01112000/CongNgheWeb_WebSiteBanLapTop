using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Models.DAO
{
    public class TheLoaiDAO
    {
        WebsiteModel model;
        public TheLoaiDAO()
        {
            model = new WebsiteModel();
        }
        public IEnumerable<TheLoai> ListTheLoai (string timkiem,  int PageNum, int PageSize)
        {
            IQueryable<TheLoai> kq = model.TheLoai;
            if (!string.IsNullOrEmpty(timkiem))
            {
            
                kq = kq.Where(x => x.TenLoai.Contains(timkiem));
            }
           
            return kq.OrderBy(a => a.MaLoai).ToPagedList(PageNum, PageSize);
        }
        public void Add(TheLoai tl)
        {
            model.TheLoai.Add(tl);
            model.SaveChanges();
        }
        public void Edit(TheLoai tl)
        {
            TheLoai theloai = GetIdTheLoai(tl.MaLoai);
            if (theloai != null)
            {
                theloai.MaLoai = tl.MaLoai;
                theloai.TenLoai = tl.TenLoai;
                model.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            TheLoai tl = model.TheLoai.Find(id);
            if (tl != null)
            {
                model.TheLoai.Remove(tl);
                model.SaveChanges();
            }
        }
        public TheLoai GetIdTheLoai(int id)
        {
            return model.TheLoai.Find(id);
        }
    }
}