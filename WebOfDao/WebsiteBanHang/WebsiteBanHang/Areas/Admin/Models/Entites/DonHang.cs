namespace WebsiteBanHang.Areas.Admin.Models.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name ="Mã Đơn Hàng")]
        //[Required(ErrorMessage ="Nhập {0}")]
        public int MaDonHang { get; set; }

        [Display(Name ="Thanh Toán")]
        //[Range(0,1, ErrorMessage ="{0} chỉ được nhập {1} hoặc {2}")]
        
        public int? DaThanhToan { get; set; }

        [Display(Name = "Tình Trạng Giao Hàng")]
        //[Range(0, 1, ErrorMessage = "{0} chỉ được nhập {1} hoặc {2}")]
       
        public int? TinhTrangGiaoHang { get; set; }

        [Display(Name ="Ngày Đặt")]
        //[Required(ErrorMessage ="Nhập {0}")]
        public DateTime? NgayDat { get; set; }

        [Display(Name = "Ngày Giao")]
        public DateTime? NgayGiao { get; set; }

        [Display(Name = "Tên Khách Hàng")]
        //[Required(ErrorMessage ="Chọn {0}")]
        public int? MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
