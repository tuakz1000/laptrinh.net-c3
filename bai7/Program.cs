using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai7
{
    interface IMove
    {
        double TinhTocDo();
        double TinhChiPhiVanHanh(double soKm);
        void HienThi();
    }

    class XeMay : IMove
    {
        public double TocDo { get; set; }
        public double ChiPhiMoiKm { get; set; }

        public XeMay(double tocDo, double chiPhiMoiKm)
        {
            TocDo = tocDo;
            ChiPhiMoiKm = chiPhiMoiKm;
        }

        public double TinhTocDo()
        {
            return TocDo;
        }

        public double TinhChiPhiVanHanh(double soKm)
        {
            return soKm * ChiPhiMoiKm;
        }

        public void HienThi()
        {
            Console.WriteLine("Phương tiện: Xe máy");
            Console.WriteLine($"Tốc độ: {TinhTocDo()} km/h");
        }
    }

    class OTo : IMove
    {
        public double TocDo { get; set; }
        public double ChiPhiMoiKm { get; set; }

        public OTo(double tocDo, double chiPhiMoiKm)
        {
            TocDo = tocDo;
            ChiPhiMoiKm = chiPhiMoiKm;
        }

        public double TinhTocDo()
        {
            return TocDo;
        }

        public double TinhChiPhiVanHanh(double soKm)
        {
            return soKm * ChiPhiMoiKm;
        }

        public void HienThi()
        {
            Console.WriteLine("Phương tiện: Ô tô");
            Console.WriteLine($"Tốc độ: {TinhTocDo()} km/h");
        }
    }

    class XeDap : IMove
    {
        public double TocDo { get; set; }
        public double ChiPhiMoiKm { get; set; }

        public XeDap(double tocDo, double chiPhiMoiKm)
        {
            TocDo = tocDo;
            ChiPhiMoiKm = chiPhiMoiKm;
        }

        public double TinhTocDo()
        {
            return TocDo;
        }

        public double TinhChiPhiVanHanh(double soKm)
        {
            return soKm * ChiPhiMoiKm;
        }

        public void HienThi()
        {
            Console.WriteLine("Phương tiện: Xe đạp");
            Console.WriteLine($"Tốc độ: {TinhTocDo()} km/h");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IMove[] danhSach =
            {
            new XeMay(40, 1500),
            new OTo(60, 5000),
            new XeDap(15, 0)
        };

            double soKm = 100;

            foreach (IMove xe in danhSach)
            {
                xe.HienThi();

                Console.WriteLine(
                    $"Chi phí đi {soKm} km: " +
                    $"{xe.TinhChiPhiVanHanh(soKm):N0} VNĐ");

                Console.WriteLine("----------------------");
            }
        }
    }
}
