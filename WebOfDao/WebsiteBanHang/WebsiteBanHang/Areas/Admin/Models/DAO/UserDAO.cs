using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Models.DAO
{
    public class UserDAO
    {
        WebsiteModel model;
        public UserDAO()
        {
            model = new WebsiteModel();
        }

        public bool checkLogin(string username, string password)
        {
            bool check = false;
            int a = model.US.Where(y => y.username == username && y.password == password).ToList().Count();
            if (a >= 1)
                check = true;
            return check;
        }
        public IEnumerable<US> ListUS(string timkiem, int PageNum, int PageSize)
        {
            IQueryable<US> kq = model.US;
            if (!string.IsNullOrEmpty(timkiem))
            {
                kq = kq.Where(x => x.username.Contains(timkiem));
            }
          
            return kq.OrderBy(a => a.username).ToPagedList(PageNum, PageSize);
        }
        public void Add(US us)
        {
            model.US.Add(us);
            model.SaveChanges();
        }
        public void Edit(US u)
        {
            US user = GetIdUS(u.username);
            if(user != null)
            {
                user.username = u.username;
                user.password = u.password;
                user.fullname = u.fullname;
                model.SaveChanges();
            }
        }
        public void Delete (string id)
        {
            US user = model.US.Find(id);
            if(user != null)
            {
                model.US.Remove(user);
                model.SaveChanges();
            }
        }
      
        public US GetIdUS(string id)
        {
            return model.US.Find(id);
        }
    }
}