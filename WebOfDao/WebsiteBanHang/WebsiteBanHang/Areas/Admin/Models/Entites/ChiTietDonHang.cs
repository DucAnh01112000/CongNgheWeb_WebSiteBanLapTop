namespace WebsiteBanHang.Areas.Admin.Models.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Mã Sản Phẩm")]
        public int MaLap { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Mã Đơn Hàng")]
        public int MaDonHang { get; set; }

        [Display(Name ="Số Lượng")]
        public int? SoLuong { get; set; }

        [StringLength(10)]
        [Display(Name ="Đơn Giá")]
        public string DonGia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
