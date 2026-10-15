using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai10
{
    public interface IXuatDuLieu
    {
        string XuatDuLieu();
    }

    // Lop nguoi
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

    // Sinh vien co ma va diem trung binh
    public class SinhVien : Nguoi, IXuatDuLieu
    {
        public string MaSV { get; set; }
        public double DiemTB { get; set; }

        public SinhVien(
            string ma, string ten, DateTime ngaySinh, double diem)
            : base(ten, ngaySinh)
        {
            MaSV = ma;
            DiemTB = diem;
        }

        public override string MoTa()
        {
            return base.MoTa() + " - " + MaSV + " - " + DiemTB.ToString("N2");
        }

        public virtual string LayLoai()
        {
            return "Sinh vien";
        }

        public virtual decimal TinhHocPhi()
        {
            return 0;
        }

        public virtual string XuatDuLieu()
        {
            return MaSV + "," + HoTen + "," +
                   NgaySinh.ToString("dd/MM/yyyy") + "," +
                   DiemTB.ToString("N2") + "," +
                   LayLoai() + "," + TinhHocPhi().ToString("0");
        }

        public virtual void HienThi()
        {
            Console.WriteLine("Ma sinh vien: " + MaSV);
            Console.WriteLine("Ho ten: " + HoTen);
            Console.WriteLine("Ngay sinh: " + NgaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Diem trung binh: " + DiemTB.ToString("N2"));
            Console.WriteLine("Loai: " + LayLoai());
            Console.WriteLine("Hoc phi: " + TinhHocPhi().ToString("N0") + " VND");
        }
    }

    // Lop nguoi hoc truu tuong
    public abstract class NguoiHoc
    {
        public string HoTen { get; set; }
        public int SoTinChi { get; set; }

        public abstract decimal TinhHocPhi();
    }

    // Sinh vien chinh quy
    public class SinhVienChinhQuy : SinhVien
    {
        public int SoTinChi { get; set; }

        public SinhVienChinhQuy(
            string ma, string ten, DateTime ngaySinh,
            double diem, int soTinChi)
            : base(ma, ten, ngaySinh, diem)
        {
            SoTinChi = soTinChi;
        }

        public override string LayLoai()
        {
            return "Chinh quy";
        }

        public override decimal TinhHocPhi()
        {
            return SoTinChi * 450000m;
        }
    }

    // Sinh vien lien thong
    public class SinhVienLienThong : SinhVien
    {
        public int SoTinChi { get; set; }

        public SinhVienLienThong(
            string ma, string ten, DateTime ngaySinh,
            double diem, int soTinChi)
            : base(ma, ten, ngaySinh, diem)
        {
            SoTinChi = soTinChi;
        }

        public override string LayLoai()
        {
            return "Lien thong";
        }

        public override decimal TinhHocPhi()
        {
            return SoTinChi * 520000m;
        }
    }

    // Sinh vien tu xa
    public class SinhVienTuXa : SinhVien
    {
        public int SoTinChi { get; set; }

        public SinhVienTuXa(
            string ma, string ten, DateTime ngaySinh,
            double diem, int soTinChi)
            : base(ma, ten, ngaySinh, diem)
        {
            SoTinChi = soTinChi;
        }

        public override string LayLoai()
        {
            return "Tu xa";
        }

        public override decimal TinhHocPhi()
        {
            return SoTinChi * 350000m;
        }
    }

    internal class Program
    {
        static List<SinhVien> danhSach = new List<SinhVien>();

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Du lieu mau
            danhSach.Add(new SinhVienChinhQuy(
                "SV01", "Nguyen An", new DateTime(2004, 5, 12), 8.5, 20));

            danhSach.Add(new SinhVienLienThong(
                "SV02", "Tran Binh", new DateTime(2002, 8, 20), 7.8, 18));

            danhSach.Add(new SinhVienTuXa(
                "SV03", "Le Minh", new DateTime(2003, 3, 15), 9.0, 15));

            int chon;

            do
            {
                Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Hien thi danh sach");
                Console.WriteLine("3. Tim kiem sinh vien");
                Console.WriteLine("4. Thong ke theo loai");
                Console.WriteLine("5. Xuat du lieu ra file CSV");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }

                switch (chon)
                {
                    case 1:
                        ThemSinhVien();
                        break;

                    case 2:
                        HienThiDanhSach(danhSach);
                        break;

                    case 3:
                        TimKiem();
                        break;

                    case 4:
                        ThongKe();
                        break;

                    case 5:
                        XuatCSV();
                        break;

                    case 0:
                        Console.WriteLine("Da thoat chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (chon != 0);
        }

        static void ThemSinhVien()
        {
            Console.WriteLine("\nChon loai sinh vien:");
            Console.WriteLine("1. Chinh quy");
            Console.WriteLine("2. Lien thong");
            Console.WriteLine("3. Tu xa");
            Console.Write("Lua chon: ");

            int loai;
            if (!int.TryParse(Console.ReadLine(), out loai) ||
                loai < 1 || loai > 3)
            {
                Console.WriteLine("Loai sinh vien khong hop le!");
                return;
            }

            Console.Write("Ma sinh vien: ");
            string ma = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(ma))
            {
                Console.WriteLine("Ma sinh vien khong duoc de trong!");
                return;
            }

            if (danhSach.Any(s =>
                string.Equals(s.MaSV, ma, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Ma sinh vien da ton tai!");
                return;
            }

            Console.Write("Ho ten: ");
            string ten = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(ten))
            {
                Console.WriteLine("Ho ten khong duoc de trong!");
                return;
            }

            Console.Write("Ngay sinh (dd/MM/yyyy): ");
            DateTime ngaySinh;

            if (!DateTime.TryParseExact(
                Console.ReadLine(),
                "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out ngaySinh))
            {
                Console.WriteLine("Ngay sinh khong hop le!");
                return;
            }

            Console.Write("Diem trung binh (0-10): ");
            double diem;

            if (!double.TryParse(Console.ReadLine(), out diem) ||
                diem < 0 || diem > 10)
            {
                Console.WriteLine("Diem phai tu 0 den 10!");
                return;
            }

            Console.Write("So tin chi: ");
            int tinChi;

            if (!int.TryParse(Console.ReadLine(), out tinChi) || tinChi < 0)
            {
                Console.WriteLine("So tin chi khong hop le!");
                return;
            }

            SinhVien sv;

            switch (loai)
            {
                case 1:
                    sv = new SinhVienChinhQuy(
                        ma, ten, ngaySinh, diem, tinChi);
                    break;

                case 2:
                    sv = new SinhVienLienThong(
                        ma, ten, ngaySinh, diem, tinChi);
                    break;

                default:
                    sv = new SinhVienTuXa(
                        ma, ten, ngaySinh, diem, tinChi);
                    break;
            }

            danhSach.Add(sv);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        static void HienThiDanhSach(List<SinhVien> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            foreach (SinhVien sv in ds)
            {
                Console.WriteLine("\n------------------------");
                sv.HienThi();
            }
        }

        static void TimKiem()
        {
            Console.Write("Nhap ma hoac ten sinh vien: ");
            string tuKhoa = Console.ReadLine() ?? "";

            List<SinhVien> ketQua = danhSach
                .Where(s =>
                    s.MaSV.IndexOf(
                        tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
                    ||
                    s.HoTen.IndexOf(
                        tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }

            HienThiDanhSach(ketQua);
        }

        static void ThongKe()
        {
            Console.WriteLine("\n===== THONG KE THEO LOAI =====");

            var nhomLoai = danhSach.GroupBy(s => s.LayLoai());

            foreach (var nhom in nhomLoai)
            {
                Console.WriteLine("Loai: " + nhom.Key);
                Console.WriteLine("So sinh vien: " + nhom.Count());
                Console.WriteLine("Tong hoc phi: " +
                    nhom.Sum(s => s.TinhHocPhi()).ToString("N0") + " VND");

                if (nhom.Any())
                {
                    Console.WriteLine("Diem trung binh cua loai: " +
                        nhom.Average(s => s.DiemTB).ToString("N2"));
                }

                Console.WriteLine("------------------------");
            }

            Console.WriteLine("Tong so sinh vien: " + danhSach.Count);
            Console.WriteLine("Tong hoc phi: " +
                danhSach.Sum(s => s.TinhHocPhi()).ToString("N0") + " VND");
        }

        static void XuatCSV()
        {
            string duongDan = "DanhSachSinhVien.csv";

            try
            {
                using (StreamWriter sw = new StreamWriter(
                    duongDan, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(
                        "MaSV,HoTen,NgaySinh,DiemTB,Loai,SoTinChi,HocPhi");

                    foreach (SinhVien sv in danhSach)
                    {
                        sw.WriteLine(
                            sv.MaSV + "," +
                            "\"" + sv.HoTen.Replace("\"", "\"\"") + "\"," +
                            sv.NgaySinh.ToString("dd/MM/yyyy") + "," +
                            sv.DiemTB.ToString(
                                System.Globalization.CultureInfo.InvariantCulture) + "," +
                            sv.LayLoai() + "," +
                            LaySoTinChi(sv) + "," +
                            sv.TinhHocPhi().ToString(
                                System.Globalization.CultureInfo.InvariantCulture));
                    }
                }

                Console.WriteLine("Da xuat du lieu ra file: " + duongDan);
                Console.WriteLine("Thu muc: " + Environment.CurrentDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi xuat file: " + ex.Message);
            }
        }

        static int LaySoTinChi(SinhVien sv)
        {
            SinhVienChinhQuy chinhQuy = sv as SinhVienChinhQuy;
            if (chinhQuy != null)
                return chinhQuy.SoTinChi;

            SinhVienLienThong lienThong = sv as SinhVienLienThong;
            if (lienThong != null)
                return lienThong.SoTinChi;

            SinhVienTuXa tuXa = sv as SinhVienTuXa;
            if (tuXa != null)
                return tuXa.SoTinChi;

            return 0;
        }
}
}
