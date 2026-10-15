using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai9
{
    interface IPayment
    {
        bool KiemTra(double soTien);
        bool ThanhToan(double soTien);
        string LayTenPhuongThuc();
    }

    class ThanhToanTienMat : IPayment
    {
        public bool KiemTra(double soTien)
        {
            return soTien > 0;
        }

        public bool ThanhToan(double soTien)
        {
            if (!KiemTra(soTien))
            {
                Console.WriteLine("So tien khong hop le!");
                return false;
            }

            Console.WriteLine("Da thanh toan bang tien mat.");
            return true;
        }

        public string LayTenPhuongThuc()
        {
            return "Tien mat";
        }
    }

    class ChuyenKhoan : IPayment
    {
        public string SoTaiKhoan { get; set; }

        public ChuyenKhoan(string soTaiKhoan)
        {
            SoTaiKhoan = soTaiKhoan;
        }

        public bool KiemTra(double soTien)
        {
            return soTien > 0 && !string.IsNullOrWhiteSpace(SoTaiKhoan);
        }

        public bool ThanhToan(double soTien)
        {
            if (!KiemTra(soTien))
            {
                Console.WriteLine("So tien hoac so tai khoan khong hop le!");
                return false;
            }

            Console.WriteLine("Chuyen khoan thanh cong.");
            return true;
        }

        public string LayTenPhuongThuc()
        {
            return "Chuyen khoan";
        }
    }

    class ViDienTu : IPayment
    {
        public string SoDienThoai { get; set; }
        public double SoDu { get; private set; }

        public ViDienTu(string soDienThoai, double soDu)
        {
            SoDienThoai = soDienThoai;
            SoDu = soDu;
        }

        public bool KiemTra(double soTien)
        {
            return soTien > 0
                && !string.IsNullOrWhiteSpace(SoDienThoai)
                && SoDu >= soTien;
        }

        public bool ThanhToan(double soTien)
        {
            if (!KiemTra(soTien))
            {
                Console.WriteLine("So du khong du hoac thong tin vi khong hop le!");
                return false;
            }

            SoDu -= soTien;
            Console.WriteLine("Thanh toan vi dien tu thanh cong.");
            Console.WriteLine($"So du con lai: {SoDu:N0} VND");
            return true;
        }

        public string LayTenPhuongThuc()
        {
            return "Vi dien tu";
        }
    }

    class GiaoDich
    {
        public string MaGiaoDich { get; set; }
        public string PhuongThuc { get; set; }
        public double SoTien { get; set; }
        public DateTime ThoiGian { get; set; }
        public string TrangThai { get; set; }

        public GiaoDich(
            string ma, string phuongThuc,
            double soTien, string trangThai)
        {
            MaGiaoDich = ma;
            PhuongThuc = phuongThuc;
            SoTien = soTien;
            TrangThai = trangThai;
            ThoiGian = DateTime.Now;
        }

        public void HienThi()
        {
            Console.WriteLine($"Ma giao dich: {MaGiaoDich}");
            Console.WriteLine($"Phuong thuc: {PhuongThuc}");
            Console.WriteLine($"So tien: {SoTien:N0} VND");
            Console.WriteLine($"Thoi gian: {ThoiGian}");
            Console.WriteLine($"Trang thai: {TrangThai}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<GiaoDich> lichSu = new List<GiaoDich>();
            int stt = 1;
            int chon;

            do
            {
                Console.WriteLine("\n===== HE THONG THANH TOAN =====");
                Console.WriteLine("1. Thanh toan tien mat");
                Console.WriteLine("2. Chuyen khoan");
                Console.WriteLine("3. Vi dien tu");
                Console.WriteLine("4. Xem lich su giao dich");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Vui long nhap so!");
                    continue;
                }

                if (chon >= 1 && chon <= 3)
                {
                    Console.Write("Nhap so tien: ");

                    double soTien;

                    if (!double.TryParse(Console.ReadLine(), out soTien)
                        || soTien <= 0)
                    {
                        Console.WriteLine("So tien khong hop le!");
                        continue;
                    }

                    IPayment payment = null;

                    switch (chon)
                    {
                        case 1:
                            payment = new ThanhToanTienMat();
                            break;

                        case 2:
                            Console.Write("Nhap so tai khoan: ");
                            string stk = Console.ReadLine() ?? "";
                            payment = new ChuyenKhoan(stk);
                            break;

                        case 3:
                            Console.Write("Nhap so dien thoai vi: ");
                            string sdt = Console.ReadLine() ?? "";

                            Console.Write("Nhap so du vi: ");
                            double soDu;

                            if (!double.TryParse(
                                Console.ReadLine(), out soDu) || soDu < 0)
                            {
                                Console.WriteLine("So du khong hop le!");
                                continue;
                            }

                            payment = new ViDienTu(sdt, soDu);
                            break;
                    }

                    bool thanhCong = payment.ThanhToan(soTien);

                    GiaoDich gd = new GiaoDich(
                        "GD" + stt.ToString("D3"),
                        payment.LayTenPhuongThuc(),
                        soTien,
                        thanhCong ? "Thanh cong" : "That bai"
                    );

                    lichSu.Add(gd);
                    stt++;

                    Console.WriteLine("\n===== KET QUA GIAO DICH =====");
                    gd.HienThi();
                }
                else if (chon == 4)
                {
                    Console.WriteLine("\n===== LICH SU GIAO DICH =====");

                    if (lichSu.Count == 0)
                    {
                        Console.WriteLine("Chua co giao dich nao.");
                    }
                    else
                    {
                        foreach (GiaoDich gd in lichSu)
                        {
                            Console.WriteLine("------------------------");
                            gd.HienThi();
                        }
                    }
                }
                else if (chon == 0)
                {
                    Console.WriteLine("Da thoat chuong trinh.");
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le!");
                }

            } while (chon != 0);
        }
    }
}
