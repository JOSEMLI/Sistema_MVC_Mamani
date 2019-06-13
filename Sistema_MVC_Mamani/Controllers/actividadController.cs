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
    public class actividadController : Controller
    {
        //instanciar la clase asignacion y semestre

        private Actividad objactividad = new Actividad();
        private Semestre objsemestre = new Semestre();
        private Criterio objcriterio = new Criterio();


        // GET: actividad
        public ActionResult Index()
        {
            return View(objactividad.listar());
        }

        //accion visualizar
        public ActionResult visualizar(int id)
        {
            //ViewBag.docente = objdocente.listar();
            return View(objactividad.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.semestre = objsemestre.listar();
            ViewBag.criterio = objcriterio.listar();

            return View(
                id == 0 ? new Actividad() //agrega un nuevo objeto
                : objactividad.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Actividad objactividad)
        {

            if (ModelState.IsValid)
            {
                objactividad.guardar();
                return Redirect("~/actividad");
            }
            else
            {
                return View("~/Views/actividad/agregareditar.cshtml", objactividad);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objactividad.actividad_id = id;
            objactividad.eliminar();
            return Redirect("~/actividad");
        }





    }
}