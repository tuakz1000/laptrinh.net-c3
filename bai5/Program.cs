using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai5
{
    internal class Program
    {
        public class Nguoi
        {
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }
            public Nguoi(string hoTen, DateTime ngaySinh)
            {
                HoTen = hoTen;
                NgaySinh = ngaySinh;
            }
            public virtual string MoTa()
            {
                return HoTen + " - " + NgaySinh.ToString("dd/MM/yyyy");
            }
        }
        public class SinhVien : Nguoi
        {
            public string MaSV { get; set; }
            public double DiemTB { get; set; }
            public SinhVien(string ma, string ten, DateTime ngaySinh, double diem) : base(ten, ngaySinh)
            {
                MaSV = ma;
                DiemTB = diem;
            }
            public override string MoTa()
            {
                return base.MoTa() + " - " + MaSV + " - " + DiemTB.ToString("N2");
            }
        }
        public abstract class NguoiHoc
        {
            public string HoTen { get; set; }
            public int SoTinChi { get; set; }
            public abstract decimal TinhHocPhi();
        }
        public class SinhVienChinhQuy : NguoiHoc
        {
            public override decimal TinhHocPhi()
            {
                return SoTinChi * 450000m;
            }
        }
        public class SinhVienLienThong : NguoiHoc
        {
            public override decimal TinhHocPhi()
            {
                return SoTinChi * 520000m;
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<NguoiHoc> ds = new List<NguoiHoc>();
            ds.Add(new SinhVienChinhQuy { HoTen = "An", SoTinChi = 18 });
            ds.Add(new SinhVienLienThong { HoTen = "Bình", SoTinChi = 15 });
            decimal tong = 0;
            foreach (NguoiHoc item in ds)
            {
                decimal hocPhi = item.TinhHocPhi();
                tong += hocPhi;
                Console.WriteLine("{0}: {1:N0}", item.HoTen, hocPhi);
            }
            Console.WriteLine("Tổng học phí: {0:N0}", tong);
        }
    }
}
