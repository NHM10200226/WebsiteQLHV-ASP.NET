using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebQLHV.Models
{
    public partial class DemoThucTapEntities : DbContext
    {
        public DemoThucTapEntities()
            : base("name=DemoThucTapEntities")
        {
        }

        public virtual DbSet<DiemThi> DiemThi { get; set; }
        public virtual DbSet<HangGPLX> HangGPLX { get; set; }
        public virtual DbSet<HoSo> HoSo { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHoc { get; set; }
        public virtual DbSet<LoaiHoSo> LoaiHoSo { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TTHocVien> TTHocVien { get; set; }
        public virtual DbSet<ThongTin> ThongTin { get; set; }
        public virtual DbSet<TrungTam> TrungTam { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiHoSo>()
                .Property(e => e.TRUNGTAM)
                .IsUnicode(false);
        }
    }
}
