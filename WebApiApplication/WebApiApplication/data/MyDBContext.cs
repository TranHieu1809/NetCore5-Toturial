using Microsoft.EntityFrameworkCore;
using System;

namespace WebApiApplication.Data
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        #region DBSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e => {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDonHang);
                e.Property(dh => dh.NgayDatHang).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhanHang).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(e => new {e.MaDonHang, e.MaHangHoa});

                e.HasOne(e => e.DonHang)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDonHang)
                .HasConstraintName("FK_DonHangCT_DonHang");

                e.HasOne(e => e.HangHoa)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaHangHoa)
                .HasConstraintName("FK_DonHangCT_HangHoa");
            });
        }
    }
}
