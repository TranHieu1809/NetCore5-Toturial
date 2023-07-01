using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApiApplication.Data
{
    public enum TinhTrangDonDatHang
    {
        New = 0,
        Payment = 1,
        Complate = 2,
        Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDonHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }
        public string NguoiNhanHang { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
