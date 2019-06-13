using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sistema_MVC_Mamani.Models;
using Sistema_MVC_Mamani.Filters;

namespace Sistema_MVC_Mamani.Controllers
{
    public class loginController : Controller
    {
        private Usuario usuario = new Usuario();



        // GET: login
        [NoLogin]
        // GET: login
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult validar(string Usuario , string Password)
        {
            var rm = usuario.validarlogin(Usuario, Password);

            if(rm.response)
            {
                rm.href = Url.Content("/demo");
            }
            return Json(rm);
        }

        public ActionResult logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/login");
        }


    }
}