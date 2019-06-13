using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sistema_MVC_Mamani.Models;

namespace Sistema_MVC_Mamani.Controllers
{
    public class docenteController : Controller
    {
        //instanciar la clase docente

        private Docente objdocente = new Docente();

        // GET: docente
        public ActionResult Index()
        {
            return View(objdocente.listar());
        }

        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objdocente.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            return View(
                id == 0 ? new Docente() //agrega un nuevo objeto
                : objdocente.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Docente docente)
        {

            if (ModelState.IsValid)
            {
                docente.guardar();
                return Redirect("~/docente");
            }
            else
            {
                return View("~/Views/docente/agregareditar.cshtml", docente);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objdocente.docente_id = id;
            objdocente.eliminar();
            return Redirect("~/docente");
        }



    }
}