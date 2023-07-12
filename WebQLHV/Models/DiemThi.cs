namespace WebQLHV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiemThi")]
    public partial class DiemThi
    {
        [StringLength(255)]
        public string ID { get; set; }

        [Required]
        [StringLength(255)]
        public string KHOAHOC { get; set; }

        [Required]
        [StringLength(255)]
        public string HOCVIEN { get; set; }

        [Required]
        [StringLength(255)]
        public string LYTHUYET { get; set; }

        [Required]
        [StringLength(255)]
        public string THUCHANH { get; set; }

        public DateTime CREATEDATE { get; set; }

        public DateTime UPDATEDATE { get; set; }
    }
}
