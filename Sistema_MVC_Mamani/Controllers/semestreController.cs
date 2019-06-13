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
    public class semestreController : Controller
    {
        //instanciar la clase semestre

            private Semestre objsemestre = new Semestre();

        // GET: semestre
        public ActionResult Index()
        {
            return View(objsemestre.listar());
        }

        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objsemestre.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            return View(
                id == 0 ? new Semestre() //agrega un nuevo objeto
                : objsemestre.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Semestre objsemestre)
        {

            if(ModelState.IsValid)
            {
                objsemestre.guardar();
                return Redirect("~/semestre");
            }
            else
            {
                return View("~/Views/semestre/agregareditar.cshtml", objsemestre);
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objsemestre.semestre_id = id;
            objsemestre.eliminar();
            return Redirect("~/semestre");
        }



    }
}