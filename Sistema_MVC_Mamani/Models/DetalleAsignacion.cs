namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("DetalleAsignacion")]
    public partial class DetalleAsignacion
    {
        [Key]
        public int detalleasignacion_id { get; set; }

        public int asignacion_id { get; set; }

        public int docente_id { get; set; }

        public int criterio_id { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Asignacion Asignacion { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Docente Docente { get; set; }




        //metodo listar

        public List<DetalleAsignacion> listar() //retorna una coleccion de resgistro
        {
            var objdetalleasignacion = new List<DetalleAsignacion>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objdetalleasignacion = db.DetalleAsignacion.Include("asignacion").Include("docente").Include("criterio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objdetalleasignacion;
        }

        //metodo obtener

        public DetalleAsignacion obtener(int id) //retorna solo un objeto
        {
            var objdetalleasignacion = new DetalleAsignacion();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objdetalleasignacion = db.DetalleAsignacion.Include("asignacion").Include("docente").Include("criterio").Where(x => x.detalleasignacion_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objdetalleasignacion;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.detalleasignacion_id > 0)
                    {
                        //si existe un valor mayor a cero es porque exiiste el registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe el registro lo graba(nuevo)
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //metodo eliminar

        public void eliminar()
        {
            try
            {
                using (var db = new modelo_sistemas())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
