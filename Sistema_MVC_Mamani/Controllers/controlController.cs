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
    public class controlController : Controller
    {
        private Control objcontrol = new Control();
        private Semestre objsemestre = new Semestre();

        // GET: control
        public ActionResult Index()
        {
            ViewBag.semestre = objsemestre.listar();
            return View(objcontrol.listar());
        }



        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objcontrol.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            ViewBag.semestre = objsemestre.listar();
            return View(
                id == 0 ? new Control() //agrega un nuevo objeto
                : objcontrol.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Control objcontrol)
        {

            if (ModelState.IsValid)
            {
                objcontrol.guardar();
                return Redirect("~/control");
            }
            else
            {
                return View("~/Views/control/agregareditar.cshtml", objcontrol);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objcontrol.control_id = id;
            objcontrol.eliminar();
            return Redirect("~/control");
        }



    }
}