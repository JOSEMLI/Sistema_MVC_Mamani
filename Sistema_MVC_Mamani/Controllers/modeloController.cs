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
    public class modeloController : Controller
    {
        //instanciar la clase modelo

        private Modelo objmodelo = new Modelo();


        // GET: modelo
        public ActionResult Index()
        {
            return View(objmodelo.listar());
        }


        //accion visualizar
        public ActionResult visualizar(int id)
        {
            return View(objmodelo.obtener(id));
        }


        //accion agregar editar
        public ActionResult agregareditar(int id = 0)
        {
            return View(
                id == 0 ? new Modelo() //agrega un nuevo objeto
                : objmodelo.obtener(id) //devuelvo un objeto
                );
        }

        //accion guardar
        public ActionResult guardar(Modelo objmodelo)
        {

            if (ModelState.IsValid)
            {
                objmodelo.guardar();
                return Redirect("~/modelo");
            }
            else
            {
                return View("~/Views/modelo/agregareditar.cshtml");
            }

        }


        //accion eliminar

        public ActionResult eliminar(int id)
        {
            objmodelo.modelo_id = id;
            objmodelo.eliminar();
            return Redirect("~/modelo");
        }


    }
}