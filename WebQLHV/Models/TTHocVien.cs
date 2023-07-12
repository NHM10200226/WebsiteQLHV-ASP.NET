namespace WebQLHV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTHocVien")]
    public partial class TTHocVien
    {
        [StringLength(255)]
        public string ID { get; set; }

        [Required]
        [StringLength(255)]
        public string HOTEN { get; set; }

        [Required]
        [StringLength(255)]
        public string SDT { get; set; }

        [Required]
        [StringLength(255)]
        public string NGAYSINH { get; set; }

        [Required]
        [StringLength(255)]
        public string CMND { get; set; }

        [Required]
        [StringLength(255)]
        public string NOICAP { get; set; }

        [Required]
        [StringLength(255)]
        public string GIOITINH { get; set; }

        [Required]
        [StringLength(255)]
        public string HANGTHI { get; set; }

        [Required]
        [StringLength(255)]
        public string TRUNGTAM { get; set; }

        [Required]
        [StringLength(255)]
        public string DIACHI { get; set; }

        [Required]
        [StringLength(255)]
        public string NOIHOC { get; set; }

        [Required]
        [StringLength(255)]
        public string HOCPHI { get; set; }

        [Required]
        [StringLength(255)]
        public string HINHANH { get; set; }

        public DateTime CREATEDATE { get; set; }

        public DateTime UPDATEDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string GHICHU { get; set; }
    }
}
