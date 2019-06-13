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
    public class evidenciaactividadController : Controller
    {
        private Actividad objactividad = new Actividad();
        private EvidenciaActividad objevidenciaactividad = new EvidenciaActividad();

        // GET: evidenciaactividad
        public ActionResult Index()
        {
            return View(objevidenciaactividad.listar());
        }

        

        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objevidenciaactividad.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.actividad = objactividad.listar();
            return View(
                id == 0 ? new EvidenciaActividad() //agrega un nuevo objeto
                : objevidenciaactividad.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(EvidenciaActividad objevidenciaactividad)
        {

            if (ModelState.IsValid)
            {
                objevidenciaactividad.guardar();
                return Redirect("~/evidenciaactividad");
            }
            else
            {
                return View("~/Views/evidenciaactividad/agregareditar.cshtml", objevidenciaactividad);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objevidenciaactividad.evidenciaactividad_id = id;
            objevidenciaactividad.eliminar();
            return Redirect("~/evidenciaactividad");
        }

    }
}