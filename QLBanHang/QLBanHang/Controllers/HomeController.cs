using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;
using System.Data.Entity;
using PagedList;

namespace QLBanHang.Controllers
{
    public class HomeController : Controller
    {
        private qlbanhangEntities db = new qlbanhangEntities();
        public ActionResult Index(string currentFilter, int?page, int maloaisp = 0, string SearchString="")
        {
            if (SearchString != "")
            {
                page = 1;
                var sanPhams = db.SanPhams.Where(x => x.TenSP.ToUpper().Contains(SearchString.ToUpper()));
                sanPhams = sanPhams.OrderBy(x => x.TenSP);

                int pageSize = sanPhams.Count();
                int pageNumber = (page ?? 1);
                return View(sanPhams.ToPagedList(pageNumber, pageSize));
            }
            else
                SearchString = currentFilter;
            ViewBag.CurrentFilter = currentFilter;
            if (maloaisp == 0)
            {
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var sanPhams = db.SanPhams.OrderBy(x => x.TenSP);
                return View(sanPhams.ToPagedList(pageNumber, pageSize));
            } 
            else
            {
                var sanPhams = db.SanPhams.Where(x => x.MaLoaiSP == maloaisp);
                sanPhams = sanPhams.OrderBy(x => x.TenSP);

                int pageSize = sanPhams.Count();
                int pageNumber = (page ?? 1);
                return View(sanPhams.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}