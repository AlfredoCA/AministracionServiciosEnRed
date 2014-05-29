using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventarios.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        
        public ActionResult SignInAsDifferentUser()
        {

            HttpCookie cookie = base.Request.Cookies["TSWA-Last-User"];

            if (base.User.Identity.IsAuthenticated == false || cookie == null || StringComparer.OrdinalIgnoreCase.Equals(base.User.Identity.Name, cookie.Value))
            {

                string name = string.Empty;
                if (base.Request.IsAuthenticated)
                {
                    name = this.User.Identity.Name;
                }

                cookie = new HttpCookie("TSWA-Last-User", name);
                base.Response.Cookies.Set(cookie);

                base.Response.AppendHeader("Connection", "close");
                base.Response.StatusCode = 0x191;
                base.Response.Clear();
                base.Response.Write("Acceso denegado.");
                base.Response.End();
                return RedirectToAction("Index");
            }

            cookie = new HttpCookie("TSWA-Last-User", string.Empty)
            {
                Expires = DateTime.Now.AddYears(-5)
            };
            base.Response.Cookies.Set(cookie);

            return RedirectToRoute("Default", new { controller = "Home", action = "Index" });
        }





    }


    }

