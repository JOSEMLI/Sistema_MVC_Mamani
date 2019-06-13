using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sistema_MVC_Mamani.Models;
using Sistema_MVC_Mamani.Filters;

namespace Sistema_MVC_Mamani.Controllers
{
    [Autenticado]
    public class perfilController : Controller
    {

        private Usuario usu = new Usuario();

        // GET: perfil
        public ActionResult Index()
        {
            return View(usu.obtener(SessionHelper.GetUser()));
        }


        public JsonResult actualizar(Usuario model, HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();

            //retirar los campos que no se actualizan
            ModelState.Remove("usuario_id");
            ModelState.Remove("docente_id");
            ModelState.Remove("clave");
            ModelState.Remove("nivel");
            ModelState.Remove("estado");


            if (ModelState.IsValid)
            {
                rm = model.guardarperfil(foto);
            }
            rm.href = Url.Content("~/demo");
            return Json(rm);
        }


    }
}