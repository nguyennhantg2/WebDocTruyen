using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebDocTruyen.Models;

namespace WebDocTruyen.Controllers
{
    public class HomeController : Controller
    {
        DB_User db = new DB_User();
        DB_Truyen dbt = new DB_Truyen();
        public ActionResult Index()
        {
            return View(dbt.TRUYENs.ToList());
        }

        public ActionResult Test()
        {
            dynamic model = new ExpandoObject();
            model.Users = db.USERs.ToList();
            model.Truyens = dbt.TRUYENs.ToList();
            return View(model);
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

        public ActionResult QuanTri()
        {
            return View();
        }


        public ActionResult Register()
        {
            if (Session["USERNAME"] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(USER user)
        {
            if (ModelState.IsValid)
            {
                var check_username = db.USERs.FirstOrDefault(s => s.USERNAME.Equals(user.USERNAME));
                var check_email = db.USERs.FirstOrDefault(s => s.EMAIL.Equals(user.EMAIL));
                if(check_username == null && check_email == null)
                {
                    user.PASSWORD = GetMD5(user.PASSWORD);
                    user.IDCHUCVU = 10;
                    user.JOINDATE = DateTime.Now;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.USERs.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                if(check_username != null)
                {
                    ViewBag.error = "Tài khoản đã tồn tại!";
                    return View();
                }
                if(check_email != null)
                {
                    ViewBag.error = "Email này đã được sử dụng cho một tài khoản khác!";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            if(Session["USERNAME"] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var c_pass = GetMD5(password);
                var data = db.USERs.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(c_pass)).ToList();
                if(data.Count() > 0)
                {
                    Session["USERNAME"] = data.FirstOrDefault().USERNAME;
                    Session["IDUSER"] = data.FirstOrDefault().IDUSER;
                    Session["AVATAR"] = data.FirstOrDefault().LINKAVATAR;
                    Session["IDCHUCVU"] = data.FirstOrDefault().IDCHUCVU;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Sai tên tài khoản hoặc mật khẩu!";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        //MD5Hash
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }

    }
}