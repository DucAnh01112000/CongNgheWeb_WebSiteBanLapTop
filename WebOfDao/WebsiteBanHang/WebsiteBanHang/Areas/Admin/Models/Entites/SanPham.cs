namespace WebsiteBanHang.Areas.Admin.Models.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name ="Mã Sản Phẩm")]
        public int MaLap { get; set; }

        [StringLength(100)]
        [Display(Name ="Tên Sản Phẩm")]
        //[Required(ErrorMessage = "Nhập {0}")]
        public string TenLap { get; set; }

        [Display(Name ="Giá Bán")]
        //[Range(0, Int32.MaxValue, ErrorMessage = "{0} phải là số")]
        public decimal? GiaBan { get; set; }

        [Display(Name = "Mô Tả")]
        //[Required(ErrorMessage = "Nhập {0}")]
        public string MoTa { get; set; } 

        [StringLength(50)]
        [Display(Name = "Ảnh Bìa")]
        public string AnhBia { get; set; }

        [Display(Name = "Ngày Cập Nhập")]
        public DateTime? NgayCapNhat { get; set; }

        [Display(Name = "Số Lượng Tồn")]
        public int? SoLuongTon { get; set; }

        
        [Display(Name = "Hãng Sản Xuất")]
        //[Required(ErrorMessage = "Chọn {0}")]
        public int? MaHangSX { get; set; }

        [Display(Name = "Loại Máy")]
        //[Required(ErrorMessage = "Chọn {0}")]
        public int? MaLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual HangSX HangSX { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
