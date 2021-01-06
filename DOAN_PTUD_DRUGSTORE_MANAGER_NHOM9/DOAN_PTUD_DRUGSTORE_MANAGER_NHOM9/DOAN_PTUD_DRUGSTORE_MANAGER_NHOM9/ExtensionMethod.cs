using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DOAN_PTUD_DRUGSTORE_MANAGER_NHOM9
{
    public static class ExtensionMethod
    {
        public static bool KiemTraMaNhanVien(this string ms)
        {
            string rgs = @"^BH|QL|TK\d{3}$";

            return Regex.IsMatch(ms, rgs);
        }
        public static bool KiemTraMaKhachHang(this string ms)
        {
            string rgs = @"^KH\d{3}$";

            return Regex.IsMatch(ms, rgs);
        }
        public static bool KiemTraMaNCC(this string ms)
        {
            string rgs = @"^\d{4}$";

            return Regex.IsMatch(ms, rgs);
        }
    }
}
