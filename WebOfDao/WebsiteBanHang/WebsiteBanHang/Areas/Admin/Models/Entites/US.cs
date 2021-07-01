namespace WebsiteBanHang.Areas.Admin.Models.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class US
    {
        [Key]
        [StringLength(100)]
        [Display(Name ="Tên Tài Khoản")]
        [Required(ErrorMessage ="Nhập {0}")]
        public string username { get; set; }

        [StringLength(100)]
        [Display(Name ="Mật Khẩu")]
        [Required(ErrorMessage ="Nhập {0}")]
        public string password { get; set; }

        [StringLength(100)]
        [Display(Name ="Họ Và Tên")]
        [Required(ErrorMessage ="Nhập {0}")]
        public string fullname { get; set; }
    }
}
