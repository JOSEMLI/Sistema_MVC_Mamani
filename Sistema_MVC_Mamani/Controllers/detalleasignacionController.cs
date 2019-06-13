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
    public class detalleasignacionController : Controller
    {
        private Asignacion objasignacion = new Asignacion();
        private DetalleAsignacion objdetalleasignacion = new DetalleAsignacion();
        private Docente objdocente = new Docente();
        private Criterio objcriterio = new Criterio();

        // GET: detalleasignacion
        public ActionResult Index()
        {
            return View(objdetalleasignacion.listar());
        }


        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objdetalleasignacion.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.asignacion = objasignacion.listar();
            ViewBag.docente = objdocente.listar();
            ViewBag.criterio = objcriterio.listar();
            return View(
                id == 0 ? new DetalleAsignacion() //agrega un nuevo objeto
                : objdetalleasignacion.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(DetalleAsignacion objdetalleasignacion)
        {

            if (ModelState.IsValid)
            {
                objdetalleasignacion.guardar();
                return Redirect("~/detalleasignacion");
            }
            else
            {
                return View("~/Views/detalleasignacion/agregareditar.cshtml", objdetalleasignacion);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objdetalleasignacion.detalleasignacion_id = id;
            objdetalleasignacion.eliminar();
            return Redirect("~/detalleasignacion");
        }



    }
}