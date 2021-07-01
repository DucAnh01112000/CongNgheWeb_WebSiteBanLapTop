using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Areas.Admin.Models.Entites;
using WebsiteBanHang.Areas.Admin.Models.DAO;
using System.IO;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller

    {
        // GET: Admin/Product
        WebsiteModel db;
        public ProductController()
        {
            db = new WebsiteModel();
        }
        public ActionResult Index(string timkiem,string HangSX,string PhanLoai,string KhoangGia,int PageNum = 1, int PageSize = 5)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return View(dao.ListSanPham(timkiem,HangSX,PhanLoai,KhoangGia,PageNum,PageSize));
        }

        public ActionResult Create()
        { 
            //dua du lieu vao dropdownlist
            ViewBag.MaHangSX = new SelectList(db.HangSX.ToList().OrderBy(n=>n.MaHangSX),"MaHangSX", "TenHangSX");
            ViewBag.MaLoai = new SelectList(db.TheLoai.ToList().OrderBy(n=>n.MaLoai),"MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham pro, HttpPostedFileBase fileUpLoad)
        {
            
                //luu ten file
                if (fileUpLoad != null)
                {
                    var fileName = Path.GetFileName(fileUpLoad.FileName);
                    //luu duong dan cua file 
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"), fileName);
                    // kiem tra hinh anh da ton tai chua 

                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hinh anh da ton tai";
                    }
                    else
                    {
                        fileUpLoad.SaveAs(path);
                    }

                    pro.AnhBia = fileUpLoad.FileName;
                    SanPhamDAO dao = new SanPhamDAO();
                    dao.Add(pro);
                    return RedirectToAction("Index");
                }
                else
                {
                    SanPhamDAO dao = new SanPhamDAO();
                    dao.Add(pro);
                    return RedirectToAction("Index");
                }
            
        }


        public ActionResult Edit(int id)
        {
            //dua du lieu vao dropdownlist
            ViewBag.MaHangSX = new SelectList(db.HangSX.ToList().OrderBy(n => n.MaHangSX), "MaHangSX", "TenHangSX");
            ViewBag.MaLoai = new SelectList(db.TheLoai.ToList().OrderBy(n => n.MaLoai), "MaLoai", "TenLoai");
            SanPhamDAO dao = new SanPhamDAO();
            SanPham pro = new SanPham();
            pro = dao.GetIdSanPham(id);
            ViewBag.image = pro.AnhBia;
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(SanPham pro, HttpPostedFileBase fileUpLoad)
        {
            
                //luu ten file
                if (fileUpLoad != null)
                {
                    var fileName = Path.GetFileName(fileUpLoad.FileName);
                    //luu duong dan cua file 
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"), fileName);
                    // kiem tra hinh anh da ton tai chua
                    fileUpLoad.SaveAs(path);

                    pro.AnhBia = fileUpLoad.FileName;
                    ViewBag.image = pro.AnhBia;
                    SanPhamDAO dao = new SanPhamDAO();
                    dao.Edit(pro);
                    return RedirectToAction("Index");
                }
                else
                {
                    SanPhamDAO dao = new SanPhamDAO();
                    dao.Edit(pro);
                    return RedirectToAction("Index");
                }
         
        }

        public ActionResult Delete(int id)
        {
            SanPhamDAO dao = new SanPhamDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}