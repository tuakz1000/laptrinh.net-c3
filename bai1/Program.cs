using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1
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
        }
    }
}
