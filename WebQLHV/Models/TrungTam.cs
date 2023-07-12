namespace WebQLHV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrungTam")]
    public partial class TrungTam
    {
        [StringLength(255)]
        public string ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NAME { get; set; }

        [Required]
        [StringLength(255)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(255)]
        public string HOTLINE { get; set; }

        [Required]
        [StringLength(255)]
        public string ADDRESS { get; set; }

        public DateTime CREATEDATE { get; set; }

        public DateTime UPDATEDATE { get; set; }
    }
}
