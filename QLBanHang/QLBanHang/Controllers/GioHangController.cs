using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace QLBanHang.Models
{
    public class GioHangController : Controller
    {
        private qlbanhangEntities db = new qlbanhangEntities();
        // GET: GioHang
        public ActionResult Index()
        {
            var giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }
        public ActionResult AddToCart(string MaSP)
        {
            var sanpham = db.SanPhams.FirstOrDefault(x => x.MaSP == MaSP);
            var giohang = Session["giohang"] as List<CartItem>;
            var item = giohang.FirstOrDefault(x => x.MaSP == MaSP);
            if (item == null)
            {
                var newitem = new CartItem();
                newitem.MaSP = MaSP;
                newitem.TenSP = sanpham.TenSP;
                newitem.Soluong = 1;
                newitem.Dongia = Convert.ToDouble(sanpham.Dongia);
                giohang.Add(newitem);
            }
            else
            {
                item.Soluong++;
            }
            Session["giohang"] = giohang;
            return RedirectToAction("Index");
        }
        public ActionResult Update(string MaSP, int Soluong)
        {
            var sanpham = db.SanPhams.FirstOrDefault(x => x.MaSP == MaSP);
            var giohang = Session["giohang"] as List<CartItem>;
            var item = giohang.FirstOrDefault(x => x.MaSP == MaSP);
            item.Soluong = Soluong;
            Session["giohang"] = giohang;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string MaSP)
        {
            var giohang = Session["giohang"] as List<CartItem>;
            var item = giohang.FirstOrDefault(x => x.MaSP == MaSP);
            giohang.Remove(item);
            Session["giohang"] = giohang;
            return RedirectToAction("Index");
        }
        public ActionResult Order(string Email, string Phone)
        {
            var giohang = Session["giohang"] as List<CartItem>;
            string msg = "<html><head><meta charset=UTF-8><head/><body><table border='1'>";
            msg += "<tr><th>STT</th><th>Mã hàng</th><th>Tên hàng</th><th>Số lượng</th><th>Đơn giá</th><th>Thành tiền</th></tr>";
            int i = 1;
            foreach (var item in giohang)
            {
                msg += "<tr>";
                msg += "<td>" + i.ToString() + "</td>";
                msg += "<td>" + item.MaSP + "</td>";
                msg += "<td>" + item.TenSP + "</td>";
                msg += "<td>" + item.Soluong + "</td>";
                msg += "<td>" + String.Format("{0:0,### VNĐ}", item.Dongia) + "</td>";
                msg += "<td>" + String.Format("{0:0,### VNĐ}", item.Thanhtien) + "</td>";
                msg += "</tr>";
                i++;
            }
            msg += "<tr><td colspan='6'>Tổng cộng: " + String.Format("{0:0,### VNĐ}", giohang.Sum(x => x.Thanhtien)) + "</td></tr></table></body></html>";
            MailMessage mail = new MailMessage("anhtuan222001@gmail.com", Email, "Thông tin đặt hàng", msg);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("anhtuan222001", "huhneoshqupzhonv");
            mail.IsBodyHtml = true;
            client.Send(mail);
            return RedirectToAction("Index", "Home");
        }
    }
}