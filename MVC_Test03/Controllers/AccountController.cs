using MVC_Test03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Test03.Controllers
{
    public class AccountController : Controller
    {
        // GET: SignIn
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminUser user)
        {
            using (var db = new DBSportStoreEntities())
            {
                var validUser = db.AdminUsers.FirstOrDefault(u => u.NameUser == user.NameUser && u.PasswordUser == user.PasswordUser);
                if (validUser != null)
                {
                    FormsAuthentication.SetAuthCookie(validUser.NameUser, false);
                    Session["Role"] = validUser.RoleUser;  // Lưu vai trò người dùng trong session
                    return RedirectToAction("ProductList", "Products");
                }
                ViewBag.ErrorMessage = "Invalid Username or Password";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Role"] = null;  // Xóa session vai trò người dùng
            return RedirectToAction("Login", "Home");
        }

    }
}