namespace WebQLHV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTin")]
    public partial class ThongTin
    {
        [StringLength(255)]
        public string ID { get; set; }

        [Required]
        [StringLength(255)]
        public string HANG { get; set; }

        [Required]
        [StringLength(255)]
        public string TRUNGTAM { get; set; }

        [Required]
        [StringLength(255)]
        public string PRICE { get; set; }

        public DateTime CREATEDATE { get; set; }

        public DateTime UPDATEDATE { get; set; }
    }
}
