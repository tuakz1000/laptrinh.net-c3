using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai6
{

    using System;

    abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }

        public NhanVien(string maNV, string hoTen)
        {
            MaNV = maNV;
            HoTen = hoTen;
        }

        public abstract double TinhLuong();

        public virtual void HienThi()
        {
            Console.WriteLine($"Mã NV: {MaNV}");
            Console.WriteLine($"Họ tên: {HoTen}");
            Console.WriteLine($"Lương: {TinhLuong():N0} VNĐ");
        }
    }

    class NhanVienVanPhong : NhanVien
    {
        public double LuongCoBan { get; set; }
        public int SoNgayCong { get; set; }

        public NhanVienVanPhong(
            string maNV, string hoTen,
            double luongCoBan, int soNgayCong)
            : base(maNV, hoTen)
        {
            LuongCoBan = luongCoBan;
            SoNgayCong = soNgayCong;
        }

        public override double TinhLuong()
        {
            return LuongCoBan * SoNgayCong / 26;
        }
    }

    class NhanVienKinhDoanh : NhanVien
    {
        public double LuongCoBan { get; set; }
        public double DoanhSo { get; set; }
        public double TyLeHoaHong { get; set; }

        public NhanVienKinhDoanh(
            string maNV, string hoTen,
            double luongCoBan, double doanhSo,
            double tyLeHoaHong)
            : base(maNV, hoTen)
        {
            LuongCoBan = luongCoBan;
            DoanhSo = doanhSo;
            TyLeHoaHong = tyLeHoaHong;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + DoanhSo * TyLeHoaHong / 100;
        }
    }

    class GiangVien : NhanVien
    {
        public double LuongMotTiet { get; set; }
        public int SoTietDay { get; set; }

        public GiangVien(
            string maNV, string hoTen,
            double luongMotTiet, int soTietDay)
            : base(maNV, hoTen)
        {
            LuongMotTiet = luongMotTiet;
            SoTietDay = soTietDay;
        }

        public override double TinhLuong()
        {
            return LuongMotTiet * SoTietDay;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            NhanVien[] danhSach =
            {
            new NhanVienVanPhong("NV01", "Nguyễn An", 10000000, 26),
            new NhanVienKinhDoanh("NV02", "Trần Bình", 8000000, 50000000, 5),
            new GiangVien("GV01", "Lê Minh", 250000, 80)
        };

            foreach (NhanVien nv in danhSach)
            {
                nv.HienThi();
                Console.WriteLine("------------------------------");
            }
        }
    }

}
