using MVC_Test03.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVC_Test03.Controllers
{
    public class HomeController : Controller
    {
        private DBSportStoreEntities db = new DBSportStoreEntities();
        public ActionResult Index(int? page)
        {
        
            // Khai báo mỗi trang có 8 sản phẩm
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var selectedAQTDNames = new List<string>
    {
        "Bộ Bàn Ghế Phòng Ăn",
        "Bàn Ăn Dá Cẩm Thạch",
       "Bàn Ăn Nhập Khẩu ARETI-102"
    };
             var products = db.Products
             .Where(p => selectedAQTDNames.Contains(p.NamePro))
                     .OrderBy(x => Guid.NewGuid()) // Chọn ngẫu nhiên
                     .ToPagedList(pageNumber, pageSize); // Phân trang


            return View(products);
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