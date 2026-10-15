using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai8
{
    abstract class TaiLieu
    {
        public string MaTaiLieu { get; set; }
        public string TenTaiLieu { get; set; }

        public TaiLieu(string ma, string ten)
        {
            MaTaiLieu = ma;
            TenTaiLieu = ten;
        }

        public abstract string LayLoai();

        public virtual void HienThi()
        {
            Console.WriteLine("Ma tai lieu: " + MaTaiLieu);
            Console.WriteLine("Ten tai lieu: " + TenTaiLieu);
            Console.WriteLine("Loai tai lieu: " + LayLoai());
        }
    }

    class Sach : TaiLieu
    {
        public string TacGia { get; set; }
        public int SoTrang { get; set; }

        public Sach(string ma, string ten, string tacGia, int soTrang)
            : base(ma, ten)
        {
            TacGia = tacGia;
            SoTrang = soTrang;
        }

        public override string LayLoai()
        {
            return "Sach";
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine("Tac gia: " + TacGia);
            Console.WriteLine("So trang: " + SoTrang);
        }
    }

    class TapChi : TaiLieu
    {
        public int SoPhatHanh { get; set; }
        public int ThangPhatHanh { get; set; }

        public TapChi(string ma, string ten, int soPhatHanh, int thang)
            : base(ma, ten)
        {
            SoPhatHanh = soPhatHanh;
            ThangPhatHanh = thang;
        }

        public override string LayLoai()
        {
            return "Tap chi";
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine("So phat hanh: " + SoPhatHanh);
            Console.WriteLine("Thang phat hanh: " + ThangPhatHanh);
        }
    }

    class LuanVan : TaiLieu
    {
        public string TacGia { get; set; }
        public string ChuyenNganh { get; set; }

        public LuanVan(string ma, string ten, string tacGia, string chuyenNganh)
            : base(ma, ten)
        {
            TacGia = tacGia;
            ChuyenNganh = chuyenNganh;
        }

        public override string LayLoai()
        {
            return "Luan van";
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine("Tac gia: " + TacGia);
            Console.WriteLine("Chuyen nganh: " + ChuyenNganh);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<TaiLieu> danhSach = new List<TaiLieu>
        {
            new Sach("S01", "Lap trinh C#", "Nguyen An", 300),
            new Sach("S02", "Co so du lieu", "Tran Binh", 250),
            new TapChi("TC01", "Cong nghe thong tin", 15, 10),
            new LuanVan("LV01", "Tri tue nhan tao", "Le Minh", "CNTT")
        };

            int chon;

            do
            {
                Console.WriteLine("\n===== QUAN LY TAI LIEU THU VIEN =====");
                Console.WriteLine("1. Hien thi tat ca tai lieu");
                Console.WriteLine("2. Tim kiem tai lieu");
                Console.WriteLine("3. In tai lieu theo loai");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Vui long nhap mot so!");
                    continue;
                }

                switch (chon)
                {
                    case 1:
                        Console.WriteLine("\n===== DANH SACH TAI LIEU =====");

                        foreach (TaiLieu tl in danhSach)
                        {
                            Console.WriteLine("--------------------------");
                            tl.HienThi();
                        }
                        break;

                    case 2:
                        Console.Write("Nhap ma hoac ten tai lieu can tim: ");
                        string tuKhoa = Console.ReadLine() ?? "";

                        List<TaiLieu> ketQua = danhSach
                            .Where(t =>
                                t.MaTaiLieu.IndexOf(
                                    tuKhoa,
                                    StringComparison.OrdinalIgnoreCase) >= 0
                                ||
                                t.TenTaiLieu.IndexOf(
                                    tuKhoa,
                                    StringComparison.OrdinalIgnoreCase) >= 0)
                            .ToList();

                        if (ketQua.Count > 0)
                        {
                            Console.WriteLine("\n===== KET QUA TIM KIEM =====");

                            foreach (TaiLieu tl in ketQua)
                            {
                                Console.WriteLine("--------------------------");
                                tl.HienThi();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay tai lieu!");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n===== CHON LOAI TAI LIEU =====");
                        Console.WriteLine("1. Sach");
                        Console.WriteLine("2. Tap chi");
                        Console.WriteLine("3. Luan van");
                        Console.Write("Nhap loai: ");

                        int loaiChon;

                        if (!int.TryParse(Console.ReadLine(), out loaiChon))
                        {
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                        }

                        string loai = "";

                        switch (loaiChon)
                        {
                            case 1:
                                loai = "Sach";
                                break;

                            case 2:
                                loai = "Tap chi";
                                break;

                            case 3:
                                loai = "Luan van";
                                break;

                            default:
                                Console.WriteLine("Lua chon khong hop le!");
                                break;
                        }

                        if (loai == "")
                        {
                            break;
                        }

                        List<TaiLieu> theoLoai = danhSach
                            .Where(t => t.LayLoai() == loai)
                            .ToList();

                        if (theoLoai.Count > 0)
                        {
                            foreach (TaiLieu tl in theoLoai)
                            {
                                Console.WriteLine("--------------------------");
                                tl.HienThi();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong co tai lieu thuoc loai nay!");
                        }
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
    }
}
