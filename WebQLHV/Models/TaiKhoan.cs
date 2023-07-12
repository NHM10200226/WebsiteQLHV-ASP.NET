namespace WebQLHV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [StringLength(255)]
        public string ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NAME { get; set; }

        [Required]
        [StringLength(255)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(255)]
        public string PASSWORD { get; set; }

        public DateTime CREATEDATE { get; set; }

        public DateTime UPDATEDATE { get; set; }
    }
}
