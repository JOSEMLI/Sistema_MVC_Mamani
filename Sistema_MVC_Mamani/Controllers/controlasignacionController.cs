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
    public class controlasignacionController : Controller
    {
        //instanciar la clase asignacion y semestre

        private ControlAsignacion objcontrolasignacion = new ControlAsignacion();
        private Semestre objsemestre = new Semestre();
        private Criterio objcriterio = new Criterio();
        private Docente objdocente = new Docente();
        private Control objcontrol = new Control();


        // GET: controlasignacion
        public ActionResult Index()
        {
            return View(objcontrolasignacion.listar());
        }


        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objcontrolasignacion.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.criterio = objcriterio.listar();
            ViewBag.docente = objdocente.listar();
            ViewBag.control = objcontrol.listar();

            return View(
                id == 0 ? new ControlAsignacion() //agrega un nuevo objeto
                : objcontrolasignacion.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(ControlAsignacion objcontrolasignacion)
        {

            if (ModelState.IsValid)
            {
                objcontrolasignacion.guardar();
                return Redirect("~/controlasignacion");
            }
            else
            {
                return View("~/Views/controlasignacion/agregareditar.cshtml", objcontrolasignacion);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objcontrolasignacion.controlasignacion_id = id;
            objcontrolasignacion.eliminar();
            return Redirect("~/controlasignacion");
        }


    }
}