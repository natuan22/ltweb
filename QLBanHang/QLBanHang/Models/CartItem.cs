using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBanHang.Models
{
    public class CartItem
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int Soluong { get; set; }
        public double Dongia { get; set; }
        public double Thanhtien
        {
            get { return Dongia * Soluong; }
        }
    }
}