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
    public class asignacionController : Controller
    {
        //instanciar la clase asignacion y semestre

        private Asignacion objasignacion = new Asignacion();
        private Semestre objsemestre = new Semestre();
        private Docente objdocente = new Docente();
        private DetalleAsignacion objdetalleasignacion = new DetalleAsignacion();

        // GET: asignacion
        public ActionResult Index()
        {
            return View(objasignacion.listar());
        }
        
        //accion visualizar
        public ActionResult visualizar(int id)
        {
            ViewBag.docente = objdocente.listar();
            return View(objasignacion.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {

            return View(
                id == 0 ? new Asignacion() //agrega un nuevo objeto
                : objasignacion.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Asignacion objasignacion)
        {

            if (ModelState.IsValid)
            {
                objasignacion.guardar();
                return Redirect("~/asignacion");
            }
            else
            {
                return View("~/Views/asignacion/agregareditar.cshtml", objasignacion);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objasignacion.asignacion_id = id;
            objasignacion.eliminar();
            return Redirect("~/asignacion");
        }



    }
}