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
    public class usuarioController : Controller
    {
        //instanciar la clase semestre

        private Usuario objusuario = new Usuario();
        private Docente objdocente = new Docente();

        // GET: usuario
        public ActionResult Index()
        {
            return View(objusuario.listar());
        }


        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objusuario.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.docente = objdocente.listar();
            return View(
                id == 0 ? new Usuario() //agrega un nuevo objeto
                : objusuario.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Usuario objusuario)
        {

            if (ModelState.IsValid)
            {
                objusuario.guardar();
                return Redirect("~/usuario");
            }
            else
            {
                return View("~/Views/usuario/agregareditar.cshtml", objusuario);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objusuario.usuario_id = id;
            objusuario.eliminar();
            return Redirect("~/usuario");
        }







    }
}