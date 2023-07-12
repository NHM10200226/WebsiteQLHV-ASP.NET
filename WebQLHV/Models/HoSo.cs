namespace WebQLHV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoSo")]
    public partial class HoSo
    {
        [StringLength(255)]
        public string ID { get; set; }

        [Required]
        [StringLength(255)]
        public string LOAIHOSO { get; set; }

        [Required]
        [StringLength(255)]
        public string HOCVIEN { get; set; }

        [Column("HOSO")]
        [Required]
        [StringLength(255)]
        public string HOSO { get; set; }

        [Required]
        [StringLength(255)]
        public string GHICHU { get; set; }

        public DateTime CREATEDATE { get; set; }

        public DateTime UPDATEDATE { get; set; }
    }
}
