namespace WebsiteBanHang.Areas.Admin.Models.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        [Display(Name ="Mã KH")]
        public int MaKH { get; set; }

        [Display(Name ="Họ Tên")]
        [StringLength(100)]
        [Required(ErrorMessage ="Nhập {0}")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [Display(Name ="Tài Khoản")]
        [Required(ErrorMessage ="Nhập {0}")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Display(Name ="Mật Khẩu")]
        [Required(ErrorMessage ="Nhập {0}")]
        public string MatKhau { get; set; }

        [StringLength(100)]
        //[RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A_Za-z0-9]+(\\.[A_Za-z0-9]+)*(\\.[A_Za-z]{2,})$", ErrorMessage ="Không hợp lệ") ]
        public string Email { get; set; }

        [StringLength(100)]
        [Display(Name ="Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(10, ErrorMessage ="{0} phải là 10 số")]
        [Display(Name ="Số Điện Thoại")]
        [Required(ErrorMessage ="Nhập {0}")]
        [Range(0,double.MaxValue, ErrorMessage ="{0} phải là số")]
        public string DienThoai { get; set; }

        [StringLength(3)]
        [Display(Name ="Giới Tính")]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="Ngày Sinh")]
        public DateTime? NgaySinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
