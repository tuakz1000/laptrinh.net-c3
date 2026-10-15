using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai4
{
    internal class Program
    {
        public interface IValidatable
        {
            bool IsValid(out string message);
        }
        public interface IPrintable
        {
            string ToDisplayText();
        }
        public class SinhVien : IValidatable, IPrintable
        {
            public string MaSV { get; set; }
            public string HoTen { get; set; }
            public double DiemTB { get; set; }
            public bool IsValid(out string message)
            {
                if (string.IsNullOrWhiteSpace(MaSV)) { message = "Thiếu mã"; return false; }
                if (DiemTB < 0 || DiemTB > 10) { message = "Điểm sai"; return false; }
                message = ""; return true;
            }
            public string ToDisplayText() { return MaSV + " - " + HoTen; }
        }
        static void Main(string[] args)
        {
        }
    }
}
