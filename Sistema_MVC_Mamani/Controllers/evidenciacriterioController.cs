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
    public class evidenciacriterioController : Controller
    {
        private Criterio objcriterio = new Criterio();
        private EvidenciaCriterio objevidenciacriterio = new EvidenciaCriterio();

        // GET: evidenciacriterio
        public ActionResult Index()
        {
            return View(objevidenciacriterio.listar());
        }



        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objevidenciacriterio.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.criterio = objcriterio.listar();
            return View(
                id == 0 ? new EvidenciaCriterio() //agrega un nuevo objeto
                : objevidenciacriterio.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(EvidenciaCriterio objevidenciacriterio)
        {

            if (ModelState.IsValid)
            {
                objevidenciacriterio.guardar();
                return Redirect("~/evidenciacriterio");
            }
            else
            {
                return View("~/Views/evidenciacriterio/agregareditar.cshtml", objevidenciacriterio);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objevidenciacriterio.evidencia_id = id;
            objevidenciacriterio.eliminar();
            return Redirect("~/evidenciacriterio");
        }

    }
}