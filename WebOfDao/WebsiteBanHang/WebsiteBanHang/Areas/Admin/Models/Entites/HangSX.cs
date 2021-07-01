namespace WebsiteBanHang.Areas.Admin.Models.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangSX")]
    public partial class HangSX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangSX()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [Display(Name ="Mã Hãng")]
        public int MaHangSX { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên Hãng")]
        [Required(ErrorMessage ="Nhập {0}")]
       
        public string TenHangSX { get; set; }

        [StringLength(100)]
        [Display(Name ="Địa Chỉ")]
        [Required(ErrorMessage ="Nhập {0}")]
        public string DiaChi { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [StringLength(10, ErrorMessage ="{0} chỉ có 10 số")]
        [Required(ErrorMessage ="Nhập {0}")]
        [Range(0, double.MaxValue, ErrorMessage ="{0} phải là số")]
        public string DienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
