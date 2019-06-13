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
    public class criterioController : Controller
    {
        private Criterio objcriterio = new Criterio();
        private Modelo objmodelo = new Modelo();

        // GET: criterio
        public ActionResult Index()
        {
            return View(objcriterio.listar());
        }



        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objcriterio.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.modelo = objmodelo.listar();
            return View(
                id == 0 ? new Criterio() //agrega un nuevo objeto
                : objcriterio.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Criterio objcriterio)
        {

            if (ModelState.IsValid)
            {
                objcriterio.guardar();
                return Redirect("~/criterio");
            }
            else
            {
                return View("~/Views/criterio/agregareditar.cshtml", objcriterio);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objcriterio.criterio_id = id;
            objcriterio.eliminar();
            return Redirect("~/criterio");
        }


    }
}