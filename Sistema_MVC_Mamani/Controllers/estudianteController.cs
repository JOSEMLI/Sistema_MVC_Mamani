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
    public class estudianteController : Controller
    {

        //instanciar la clase estudiante

        private Estudiante objestudiante = new Estudiante();

        // GET: estudiante
        public ActionResult Index()
        {
            return View(objestudiante.listar());
        }




        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objestudiante.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            
            return View(
                id == 0 ? new Estudiante() //agrega un nuevo objeto
                : objestudiante.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Estudiante objestudiante)
        {

            if (ModelState.IsValid)
            {
                objestudiante.guardar();
                return Redirect("~/estudiante");
            }
            else
            {
                return View("~/Views/estudiante/agregareditar.cshtml", objestudiante);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objestudiante.estudiante_id = id;
            objestudiante.eliminar();
            return Redirect("~/estudiante");
        }

        

    }
}